using academy_tema02.Models;
using System;
using System.Collections.Generic;

namespace academy_tema02.Repositories
{
    public interface ICarRepository
    {
        Car GetCar(string id);
        IEnumerable<Car> GetCars();
        void CreateCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(string id);
    }
}