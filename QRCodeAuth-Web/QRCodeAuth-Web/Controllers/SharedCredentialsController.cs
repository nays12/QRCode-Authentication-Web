using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QRCodeAuth_Web.Models;
using System.Web.Http.Description;
using Newtonsoft.Json;

namespace QRCodeAuth_Web.Controllers
{
    public class SharedCredentialsController : ApiController
    {

        [Route("api/SharedCredentials/RecieveSharedCredentials")]
        [HttpPost]
        [ResponseType(typeof(Credential))]
        public IHttpActionResult RecieveRequestedCredentials(List<Credential> requestedCredentials)
        {
            //RequestCredentials.getRequestedCredentials(requestedCredentials);    
            return Ok("Sent credentials");
        }
    }
}
