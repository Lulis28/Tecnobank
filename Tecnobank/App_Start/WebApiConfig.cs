using System.Web.Http;
using Tecnobank.App_Start;
using Tecnobank.Filters;

namespace Tecnobank
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Filters.Add(new LogExceptionFilterAttribute());
        }
    }
}
