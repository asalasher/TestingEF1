using DataAccess.DbModel;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DataAccess
{
    public class CarRepository : ICarRepository
    {

        // _carsRepository to be replacedd by the database
        //private readonly List<Car> _carsRepository = new List<Car>();
        private readonly TestingEF1Entities _dbConnection;

        public CarRepository()
        {
            //_dbConnection = dbConnection;
            _dbConnection = new TestingEF1Entities();
        }

        // El que no acaba en S es la entity de capa dominio
        public List<Car> GetCarsList()
        {
            // Esto me trae todas las data entities
            //using (_dbConnection)
            //{
            //}
            List<Cars> carsFromDb = _dbConnection.Cars.ToList();

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
            // TODO - select by id
            if (_dbConnection.Cars.Find(id) is Cars car)
            {
                Car entityCar = new Car
                {
                    Id = car.Id,
                    Model = car.Model,
                    IdOwner = car.IdOwner
                };
                return entityCar;

            }
            return null;
        }

        public bool Insert(Car domainEntity)
        {
            Cars newDataEntity = new Cars
            {
                Id = domainEntity.Id,
                Model = domainEntity.Model,
                IdOwner = domainEntity.IdOwner,
            };

            try
            {
                Cars car = _dbConnection.Cars.Add(newDataEntity);
                _dbConnection.SaveChanges();

                if (car is null)
                {
                    return false;
                }
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

        }

        public bool UpsertCar(Car domainEntity)
        {
            // Creation of data entity
            Cars newDataEntity = new Cars
            {
                Id = domainEntity.Id,
                Model = domainEntity.Model,
                IdOwner = domainEntity.IdOwner,
            };

            try
            {
                _dbConnection.Cars.AddOrUpdate(newDataEntity);
                _dbConnection.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

        }

        public bool Delete(int id)
        {
            // Todo - check this
            Cars car = _dbConnection.Cars.Find(id);
            if (car is null)
            {
                return false;
            }

            _dbConnection.Cars.Remove(car);
            _dbConnection.SaveChanges();

            return true;
        }

        //List<Users> users = _dbConnection.Users.ToList();
        //List<Cars> cars = _dbConnection.Cars.ToList();

        //var query = from user in users
        //            join car in cars on user.Id equals car.IdOwner
        //            where user.Id == userId
        //            select car;


    }
}
