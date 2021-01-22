using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackLocation.Model;

namespace TrackLocation.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly TrackLocationContext _context;

        public UserService(ILogger<UserService> logger, TrackLocationContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<User> GetUser(string Email, string Password)
        {
            var auth = await _context.User
             .FirstOrDefaultAsync(x => (x.Email == Email) &&
                                     (x.Password == Password));
            
            return auth;
        }

        public bool IsAnExistingUser(string Email)
        {
            var auth =  _context.User.Find(Email);
            if (auth != null)
                return true;
            else
                return false;

        }

        public async Task<bool> IsValidUserCredentials(string Email, string Password)
        {
            _logger.LogInformation($"Validating user [{Email}]");
            if (string.IsNullOrWhiteSpace(Email))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                return false;
            }
            var auth = await _context.User
             .FirstOrDefaultAsync(x => (x.Email == Email) &&
                                     (x.Password == Password));
           
            if (auth != null)
                return true;   
            else
                return false;


        }
        public async Task<ActionResult<User>> SignUp(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

    }
}
