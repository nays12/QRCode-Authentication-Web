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
}