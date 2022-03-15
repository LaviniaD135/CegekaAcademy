using academy_tema02.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace academy_tema02.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly List<Car> cars = new()
        {
            new Car { Id = System.Guid.NewGuid().ToString(), Model = "Renault Megane", Color = "Red", Price = 17000.0f, Year = 2017 },
            new Car { Id = System.Guid.NewGuid().ToString(), Model = "Honda Civic", Color = "Blue", Price = 24800.0f, Year = 2019 },
            new Car { Id = System.Guid.NewGuid().ToString(), Model = "Fiat 500", Color = "Pink", Price = 19500.0f, Year = 2020 },
            new Car { Id = System.Guid.NewGuid().ToString(), Model = "G-Class", Color = "Black", Price = 50000.0f, Year = 2019 },
            new Car { Id = System.Guid.NewGuid().ToString(), Model = "BMW X5", Color = "Blue", Price = 20800.0f, Year = 2019 },
            new Car { Id = System.Guid.NewGuid().ToString(), Model = "Ford Focus", Color = "Red", Price = 12500.0f, Year = 2020 }
        };

        public IEnumerable<Car> GetCars()
        {
            return cars;
        }

        public Car GetCar(string id)
        {
            return cars.Where(car => car.Id == id).SingleOrDefault();
        }
     


        public void CreateCar(Car car)
        {
            cars.Add(car);
        }

        public void UpdateCar(Car car)
        {
            var index = cars.FindIndex(existingCar => existingCar.Id == car.Id);

            cars[index] = car;
        }

        public void DeleteCar(string id)
        {
            var index = cars.FindIndex(existingCar => existingCar.Id == id);
            cars.RemoveAt(index);

        }
    }
}
