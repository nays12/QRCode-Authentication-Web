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
		public virtual DbSet<MobileAccount> MobileAccounts { get; set; }

		public virtual DbSet<WebAccount> WebAccounts { get; set; }
		public virtual DbSet<Event> Events { get; set; }
		public virtual DbSet<Credential> Credentials { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			// Users Table
			modelBuilder.Entity<User>().HasKey(u => u.UserId);
			modelBuilder.Entity<User>().HasOptional(u => u.MobileTokenAccount);
			modelBuilder.Entity<User>().HasOptional(u => u.WebAccount);

			// MobileAccounts Table
			modelBuilder.Entity<MobileAccount>().HasKey(m => m.AccountId);
			modelBuilder.Entity<MobileAccount>().HasRequired(m => m.Owner);

			// WebAccounts Table
			modelBuilder.Entity<WebAccount>().HasKey(w => w.AccountId);
			modelBuilder.Entity<WebAccount>().HasRequired(w => w.Owner);

			// Events Table
			modelBuilder.Entity<Event>().HasKey(ev => ev.Id).Property(ev => ev.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			modelBuilder.Entity<Event>().HasRequired(ev => ev.Owner);
			modelBuilder.Entity<Event>().HasMany(ev => ev.Attendees);

			// Credentials Table
			modelBuilder.Entity<Credential>().HasKey(t => t.Id).Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			modelBuilder.Entity<Credential>().HasRequired(c => c.Owner);
		}
	}
}
