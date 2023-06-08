using DataAccess;
using Domain;
using System.Collections.Generic;

namespace Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carsRepo;

        public CarService(ICarRepository carsRepo)
        {
            _carsRepo = carsRepo;
        }

        public List<string> GetCarList()
        {
            var selectedCarString = new List<string>();

            List<Car> selectedCar = _carsRepo.GetCarsList();
            selectedCar.ForEach(car =>
            {
                selectedCarString.Add(car.ToString());
            });

            return selectedCarString;
        }

    }
}
