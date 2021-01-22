using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackLocation.Model;

namespace TrackLocation.IRepository
{
    public interface IUserCarsRepository
    {
        Task<ActionResult<ICollection<Car>>> GetUserCars(long userid);
        Task<ActionResult<Car>> GetUserCar(long UserId, long CarId);
        Task<ActionResult<Car>> UpdateUserCar(long userId, long carId , Car car);
        Task<ActionResult<Car>> DeleteUserCar(long userid, long carid);
        //Task<ActionResult<Car>> UpdateUserCar(ActionResult<Car> car);
       
    }
}
