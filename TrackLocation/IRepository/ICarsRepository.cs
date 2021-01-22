using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackLocation.Model;

namespace TrackLocation.IRepository
{
    public interface ICarsRepository
    {
        Task<ActionResult<IEnumerable<Car>>> GetCar();
        Task<ActionResult<Car>> GetCar(long id);
        Task<ActionResult<Car>> PutCar(long id, Car car);
        Task<ActionResult<Car>> PostCar(Car car);
        Task<ActionResult<Car>> DeleteCar(long id);
        bool CarExists(long id);
    }
}
