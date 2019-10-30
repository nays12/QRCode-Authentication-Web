namespace QRCodeAuth_Web.Models
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
	using System.Linq;

	public class WebData : DbContext
	{
		// Your context has been configured to use a 'WebData' connection string from your application's 
		// configuration file (App.config or Web.config). By default, this connection string targets the 
		// 'QRCodeAuth_Web.Models.WebData' database on your LocalDb instance. 
		// 
		// If you wish to target a different database and/or database provider, modify the 'WebData' 
		// connection string in the application configuration file.

		public WebData()
			: base("name=WebData")
		{
		}

		// DbSets
		public DbSet<User> Users { get; set; }
		public DbSet<Account> Accounts { get; set; }
		public DbSet<Event> Events { get; set; }
	}

	public class User
	{
		[Key]
		public int user_id { get; set; }
		public string first_name { get; set; }
		public string last_name { get; set; }
		public string group { get; set; }
		public List<Account> accounts { get; set; }
	}

	public class Account
	{
		[Key]
		public int account_id { get; set; }
		public User owner { get; set; }
		public string type { get; set; }
		public string department_id { get; set; }
		public string department_name { get; set; }
		public bool is_active { get; set; }
		public bool is_credential_authority { get; set; }
		public bool is_attendance_manager { get; set; }
		public bool is_information_collector { get; set; }
		public Event events { get; set; }
	}

	public class Event
	{
		[Key]
		public int event_id { get; set; }
		public Account owner { get; set; }
		public string name { get; set; }
		public string type { get; set; }
		public string details { get; set; }
		public DateTime start_time { get; set; }
		public DateTime end_time { get; set; }
		public string credentials_needed { get; set; }
		public List<Account> attendees { get; set; }
	}
}