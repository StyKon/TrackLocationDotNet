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
    public class FamilyCarsRepository : IFamilyCarsRepository
    {
        private readonly TrackLocationContext _context;

        public FamilyCarsRepository(TrackLocationContext context)
        {
            _context = context;
        }
      

        public async Task<ActionResult<IEnumerable<FamilyCar>>> GetFamilyCar()
        {
            return await _context.FamilyCar.ToListAsync();
        }

        public async Task<ActionResult<FamilyCar>> GetFamilyCar(long id)
        {
            var familyCar = await _context.FamilyCar.FindAsync(id);
            return familyCar;
        }

        public async Task<ActionResult<FamilyCar>> PostFamilyCar(FamilyCar familyCar)
        {
            _context.FamilyCar.Add(familyCar);
            await _context.SaveChangesAsync();
            return familyCar;

        }

        public async Task<ActionResult<FamilyCar>> PutFamilyCar(long id, FamilyCar familyCar)
        {
            if (id != familyCar.FamilyCarId)
            {
                return null;
            }
            _context.Entry(familyCar).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return familyCar;
        }
        public async Task<ActionResult<FamilyCar>> DeleteFamilyCar(long id)
        {
            var familyCar = await _context.FamilyCar.FindAsync(id);
            _context.FamilyCar.Remove(familyCar);
            await _context.SaveChangesAsync();
            return familyCar;
        }

        public bool FamilyCarExists(long id)
        {
            return _context.FamilyCar.Any(e => e.FamilyCarId == id);
        }
    }
}
