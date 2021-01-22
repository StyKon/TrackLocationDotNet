using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackLocation.Model;

namespace TrackLocation.IRepository
{
    public interface IUsersRepository
    {
        Task<ActionResult<IEnumerable<User>>> GetUser();
        Task<ActionResult<User>> GetUser(long id);
        Task<ActionResult<User>> PutUser(long id, User user);
        Task<ActionResult<User>> PostUser(User user);
        Task<ActionResult<User>> DeleteUser(long id);
        bool UserExists(long id);
    }
}
