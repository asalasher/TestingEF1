using DataAccess.DbModel;
using Domain;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class CarRepository
    {

        // _carsRepository to be replacedd by the database
        //private readonly List<Car> _carsRepository = new List<Car>();

        public CarRepository()
        {
            // ???
            var _carsRepository = new Cars();
        }

        // El que no acaba en S es la entity de capa dominio
        public List<Car> GetCarsList()
        {
            TestingEF1Entities dbConnection = new TestingEF1Entities();

            // Esto me trae todas las data entities
            List<Cars> carsFromDb = dbConnection.Cars.ToList();

            // Ahora toca relizar la transformacion de data entity a domain entity
            // Mapper
            List<Car> carsAsDomainEntities = new List<Car>();
            foreach (Cars car in carsFromDb)
            {
                carsAsDomainEntities.Add(new Car
                {
                    Id = car.Id,
                    Model = car.Model,
                    IdOwner = car.IdOwner,
                });
            }
            return carsAsDomainEntities;
        }

        public Car GetById(int id)
        {
            return _carsRepository.FirstOrDefault(x => x.Id == id);
        }

        public bool Insert(Car entity)
        {
            _carsRepository.Add(entity);
            return true;
        }

        public bool Update(Car entity)
        {
            int carIndex = _carsRepository.IndexOf(entity);
            if (carIndex > -1)
            {
                _carsRepository[carIndex] = entity;
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            Car car = GetById(id);
            if (car != null)
            {
                return _carsRepository.Remove(car);
            }
            return false;
        }

    }
}
