using StackChatAPI.App_Start;
using StackChatAPI.Application.Interfaces.Repositories;
using StackChatAPI.Application.Interfaces.Services;
using StackChatAPI.Application.Services;
using StackChatAPI.Infrastructure.Persistence.Repositories;
using System.Web.Http;
using System.Web.Http.Cors;
using Unity;

namespace StackChatAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<ILoginService, LoginService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IMessageService, MessageService>();
            container.RegisterType<IMessageRepositoryAsync, MessageRepositoryAsync>();
            container.RegisterType<IUserRepositoryAsync, UserRepositoryAsync>();
            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            /**config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v{version:apiVersion}/{controller}",
                defaults: new { id = RouteParameter.Optional }
            );*/
        }
    }
}
