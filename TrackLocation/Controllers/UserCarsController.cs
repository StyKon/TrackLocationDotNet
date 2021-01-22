using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackLocation.IRepository;
using TrackLocation.Model;


namespace TrackLocation.Controllers
{
    [Route("api/UserCars")]
    [ApiController]
    public class UserCarsController : ControllerBase
    {

        public readonly IUserCarsRepository _repository;
        public UserCarsController(IUserCarsRepository repository)
        {
            _repository = repository;
        }

        // GET api/<UserCarsController>/5
        [HttpGet("{userId}")]
        public async Task<ActionResult<ICollection<Car>>>  GetUserCars(long userid)
        {
            return await _repository.GetUserCars(userid);
        }

        [HttpGet("{userId}/{CarId}")]
        public async Task<ActionResult<Car>> GetUserCar(long UserId, long CarId)
        {
            return await _repository.GetUserCar(UserId, CarId); 
        }

        [HttpPut("{userId}/{carId}")]
        public async Task<ActionResult<Car>> UpdateUserCar (long userId, long carId , Car car )
        {
           
             return await _repository.UpdateUserCar(userId, carId, car);
        }


        [HttpDelete("{userid}/{carid}")]
        public async Task<ActionResult<Car>> DeleteUserCar(long userid, long carid)
        {
            return await _repository.DeleteUserCar(userid, carid);
        }
    }
}
