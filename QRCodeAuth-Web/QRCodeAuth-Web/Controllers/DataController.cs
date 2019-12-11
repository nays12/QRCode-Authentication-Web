/*
 * Purpose: 
 * This API Contoller is responsible sending a randomly generated 6-digit code to the calling
 * mobile device for the Web App Login functionality.
 * 
 * Contributors: 
 * Naomi Wiggins
 * 
 */

using System.Web.Http;

namespace QRCodeAuth_Web.Controllers
{
    public class DataController : ApiController
    {
		[Route("api/Data/GetLoginCode")]
		[HttpGet]
		public int GetLoginCode()
		{
			return Default.GetGenCode();
		}
	}
}
