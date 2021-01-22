using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackLocation.Model;

namespace TrackLocation.Services
{
    public interface IUserService
    {
        bool IsAnExistingUser(string Email);
        Task<bool> IsValidUserCredentials(string Email, string password);
        Task<User> GetUser(string Email, string Password);
        Task<ActionResult<User>> SignUp(User user);
    }
}
