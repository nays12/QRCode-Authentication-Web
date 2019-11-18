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
	using System.ComponentModel.DataAnnotations.Schema;
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
		public DbSet<Credential> Credentials { get; set; }


		// Manually mapping Relationships for Entity Framework
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			// Users Table
			modelBuilder.Entity<User>().HasKey(u => u.UserId);
			modelBuilder.Entity<User>().HasMany(u => u.AccountsOwned);

			// Accounts Table
			modelBuilder.Entity<Account>().HasKey(t => new { t.AccountId, t.AccountType });

			modelBuilder.Entity<Account>().HasMany(a => a.CredentialsOwned);

			modelBuilder.Entity<Account>().HasMany(a => a.EventsOwned);

			//modelBuilder.Entity<Account>()
			//	.HasRequired(a => a.AccountOwner)
			//	.WithMany(u => u.AccountsOwned)
			//	.HasForeignKey(u => new { u.AccountId, u.AccountType });

			// Events Table
			modelBuilder.Entity<Event>()
				.HasKey(t => t.Id)
				.Property(t => t.Id)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			modelBuilder.Entity<Event>().HasMany(ev => ev.Attendees);

			//modelBuilder.Entity<Event>()
			//	.HasRequired(ev => ev.EventOwner)
			//	.WithMany(a => a.EventsOwned)
			//	.HasForeignKey(a => new { a.EventOwner_Id, a.EventOwner_Type });

			// Credentials Table
			modelBuilder.Entity<Credential>()
				.HasKey(t => t.Id)
				.Property(t => t.Id)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			//modelBuilder.Entity<Credential>()
			//	.HasRequired(c => c.CredentialOwner)
			//	.WithMany(a => a.CredentialsOwned)
			//	.HasForeignKey(a => new { a.CredentialOwner_Id, a.CredentialOwner_Type });

			//modelBuilder.Entity<Credential>()
			//	.HasRequired(c => c.CredentialIssuer)
			//	.WithMany(a => a.CredentialsOwned)
			//	.HasForeignKey(a => new { a.CredentialIssuer_Id, a.CredentialIssuer_Type });
		}
	}
}