using Services;
using System;

namespace TestingEF1
{
    public class App
    {
        private readonly ICarService _carsService;
        private readonly IUserService _usersService;

        public App(ICarService carrsService, IUserService usersService)
        {
            _usersService = usersService;
            _carsService = carrsService;
        }

        public void Start()
        {
            Console.WriteLine("hello world");
            var users = _usersService.GetListUsers();

            Console.WriteLine("Users:");
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }

            Console.WriteLine("Press a key to get the cars");
            Console.ReadLine();

            var cars = _carsService.GetCarList();
            Console.WriteLine("Cars:");
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }

            Console.WriteLine("Press a key to exit");
            Console.ReadLine();
        }

    }
}
