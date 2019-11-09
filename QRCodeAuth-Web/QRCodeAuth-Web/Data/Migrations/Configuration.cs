namespace QRCodeAuth_Web.Migrations
{
	using System.Data.Entity.Migrations;

	internal sealed class Configuration : DbMigrationsConfiguration<QRCodeAuth_Web.Data.WebSystemData>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
			AutomaticMigrationDataLossAllowed = true;
		}

        protected override void Seed(QRCodeAuth_Web.Data.WebSystemData context)
        {

        }
    }
}
