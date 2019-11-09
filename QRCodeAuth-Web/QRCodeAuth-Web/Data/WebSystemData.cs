/*
 * Purpose: Declare a dbcontext for the application
 * 
 * Algorithm: 
 * Construct database context
 * Define DbSets for the tables in the database: Users, Accounts, Events
 * Override OnModelCreating method
 */

namespace QRCodeAuth_Web.Data
{
	using QRCodeAuth_Web.Models;
	using System.Data.Entity;

	public class WebSystemData : DbContext
	{
		public WebSystemData(): base("name=WebSystemData")
		{
			
		}

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