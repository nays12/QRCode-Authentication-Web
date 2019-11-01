using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRCodeAuth_Web.Models
{
	public enum CredentialType
	{
		Email,
		Birthdate,
		Address,
		PhoneNumber,
		Major,
		Classification
	}
}