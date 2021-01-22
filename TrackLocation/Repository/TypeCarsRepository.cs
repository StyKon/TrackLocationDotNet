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
    public class TypeCarsRepository : ITypeCarsRepository
    {

        private readonly TrackLocationContext _context;
        public TypeCarsRepository(TrackLocationContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<TypeCar>>> GetTypeCar()
        {
            return await _context.TypeCar.ToListAsync();
        }

        public async Task<ActionResult<TypeCar>> GetTypeCar(long id)
        {
            var typeCar = await _context.TypeCar.FindAsync(id);
            if (typeCar == null)
            {
                return null;
            }
            return typeCar;
        }

        public async Task<ActionResult<TypeCar>> PostTypeCar(TypeCar typeCar)
        {
            _context.TypeCar.Add(typeCar);
            await _context.SaveChangesAsync();
            return typeCar;
        }

        public async Task<ActionResult<TypeCar>> PutTypeCar(long id, TypeCar typeCar)
        {
            if (id != typeCar.TypeCarId)
            {
                return null;
            }
            _context.Entry(typeCar).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
            return typeCar;
        }

        public async Task<ActionResult<TypeCar>> DeleteTypeCar(long id)
        {
            var typeCar = await _context.TypeCar.FindAsync(id);
            if (typeCar == null)
            {
                return null;
            }

            _context.TypeCar.Remove(typeCar);
            await _context.SaveChangesAsync();

            return typeCar;
        }     
        public bool TypeCarExists(long id)
        {
            return _context.TypeCar.Any(e => e.TypeCarId == id);
        }
    }
}
