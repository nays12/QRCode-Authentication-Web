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

		public DbSet<User> Users { get; set; }
		public DbSet<MobileAccount> MobileAccounts { get; set; }
		public DbSet<WebAccount> WebAccounts { get; set; }
		public DbSet<Event> Events { get; set; }
		public DbSet<Credential> Credentials { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			// Users Table
			modelBuilder.Entity<User>().HasKey(u => u.UserId);
			modelBuilder.Entity<User>().HasOptional(u => u.MobileAccount).WithRequired(m => m.Owner);
			modelBuilder.Entity<User>().HasOptional(u => u.WebAccount).WithRequired(w => w.Owner);

			// MobileAccounts Table
			modelBuilder.Entity<MobileAccount>().HasKey(m => m.MobileId);
			modelBuilder.Entity<MobileAccount>().HasMany(m => m.CredentialsOwned).WithRequired(c => c.Owner);

			// WebAccounts Table
			modelBuilder.Entity<WebAccount>().HasKey(w => w.WebId);
			modelBuilder.Entity<WebAccount>().HasMany(w => w.EventsOwned).WithRequired(ev => ev.Owner);

			// Events Table
			modelBuilder.Entity<Event>().HasKey(ev => ev.EventId).Property(ev => ev.EventId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			modelBuilder.Entity<Event>().HasMany(ev => ev.Attendees).WithMany(m => m.EventsAttended);

			// Credentials Table
			modelBuilder.Entity<Credential>().HasKey(c => c.CredentialId).Property(c => c.CredentialId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			modelBuilder.Entity<Credential>().HasRequired(c => c.Issuer).WithMany(w => w.CredentialsIssued).HasForeignKey(c => c.Issuer_FK);
			modelBuilder.Entity<Credential>().HasRequired(c => c.Owner).WithMany(m => m.CredentialsOwned).HasForeignKey(c => c.Owner_FK);

		}
	}
}
