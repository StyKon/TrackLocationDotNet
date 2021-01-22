using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackLocation.Model;

namespace TrackLocation.IRepository
{
    public interface ITypeCarsRepository
    {
        Task<ActionResult<IEnumerable<TypeCar>>> GetTypeCar();
        Task<ActionResult<TypeCar>> GetTypeCar(long id);
        Task<ActionResult<TypeCar>> PutTypeCar(long id, TypeCar typeCar);
        Task<ActionResult<TypeCar>> PostTypeCar(TypeCar typeCar);
        Task<ActionResult<TypeCar>> DeleteTypeCar(long id);
        bool TypeCarExists(long id);

    }
}
