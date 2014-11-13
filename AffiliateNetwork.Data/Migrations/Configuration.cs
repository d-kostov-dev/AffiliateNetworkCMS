namespace AffiliateNetwork.Data.Migrations
{
    using System.Data.Entity.Migrations;

    using AffiliateNetwork.Data.Migrations.Seeders;

    internal sealed class Configuration : DbMigrationsConfiguration<AffiliateNetworkDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AffiliateNetworkDbContext context)
        {
            IdentitySeeder.Seed(context);
            InfoPagesSeeder.Seed(context);
            CategorySeeder.Seed(context);
            CampaignsSeeder.Seed(context);
            SettingsSeeder.Seed(context);
            ClicksSeeder.Seed(context);
            ConversionsSeeder.Seed(context);

            // Just in case i forget .SaveChanges in any of the seeders
            context.SaveChanges();
        }
    }
}
