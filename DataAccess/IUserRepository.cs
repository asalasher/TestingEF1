using Domain;
using System.Collections.Generic;

namespace DataAccess
{
    public interface IUserRepository
    {
        List<Car> GetUserCars(int userId);
        List<User> GetUsersList();
    }
}