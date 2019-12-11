/*
 * Purpose: 
 * This is the DatabaseContext class that maps the Model classes to the database tables, defines the relationships 
 * between the database tables, and declares their Primary Keys.
 * 
 * Contributions: 
 * Naomi Wiggins 
 * 
 */

using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using QRCodeAuth_Web.Models;

namespace QRCodeAuth_Web.Data
{
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

			// MobileAccounts Table
			modelBuilder.Entity<MobileAccount>().HasKey(m => m.MobileId);

			// WebAccounts Table
			modelBuilder.Entity<WebAccount>().HasKey(w => w.WebId);

			// Events Table
			modelBuilder.Entity<Event>().HasKey(ev => ev.EventId).Property(ev => ev.EventId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			// Credentials Table
			modelBuilder.Entity<Credential>().HasKey(c => c.CredentialId).Property(c => c.CredentialId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
		}
	}
}
