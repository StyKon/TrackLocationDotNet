using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using TrackLocation.Infrastructure;
using TrackLocation.Model;
using TrackLocation.Requests;
using TrackLocation.Services;

namespace TrackLocation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        //private readonly ILogger<AuthenticationController> _logger;
        private readonly IUserService _userService;
        private readonly IJwtAuthManager _jwtAuthManager;
        

        public AuthenticationController(IUserService userService, IJwtAuthManager jwtAuthManager, TrackLocationContext context)
        {
            _userService = userService;
            _jwtAuthManager = jwtAuthManager;
           
        }
        

        [AllowAnonymous]
        [HttpPost("signin")]
        public async Task<ActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!await _userService.IsValidUserCredentials(request.Email, request.Password))
            {
                return Unauthorized();
            }

            // var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var User = _userService.GetUser(request.Email, request.Password);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name,request.Email),
                new Claim("UserId", Convert.ToString(User.Result.UserId)),
                new Claim("Username", User.Result.FirstName + ' '+ User.Result.LastName),
                new Claim("TypeUser", User.Result.TypeUser)
            };

            var jwtResult = _jwtAuthManager.GenerateTokens(request.Email, claims, DateTime.Now);
            // _logger.LogInformation($"User [{request.Email}] logged in the system.");
            return Ok(new LoginResult
            {
                Email = request.Email,
                UserId =  User.Result.UserId,
                Username = User.Result.FirstName + ' ' + User.Result.LastName,
                TypeUser = User.Result.TypeUser,
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<ActionResult<User>> SignUp(User user)
        {
            await _userService.SignUp(user);
            return user;
        }

        [HttpGet("user")]
        [Authorize]
        public ActionResult GetCurrentUser()
        {
            return Ok(new LoginResult
            {

                Email = User.Identity.Name
            });
        }

        [HttpPost("logout")]
        [Authorize]
        public ActionResult Logout()
        {
            var Email = User.Identity.Name;
            _jwtAuthManager.RemoveRefreshTokenByUserEmail(Email);
          //  _logger.LogInformation($"User [{Firstname}] logged out the system.");
            return Ok();
        }

        [HttpPost("refresh-token")]
        [Authorize]
        public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            try
            {
                var Email = User.Identity.Name;
             //   _logger.LogInformation($"User [{Firstname}] is trying to refresh JWT token.");

                if (string.IsNullOrWhiteSpace(request.RefreshToken))
                {
                    return Unauthorized();
                }

                var accessToken = await HttpContext.GetTokenAsync("Bearer", "access_token");
                var jwtResult = _jwtAuthManager.Refresh(request.RefreshToken, accessToken, DateTime.Now);
             //   _logger.LogInformation($"User [{Firstname}] has refreshed JWT token.");
                return Ok(new LoginResult
                {
                    Email = Email,

                    AccessToken = jwtResult.AccessToken,
                    RefreshToken = jwtResult.RefreshToken.TokenString
                });
            }
            catch (SecurityTokenException e)
            {
                return Unauthorized(e.Message); // return 401 so that the client side can redirect the user to login page
            }
        }
    }
}
