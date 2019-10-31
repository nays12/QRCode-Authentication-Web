namespace QRCodeAuth_Web.Models.Data
{
    using QRCodeAuth_Web.Models.Logic;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
	using System.Linq;

	public class WebSystemData : DbContext
	{
		// Your context has been configured to use a 'WebSystemData' connection string from your application's 
		// configuration file (App.config or Web.config). By default, this connection string targets the 
		// 'QRCodeAuth_Web.Models.Data.WebSystemData' database on your LocalDb instance. 
		// 
		// If you wish to target a different database and/or database provider, modify the 'WebSystemData' 
		// connection string in the application configuration file.
		public WebSystemData()
			: base("name=WebSystemData")
		{
		}

		// Add a DbSet for each entity type that you want to include in your model. For more information 
		// on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

		// DbSets
		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<Account> Accounts { get; set; }
		public virtual DbSet<Event> Events { get; set; }

	}

	public class Account
	{
		[Key]
		public string id { get; set; }
		public virtual User owner { get; set; }
		public string type { get; set; }
		public string department_id { get; set; }
		public string department_name { get; set; }
		public bool is_active { get; set; }
		public bool is_credential_authority { get; set; }
		public bool is_attendance_manager { get; set; }
		public bool is_information_collector { get; set; }
		public virtual List<Event> events { get; set; }
	}
	public class Event
	{
		[Key]
		public string id { get; set; }
		public virtual Account owner { get; set; }
		public string name { get; set; }
		public EventType type { get; set; }
		public string description { get; set; }
		public DateTime start_time { get; set; }
		public DateTime end_time { get; set; }
		public string credentials_required { get; set; }
		public virtual List<Account> attendees { get; set; }
	}
	public class User
	{
		[Key]
		public int id { get; set; }
		public string school_id { get; set; }
		public string last_name { get; set; }
		public string first_name { get; set; }
		public UserType group { get; set; }
		public virtual List<Account> accounts { get; set; }

	}

}