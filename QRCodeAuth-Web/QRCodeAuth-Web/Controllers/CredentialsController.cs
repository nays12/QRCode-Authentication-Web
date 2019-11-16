using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using QRCodeAuth_Web.Data;
using QRCodeAuth_Web.Models;

namespace QRCodeAuth_Web.Controllers
{
    public class CredentialsController : ApiController
    {

        private WebSystemData db = new WebSystemData();

        // GET: api/Credentials
        [Route("api/Credentials")]
        [HttpGet]
        public string GetCredentials()
        {
            //return db.Credentials;
            return "Returns all credentials";
        }

        // GET: api/Credentials/5
        [ResponseType(typeof(Credential))]
        public IHttpActionResult GetCredential(int id)
        {
            Credential @Credential = db.Credentials.Find(id);
            if (@Credential == null)
            {
                return NotFound();
            }

            return Ok(@Credential);
        }




    }
}
