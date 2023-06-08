using DataAccess;
using System.Collections.Generic;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _usersRepository;

        public UserService(IUserRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public List<string> GetListUsers()
        {
            var usersList = new List<string>();

            var users = _usersRepository.GetUsersList();
            users.ForEach(x => usersList.Add(x.ToString()));

            return usersList;
        }

    }
}
