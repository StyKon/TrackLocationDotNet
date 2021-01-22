using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackLocation.Model;

namespace TrackLocation.IRepository
{
    public interface ILocationsRepository
    {
        Task<ActionResult<IEnumerable<Location>>> GetLocation();
        Task<ActionResult<Location>> GetLocation(long id);
        Task<ActionResult<Location>> PutLocation(long id, Location location);
        Task<ActionResult<Location>> PostLocation(Location location);
        Task<ActionResult<Location>> DeleteLocation(long id);
        bool LocationExists(long id);
    }
}
