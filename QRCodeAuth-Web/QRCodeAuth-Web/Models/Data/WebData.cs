namespace QRCodeAuth_Web.Models.Data
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
		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<Account> Accounts { get; set; }
		public virtual DbSet<Event> Events { get; set; }
	}

	public class Account
	{
		[Key]
		public string ID { get; set; }
		public virtual User Owner { get; set; }
		public string Type { get; set; }
		public string DepartmentID { get; set; }
		public string DepartmentName { get; set; }
		public bool IsActive { get; set; }
		public bool IsCredentialAuthority { get; set; }
		public bool IsAttendanceManager { get; set; }
		public bool IsInformationCollector { get; set; }
		public virtual List<Event> events { get; set; }

	}

}