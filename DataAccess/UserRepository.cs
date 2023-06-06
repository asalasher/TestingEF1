using DataAccess.DbModel;
using Domain;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class UserRepository
    {

        private readonly TestingEF1Entities _dbConnection;

        public UserRepository(TestingEF1Entities dbConnection)
        {
            _dbConnection = dbConnection;
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

    }
}
