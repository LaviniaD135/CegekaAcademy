using academy_tema02.Models;
using academy_tema02.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace academy_tema02.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
		private readonly ICarRepository repository;

		public CarsController(ICarRepository repository)
		{ 
			this.repository = repository;
		}

		//Get cars
		[HttpGet]
		public IEnumerable<Car> GetCars()
		{ 
			var cars=repository.GetCars();
			return cars;
		}
		[HttpGet("{id}")]
		public ActionResult<Car> GetCar(string id)
		{
			var car = repository.GetCar(id);
			if (car == null) 
			{ 
				return NotFound();
			}
			return car;
			
		}
		//POST /cars
		[HttpPost]
        public ActionResult<Car> CreateCar(Car car)
		{
			car.Id = Guid.NewGuid().ToString();

			repository.CreateCar(car);
			return CreatedAtAction(nameof(GetCar), new { id=car.Id}, car);

		}

		//PUT /cars/{id}
		[HttpPut("{id}")]
		public ActionResult<Car> UpdateCar(string id, Car c)
		{
			var existingCar=repository.GetCar(id);
			if(existingCar == null)
            {
				return NotFound();
            }

			Car updatedCar = new()
			{
				Id = Guid.NewGuid().ToString(),
				Model = c.Model,
				Color = c.Color,
				Price = c.Price,
				Year = c.Year
			};

			repository.CreateCar(updatedCar);
			return NoContent();

		}
		//DELETE cars/{id}
		[HttpDelete("{id}")]
		public ActionResult<Car> DeleteCar(string id)
		{
			var existingCar = repository.GetCar(id);
			if (existingCar == null)
			{
				return NotFound();
			}

			repository.DeleteCar(id);
			return NoContent();

		}

	}
}
