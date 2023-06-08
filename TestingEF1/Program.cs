using DataAccess;
using Services;
using System;
using Unity;

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

            // El connection String es puesto antes del startup

            //IUserRepository userRepository = new UserRepository();
            //ICarRepository carRepository = new CarRepository();

            //ICarService carService = new CarService(carRepository);
            //IUserService userService = new UserService(userRepository);

            Console.WriteLine("Registering dependencies ...");
            // Create container
            IUnityContainer container = new UnityContainer();

            // Do your registrations.
            RegisterTypes(container);

            // Let Unity resolve ProgramStarter and create a build plan.
            App app = container.Resolve<App>();

            app.Start();

            Console.WriteLine("Press any key to continuer");
            Console.ReadKey();
        }

        static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<App>(); // Register a class that continues your program. Este tira de la manta
            container.RegisterType<ICarService, CarService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<ICarRepository, CarRepository>(TypeLifetime.Singleton);
            container.RegisterType<IUserRepository, UserRepository>(TypeLifetime.Singleton);
        }

    }
}
