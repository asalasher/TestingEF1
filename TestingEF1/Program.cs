using DataAccess;
using System;

namespace TestingEF1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Notas. Error System.InvalidOperationException: 'No connection string named .... could be found in the application config file'.
            // Esto es porque uanque se genera un app config en el EF, hay que replicar la informacion del connexion string en el app config de la capa de presentacion
            // solo copiar y pegar algunas cosas. Solamente copia el configSections del connection string. Hay que instalar en el presentation mediante paquete nuget el EntityFramework.
            // De esta forma, entenderá lo que hay en el appConfig.

            //< connectionStrings >
            //  < add name = "TestingEF1Entities" connectionString = "metadata=res://*/DbModel.Model1.csdl|res://*/DbModel.Model1.ssdl|res://*/DbModel.Model1.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=.;initial catalog=TestingEF1;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName = "System.Data.EntityClient" />
            //</ connectionStrings >

            // Es puesto antes del startup

            Console.WriteLine("hello world");

            var usersRepo = new UserRepository();
            var users = usersRepo.GetUsersList();

            Console.WriteLine("Users:");
            foreach (var user in users)
            {
                Console.WriteLine(user.ToString());
            }

            Console.ReadLine();

        }
    }
}
