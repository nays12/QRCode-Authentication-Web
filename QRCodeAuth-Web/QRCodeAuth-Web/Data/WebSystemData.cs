namespace QRCodeAuth_Web.Data
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;
	using QRCodeAuth_Web.Models;

	public partial class WebSystemData : DbContext
	{
		public WebSystemData()
			: base("name=WebSystemData")
		{
		}

		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<Account> Accounts { get; set; }
		public virtual DbSet<Event> Events { get; set; }
		public virtual DbSet<Credential> Credentials { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			// Users Table
			modelBuilder.Entity<User>().HasKey(u => u.UserId);
			modelBuilder.Entity<User>().HasMany(u => u.AccountsOwned);

			// Accounts Table
			modelBuilder.Entity<Account>().HasKey(t => new { t.AccountId, t.AccountType });
			modelBuilder.Entity<Account>().HasMany(a => a.CredentialsOwned);
			modelBuilder.Entity<Account>().HasMany(a => a.EventsOwned);

			// Events Table
			modelBuilder.Entity<Event>().HasKey(t => t.Id).Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			modelBuilder.Entity<Event>().HasMany(ev => ev.Attendees);

			// Credentials Table
			modelBuilder.Entity<Credential>().HasKey(t => t.Id).Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
		}
	}
}
