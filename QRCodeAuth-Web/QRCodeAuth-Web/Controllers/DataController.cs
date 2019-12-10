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
    public class DataController : ApiController
    {
		// For testing random number
		[Route("api/Data/GetLoginCode")]
		[HttpGet]
		public int GetLoginCode()
		{
			return Default.GetGenCode();
		}


	}
}
