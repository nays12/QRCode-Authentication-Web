/*
 * Purpose: 
 * This API Contoller is responsible for defining and performing the GET and POST request necessary to
 * recieve and send User objects between the Web and Mobile Applications
 * 
 * Contributions: 
 * Naomi Wiggins 
 * 
 */

using System.Web.Http;
using System.Web.Http.Description;
using QRCodeAuth_Web.Data;
using QRCodeAuth_Web.Models;


namespace QRCodeAuth_Web.Controllers
{
    public class UsersController : ApiController
    {
		[Route("api/Users/GetUserbyId")]
		[HttpGet]
		[ResponseType(typeof(User))]
		public User GetUserbyId(string id)
		{
			return UsersRepo.FindUserById(id);
		}

		[Route("api/Users/RecieveUserAccount")]
		[HttpPost]
		public IHttpActionResult RecieveUserAccount(User u)
		{
			Default.GetUserFromMobile(u);
			return Ok("Your data has been recieved!");
		}
	}
}
