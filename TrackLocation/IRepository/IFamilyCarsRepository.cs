using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackLocation.Model;

namespace TrackLocation.IRepository
{
    public interface IFamilyCarsRepository
    {
        Task<ActionResult<IEnumerable<FamilyCar>>> GetFamilyCar();
        Task<ActionResult<FamilyCar>> GetFamilyCar(long id);
        Task<ActionResult<FamilyCar>> PutFamilyCar(long id, FamilyCar familyCar);
        Task<ActionResult<FamilyCar>> PostFamilyCar(FamilyCar familyCar);
        Task<ActionResult<FamilyCar>> DeleteFamilyCar(long id);
        bool FamilyCarExists(long id);
    }
}
