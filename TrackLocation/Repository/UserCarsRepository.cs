using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackLocation.IRepository;
using TrackLocation.Model;

namespace TrackLocation.Repository
{
    public class UserCarsRepository : IUserCarsRepository
    {
        private readonly TrackLocationContext _context;
        public UserCarsRepository(TrackLocationContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<Car>> DeleteUserCar(long userid, long carid)
        {
            var car = await _context.Car.Where(u => u.CarId == carid && u.UserId == userid).FirstOrDefaultAsync();
            _context.Car.Remove(car);
            await _context.SaveChangesAsync();

            return car;
        }

        public async Task<ActionResult<Car>> GetUserCar(long UserId, long CarId)
        {
            
            var test = await _context.Car.Select(r => new Car
            {
                CarId = r.CarId,
                NameCar = r.NameCar,
                Matricule = r.Matricule,
                NumberPlace = r.NumberPlace,
                Puissance = r.Puissance,
                TotKm = r.TotKm,
                DateCirculation = r.DateCirculation,
                TypeCarId = r.TypeCar.TypeCarId,
                FamilyCarId = r.FamilyCar.FamilyCarId,
                UserId = r.User.UserId


            }).Where(C => C.UserId == UserId && C.CarId == CarId).FirstOrDefaultAsync();
            return test;
        }

        public async Task<ActionResult<ICollection<Car>>> GetUserCars(long userid)
        {
           
            var test = await _context.Car
                            .Select(r => new Car
                             {
                                CarId =  r.CarId,
                                NameCar= r.NameCar,
                                Matricule= r.Matricule,
                                NumberPlace= r.NumberPlace,
                                Puissance= r.Puissance,
                                TotKm= r.TotKm,
                                DateCirculation= r.DateCirculation,
                                TypeCarId= r.TypeCar.TypeCarId,
                                FamilyCarId=  r.FamilyCar.FamilyCarId,
                                UserId = r.User.UserId


                            }).Where(C => C.UserId == userid)
                             .ToListAsync();

            return test;
        }

        public async Task<ActionResult<Car>> UpdateUserCar(long userId,long carId , Car car)
        {
            /* var car = await _context.Car.Where(u => u.CarId == carId && u.UserId == userId)
                 .FirstOrDefaultAsync();*/
            if (userId != car.UserId && carId != car.CarId) return null;

            _context.Entry(car).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return car;
        }
    }
}
