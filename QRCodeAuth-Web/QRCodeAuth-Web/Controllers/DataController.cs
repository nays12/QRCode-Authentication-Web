using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QRCodeAuth_Web.Controllers
{
    public class DataController : ApiController
    {
		// For testing random number
		[Route("api/Data/GetLoginCode")]
		[HttpGet]
		public int GetLoginCode()
		{
			return Default.getGenCode();
		}
	}
}
