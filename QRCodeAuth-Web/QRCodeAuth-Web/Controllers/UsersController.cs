using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using QRCodeAuth_Web.Data;
using QRCodeAuth_Web.Models;


namespace QRCodeAuth_Web.Controllers
{
    public class UsersController : ApiController
    {
		private WebSystemData db = new WebSystemData();


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
