using System.Web.Http;
using System.Web.Routing;
using QRCodeAuth_Web.Data;

namespace QRCodeAuth_Web
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			GlobalConfiguration.Configure(WebApiConfig.Register);
		}

	}
}