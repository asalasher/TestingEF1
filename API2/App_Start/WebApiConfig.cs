using API2.App_Start;
using DataAccess;
using Services;
using System.Web.Http;
using Unity;

namespace API2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Here comes the UnityContainer class
            var container = new UnityContainer();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IUserService, UserService>();

            // This class resolves
            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
