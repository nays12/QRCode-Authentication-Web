/*
 * Purpose: 
 * This API Contoller is responsible for defining and performing the GET and POST request necessary to
 * recieve and send Credential objects between the Web and Mobile Applications
 * 
 * Contributions: 
 * Marilin Ortuno -> RecievedSharedCredentials()
 * 
 * Naomi Wiggins -> RecieveEventCredentials(), GetAllCredentials(), GetIssuedCredentials(), GetUpdatedCredentials()
 * GetCredentialIDtoDelete()
 * 
 */

using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using QRCodeAuth_Web.Data;
using QRCodeAuth_Web.Models;

namespace QRCodeAuth_Web.Controllers
{
    public class CredentialsController : ApiController
    {
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

		[Route("api/Credentials/RecieveSharedCredentials")]
		[HttpPost]
		public IHttpActionResult RecieveRequestedCredentials(List<Credential> requestedCredentials)
		{
			RequestCredentials.GetNewCredentials(requestedCredentials);
			return Ok("Recieved sent credentials");
		}

	}
}