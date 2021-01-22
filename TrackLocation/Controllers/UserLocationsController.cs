using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackLocation.IRepository;
using TrackLocation.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrackLocation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLocationsController : ControllerBase
    {
        private readonly IUserLocationsRepository _repository;

        public UserLocationsController(IUserLocationsRepository repository)
        {
            _repository = repository;
        }

        // GET api/<UserLocationsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetUserLocations(int userid)
        {
            return await _repository.GetUserLocations(userid);
        }

        [HttpGet("{userId}/{locationId}")]
        public async Task<ActionResult<Location>> GetUserLocation(int userid, int locationId)
        {
            return await _repository.GetUserLocation(userid, locationId);
        }

        [HttpDelete("{userid}/{locId}")]
        public async Task<ActionResult<Location>> DeleteUserLocation(long userid, long locId)
        {
            return await _repository.DeleteUserLocation(userid, locId);
        }


    }
}
