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
    public class CarsController : ControllerBase
    {
        private readonly ICarsRepository _repository;

        public CarsController(ICarsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCar()
        {
            return await _repository.GetCar();
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(long id)
        {
            return await _repository.GetCar(id);
        }

        // PUT: api/Cars/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Car>> PutCar(long id, Car car)
        {
            return await _repository.PutCar(id, car);    
        }

        // POST: api/Cars
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car car)
        {
            return await _repository.PostCar(car); 
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> DeleteCar(long id)
        {   
            return await _repository.DeleteCar(id);         
        }
   
    }
}
