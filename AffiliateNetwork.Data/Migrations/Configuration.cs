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
            InfoPagesSeeder.Seed(context);

            context.SaveChanges();
        }
    }
}
