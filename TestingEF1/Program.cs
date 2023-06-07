using DataAccess;
using DataAccess.DbModel;
using Domain;
using System;
using System.Collections.Generic;

namespace TestingEF1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Notas. Error System.InvalidOperationException: 'No connection string named .... could be found in the application config file'.
            // Esto es porque uanque se genera un app config en el EF, hay que replicar la informacion del connexion string en el app config de la capa de presentacion
            // solo copiar y pegar algunas cosas. Solamente copia el configSections del connection string. Hay que instalar en el presentation mediante paquete nuget el "EntityFramework".
            // De esta forma, entenderá lo que hay en el appConfig.

            //< connectionStrings >
            //  < add name = "TestingEF1Entities" connectionString = "metadata=res://*/DbModel.Model1.csdl|res://*/DbModel.Model1.ssdl|res://*/DbModel.Model1.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=.;initial catalog=TestingEF1;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName = "System.Data.EntityClient" />
            //</ connectionStrings >

            // Es puesto antes del startup

            Console.WriteLine("hello world");

            var usersRepo = new UserRepository(new TestingEF1Entities());
            var users = usersRepo.GetUsersList();

            Console.WriteLine("Users:");
            foreach (var user in users)
            {
                Console.WriteLine(user.ToString());
            }

            Console.WriteLine("Press a key to get the cars");
            Console.ReadLine();

            Console.WriteLine("Cars:");
            // TODO - dependency injection
            var carsRepo = new CarRepository(new TestingEF1Entities());
            List<Car> cars = carsRepo.GetCarsList();
            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }

            Console.WriteLine("Press a key");
            Console.ReadLine();

            Console.WriteLine("Modify a Car:");
            Console.WriteLine("Introduce the car Id");
            int idCar = int.Parse(Console.ReadLine());
            Car selectedCar = carsRepo.GetById(idCar);

            Console.WriteLine("The car selected is:");
            Console.WriteLine(selectedCar.ToString());

            Console.WriteLine("Introduce new car model");
            string newCarModel = Console.ReadLine();
            selectedCar.Model = newCarModel;

            Console.WriteLine("The new car information is:");
            Console.WriteLine(selectedCar.ToString());

            bool status = carsRepo.UpsertCar(selectedCar);
            if (status)
            {
                Console.WriteLine("Succesfully updated");
            }

            Console.WriteLine("Get cars from user. Introduce user's id");
            int idUser = int.Parse(Console.ReadLine());
            List<Car> userCars = carsRepo.GetCarsFromUser(idUser);
            if (userCars.Count > 0)
            {
                userCars.ForEach(car => Console.WriteLine(car.ToString()));
            }
            else { Console.WriteLine("The user has no cars"); }

            Console.ReadLine();
        }
    }
}
