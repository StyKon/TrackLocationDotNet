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
    public class FamilyCarsController : ControllerBase
    {
        private readonly IFamilyCarsRepository _repository;

        public FamilyCarsController(IFamilyCarsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/FamilyCars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FamilyCar>>> GetFamilyCar()
        {
            return await _repository.GetFamilyCar();
        }

        // GET: api/FamilyCars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FamilyCar>> GetFamilyCar(long id)
        {
            return await _repository.GetFamilyCar(id);
        }

        // PUT: api/FamilyCars/5
        [HttpPut("{id}")]
        public async Task<ActionResult<FamilyCar>> PutFamilyCar(long id, FamilyCar familyCar)
        {
            if (id != familyCar.FamilyCarId)
            {
                return BadRequest();
            }

           return await _repository.PutFamilyCar(id, familyCar);
        }

        // POST: api/FamilyCars
        [HttpPost]
        public async Task<ActionResult<FamilyCar>> PostFamilyCar(FamilyCar familyCar)
        {
            return await _repository.PostFamilyCar(familyCar);
        }

        // DELETE: api/FamilyCars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FamilyCar>> DeleteFamilyCar(long id)
        {

            return await _repository.DeleteFamilyCar(id);
        }

        
    }
}
