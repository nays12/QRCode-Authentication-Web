/*
 * Purpose: To configure the application to use all of the controllers in the Controllers folder
 * 
 */

using System.Web.Http;

namespace QRCodeAuth_Web
{
	public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
