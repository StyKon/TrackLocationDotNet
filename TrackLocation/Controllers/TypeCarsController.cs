using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackLocation.IRepository;
using TrackLocation.Model;

namespace TrackLocation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeCarsController : ControllerBase
    {
        private readonly ITypeCarsRepository _repository;

        public TypeCarsController(ITypeCarsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/TypeCars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeCar>>> GetTypeCar()
        {
            return await _repository.GetTypeCar();
        }

        // GET: api/TypeCars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeCar>> GetTypeCar(long id)
        {
            return  await _repository.GetTypeCar(id);
        }

        // PUT: api/TypeCars/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TypeCar>> PutTypeCar(long id, TypeCar typeCar)
        {
            return await _repository.PutTypeCar(id, typeCar);
        }

        // POST: api/TypeCars
        [HttpPost]
        public async Task<ActionResult<TypeCar>> PostTypeCar(TypeCar typeCar)
        {    
           return await _repository.PostTypeCar(typeCar);
        }

        // DELETE: api/TypeCars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TypeCar>> DeleteTypeCar(long id)
        {
            return await _repository.DeleteTypeCar(id);
        }
    }
}
