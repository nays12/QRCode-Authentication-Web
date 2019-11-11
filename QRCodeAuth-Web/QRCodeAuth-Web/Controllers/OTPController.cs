using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QRCodeAuth_Web.Data;
using QRCodeAuth_Web.Models;

namespace QRCodeAuth_Web.Controllers
{
    public class OTPController : ApiController
    {
        private WebSystemData db = new WebSystemData();

        // GET: api/OTP
        [Route("api/OTP")]
        [HttpGet]
        public string Value()
        {
            //return OTP.generateOTP();
            return "123456";
        }
    }
}
