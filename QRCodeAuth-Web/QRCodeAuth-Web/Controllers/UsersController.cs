using QRCodeAuth_Web.Data;
using QRCodeAuth_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace QRCodeAuth_Web.Controllers
{
	public class UsersController : ApiController
	{

		[Route("api/Users/GetUserWithId")]
		[HttpGet]
		[ResponseType(typeof(User))]
		public User GetUserWithId(string id)
		{
			return UsersRepo.FindUserById(id);
		}

	}
}
