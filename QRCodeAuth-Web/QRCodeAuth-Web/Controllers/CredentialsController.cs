using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using QRCodeAuth_Web.Data;
using QRCodeAuth_Web.Models;

namespace QRCodeAuth_Web.Controllers
{
    public class CredentialsController : ApiController
    {
        private WebSystemData db = new WebSystemData();

		[Route("api/Credentials/RecieveEventCredentials")]
		[HttpPost]
		public IHttpActionResult RecieveAccountId(List<Credential> credentials)
		{
			ManageEvent.GetNewCredentials(credentials);
			return Ok("Your credentials have been recieved!");
		}

		[Route("api/Credentials/GetAllCredentials")]
		[HttpGet]
		[ResponseType(typeof(Credential))]
		public List<Credential> GetAllCredentials(string id)
		{
			return CredentialsRepo.GetOwnerCredentials(id);
		}

		[Route("api/Credentials/GetIssuedCredentials")]
		[HttpGet]
		[ResponseType(typeof(Credential))]
		public List<Credential> GetIssuedCredentials()
		{
			return CreateCredential.getIssuedCredentials();
		}

		[Route("api/Credentials/GetUpdatedCredentials")]
		[HttpGet]
		[ResponseType(typeof(Credential))]
		public List<Credential> GetUpdatedCredentials()
		{
			return UpdateCredential.getUpdatedCredentials();
		}

		[Route("api/Credentials/GetCredentialIdToDelete")]
		[HttpGet]
		[ResponseType(typeof(int))]
		public int GetCredentialIdToDelete()
		{
			return UpdateCredential.GetCredentialIdToDelete();
		}

		// GET: api/Credentials/5
		[ResponseType(typeof(Credential))]
		public async Task<IHttpActionResult> GetCredential(int id)
		{
			Credential credential = await db.Credentials.FindAsync(id);
			if (credential == null)
			{
				return NotFound();
			}

			return Ok(credential);
		}

		//// PUT: api/Credentials/5
		//[ResponseType(typeof(void))]
		//public async Task<IHttpActionResult> PutCredential(int id, Credential credential)
		//{
		//	if (!ModelState.IsValid)
		//	{
		//		return BadRequest(ModelState);
		//	}

		//	if (id != credential.CredentialId)
		//	{
		//		return BadRequest();
		//	}

		//	db.Entry(credential).State = EntityState.Modified;

		//	try
		//	{
		//		await db.SaveChangesAsync();
		//	}
		//	catch (DbUpdateConcurrencyException)
		//	{
		//		if (!CredentialExists(id))
		//		{
		//			return NotFound();
		//		}
		//		else
		//		{
		//			throw;
		//		}
		//	}

		//	return StatusCode(HttpStatusCode.NoContent);
		//}

		// POST: api/Credentials
		[ResponseType(typeof(Credential))]
		public async Task<IHttpActionResult> PostCredential(Credential credential)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			db.Credentials.Add(credential);
			await db.SaveChangesAsync();

			return CreatedAtRoute("DefaultApi", new { id = credential.CredentialId }, credential);
		}

		// DELETE: api/Credentials/5
		[ResponseType(typeof(Credential))]
		public async Task<IHttpActionResult> DeleteCredential(int id)
		{
			Credential credential = await db.Credentials.FindAsync(id);
			if (credential == null)
			{
				return NotFound();
			}

			db.Credentials.Remove(credential);
			await db.SaveChangesAsync();

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
			return db.Credentials.Count(e => e.CredentialId == id) > 0;
		}
	}
}