using DataAccess.DbModel;
using Domain;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class UserRepository : IUserRepository
    {

        private readonly TestingEF1Entities _dbConnection;

        public UserRepository()
        {
            //_dbConnection = dbConnection;
            _dbConnection = new TestingEF1Entities();
        }

        public List<User> GetUsersList()
        {
            // Esto me trae todas las data entities
            List<Users> usersFromDb = _dbConnection.Users.ToList();

            // Ahora toca relizar la transformacion de data entity a domain entity
            // Mapper
            List<User> usersAsDomainEntities = new List<User>();

            foreach (Users user in usersFromDb)
            {
                usersAsDomainEntities.Add(new User
                {
                    Id = user.Id,
                    Name = user.Name,
                    DateOfBirth = user.DateOfBirth,
                });
            }
            return usersAsDomainEntities;
        }

        public List<Car> GetUserCars(int userId)
        {
            List<Cars> userCars = _dbConnection.Users.Find(userId).Cars.ToList();

            List<Car> domainEntityCars = new List<Car>();

            // TODO -> check this
            userCars.ForEach(x =>
            {
                domainEntityCars.Add(new Car
                {
                    Id = x.Id,
                    Model = x.Model,
                    IdOwner = x.IdOwner,
                });
            });

            foreach (var car in userCars)
            {
                Car entityCar = new Car
                {
                    Id = car.Id,
                    Model = car.Model,
                    IdOwner = car.IdOwner
                };
                domainEntityCars.Add(entityCar);
            }

            return domainEntityCars;
        }



    }
}
