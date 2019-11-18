using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
        public IQueryable<Credential> GetCredentials()
        {
            return db.Credentials;
        }

        // GET: api/Credentials/5
        [ResponseType(typeof(Credential))]
        public IHttpActionResult GetCredential(string id)
        {
            Credential credential = db.Credentials.Find(id);
            if (credential == null)
            {
                return NotFound();
            }

            return Ok(credential);
        }

        // PUT: api/Credentials/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCredential(int id, Credential credential)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != credential.Id)
            {
                return BadRequest();
            }

            db.Entry(credential).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CredentialExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Credentials
        [ResponseType(typeof(Credential))]
        public IHttpActionResult PostCredential(Credential credential)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Credentials.Add(credential);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = credential.Id }, credential);
        }

        // DELETE: api/Credentials/5
        [ResponseType(typeof(Credential))]
        public IHttpActionResult DeleteCredential(int id)
        {
            Credential credential = db.Credentials.Find(id);
            if (credential == null)
            {
                return NotFound();
            }

            db.Credentials.Remove(credential);
            db.SaveChanges();

            return Ok(credential);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CredentialExists(int id)
        {
            return db.Credentials.Count(e => e.Id == id) > 0;
        }
    }
}