namespace QRCodeAuth_Web.Data
{
    using QRCodeAuth_Web.Models;
    using System;
    using System.Collections.Generic;
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
		public DbSet<User> Users { get; set; }
		public DbSet<Account> Accounts { get; set; }
		public DbSet<Event> Events { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			// Manually mapping Primary Keys for Entity Framework
			modelBuilder.Entity<User>().HasKey(t => t.UserId);

			modelBuilder.Entity<Event>().HasKey(t => new { t.Name, t.StartTime });

			modelBuilder.Entity<Account>().HasKey(t => new { t.AccountId, t.Type });

		}

	}

}