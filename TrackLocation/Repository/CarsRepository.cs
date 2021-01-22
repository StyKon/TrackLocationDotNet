using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackLocation.IRepository;
using TrackLocation.Model;

namespace TrackLocation.Repository
{
    public class CarsRepository : ICarsRepository
    {
        private readonly TrackLocationContext _context;

        public CarsRepository(TrackLocationContext _context)
        {
            this._context = _context;
        }
       

        public async Task<ActionResult<Car>> DeleteCar(long id)
        {
            var car = await _context.Car.FindAsync(id);
            _context.Car.Remove(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<ActionResult<IEnumerable<Car>>> GetCar()
        {
            return await _context.Car.ToListAsync();
        }

        public async Task<ActionResult<Car>> GetCar(long id)
        {
            var car = await _context.Car.FindAsync(id);
            return car;
        }

        public async Task<ActionResult<Car>> PostCar(Car car)
        {
            _context.Car.Add(car);
            await _context.SaveChangesAsync();

            return car;
        }

        public async Task<ActionResult<Car>> PutCar(long id, Car car)
        {
            if (id != car.CarId) return null;
            _context.Entry(car).State = EntityState.Modified;
            await _context.SaveChangesAsync(); 
            return car;
        }

        public bool CarExists(long id)
        {
            return _context.Car.Any(e => e.CarId == id);
        }
    }
}
