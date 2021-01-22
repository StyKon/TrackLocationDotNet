using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackLocation.Model;

namespace TrackLocation.IRepository
{
    public interface IUserLocationsRepository
    {
        Task<ActionResult<Location>> GetUserLocations(int userid);
        Task<ActionResult<Location>> GetUserLocation(int userid, int locationId);
        Task<ActionResult<Location>> DeleteUserLocation(long userid, long locId);
    }
}
