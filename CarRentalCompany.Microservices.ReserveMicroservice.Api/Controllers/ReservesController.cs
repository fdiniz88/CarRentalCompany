using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarRentalCompany.Microservices.ReserveMicroservice.Domain.AggregatesModel.ReserveAggregate;
using System.Collections.Generic;


namespace CarRentalCompany.Microservices.ReserveMicroservice.Api.Controllers
{
//    [Authorize(Roles ="AccountHolder")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReservesController : ControllerBase
    {
        private readonly IReserveService _ReserveService;

        public ReservesController(IReserveService ReserveService)
        {
            _ReserveService = ReserveService;
        }

        // GET api/ReservesController/CarId
        [HttpGet("{CarId}")]
        public async Task<IEnumerable<Reserve>> Get(Guid ReserveId)
        {
            return await _ReserveService.GetCarStatement(ReserveId);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
