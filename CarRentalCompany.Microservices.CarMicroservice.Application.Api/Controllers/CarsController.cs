using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CarRentalCompany.Microservices.CarMicroservice.Domain.AggregatesModel.CarAggregate;

namespace carRentalCompany.Microservices.carMicroservice.Application.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _CarService;

        public CarsController(ICarService CarService)
        {
            _CarService = CarService;
        }

        /// <summary>
        /// Lists all cars in
        /// the base
        /// </summary>        
        /// <returns>Object containing car information
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> Getcars()
        {
            try
            {
                return Ok(await _CarService.Getcars());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// List a car
        /// </summary>        
        /// <param name="id">Car identification number</param>        
        /// <returns>Object containing car information
        /// </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> Getcar(Guid id)
        {
            try
            {
                return Ok(await _CarService.Getcar(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Add new car
        /// </summary>
        /// <param name="car">Object for car creation</param>
        /// <returns>Object containing car information
        /// </returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(Guid id, Car car)
        {
            try
            {
                if (id != car.CarId)
                {
                    return BadRequest();
                }

                var result = await _CarService.PutCar(id, car);
                return Created("", result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
        /// <summary>
        /// Update car
        /// </summary>
        /// <param name="car">Object to update car</param>
        /// <returns>Object containing car information
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car car)
        {
            try
            {
                var resultado = _CarService.PostCar(car);
                var result = await _CarService.PostCar(car);
                return Created("", result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Delete car
        /// </summary>
        /// /// <param name="id">Car identification number</param>        
        /// <returns>Object containing car information
        /// </returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> DeleteCar(Guid id)
        {
            try
            {
                var result = await _CarService.DeleteCar(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
