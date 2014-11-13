namespace AffiliateNetwork.Data.Migrations.Seeders
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using AffiliateNetwork.Contracts;
    using AffiliateNetwork.Models;

    public class ClicksSeeder
    {
        public static void Seed(AffiliateNetworkDbContext databaseContext)
        {
            if (!databaseContext.Clicks.Any())
            {
                for (int i = 1; i <= 30; i++)
                {
                    var currentClick = new Click()
                    {
                        Id = i,
                        AffiliateId = databaseContext.Users.FirstOrDefault().Id,
                        CampaignId = databaseContext.Campaigns.FirstOrDefault().Id,
                        CreatedOn = DateTime.Now
                    };

                    databaseContext.Clicks.AddOrUpdate(currentClick);
                }

                databaseContext.SaveChanges();
            }
        }
    }
}
