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
    public class UserLocationsRepository : IUserLocationsRepository
    {
        private readonly TrackLocationContext _context;
        public UserLocationsRepository(TrackLocationContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<Location>> DeleteUserLocation(long userid, long locId)
        {
            var location = await _context.Location.Include(u => u.LocationId == locId).FirstOrDefaultAsync(car => car.UserId == userid);
            if (location == null)
            {
                return null;
            }

            _context.Location.Remove(location);
            await _context.SaveChangesAsync();

            return location;
        }

        public async Task<ActionResult<Location>> GetUserLocation(int userid, int locationId)
        {
            IQueryable<Location> result = (IQueryable<Location>)await (from location in _context.Location
                                          join user in _context.User
                                          on location.User.UserId equals user.UserId
                                          where location.UserId == userid

                                          select new Location
                                          {
                                              LocationId = location.LocationId,
                                              StartDate = location.StartDate,
                                              EndDate = location.EndDate,
                                              Tracking = location.Tracking,
                                              UserId = location.UserId

                                          }).ToListAsync();
            

            IQueryable<Location> ListLocation = result;
            return (Location)ListLocation;
        }

        public async Task<ActionResult<Location>> GetUserLocations(int userid)
        {

            IQueryable<Location> result = (IQueryable<Location>)await (from location in _context.Location
                                          join user in _context.User
                                          on location.User.UserId equals user.UserId
                                          where location.UserId == userid

                                          select new Location
                                          {
                                              LocationId = location.LocationId,
                                              StartDate = location.StartDate,
                                              EndDate = location.EndDate,
                                              Tracking = location.Tracking,
                                              UserId = location.UserId

                                          }).ToListAsync();

            IQueryable<Location> ListLocation = result;
            return (Location)ListLocation;
        }
    }
}
