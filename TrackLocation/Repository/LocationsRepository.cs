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
    public class LocationsRepository : ILocationsRepository
    {
        private readonly TrackLocationContext _context;

        public LocationsRepository(TrackLocationContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<Location>>> GetLocation()
        {
            return await _context.Location.ToListAsync();
        }

        public async Task<ActionResult<Location>> GetLocation(long id)
        {
            var location = await _context.Location.FindAsync(id);

            if (location == null)
            {
                return null;
            }

            return location;
        }

        public async Task<ActionResult<Location>> PostLocation(Location location)
        {
            _context.Location.Add(location);     
            await _context.SaveChangesAsync();   
            return location;

        }

        public async Task<ActionResult<Location>> PutLocation(long id, Location location)
        {
            if (id != location.LocationId)
            {
                return null;
            }
            _context.Entry(location).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return location;
        }

        public async Task<ActionResult<Location>> DeleteLocation(long id)
        {
            var location = await _context.Location.FindAsync(id);
            if (location == null)
            {
                return null;
            }
            _context.Location.Remove(location);
            await _context.SaveChangesAsync();
            return location;
        }
        public bool LocationExists(long id)
        {
            return _context.Location.Any(e => e.LocationId == id);
        }
    }
}
