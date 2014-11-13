namespace AffiliateNetwork.Data.Migrations.Seeders
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using AffiliateNetwork.Contracts;
    using AffiliateNetwork.Models;

    public class ConversionsSeeder
    {
        public static void Seed(AffiliateNetworkDbContext databaseContext)
        {
            if (!databaseContext.Conversions.Any())
            {
                for (int i = 1; i <= 10; i++)
                {
                    var currentItem = new Conversion()
                    {
                        Id = i,
                        AffiliateId = databaseContext.Users.FirstOrDefault().Id,
                        CampaignId = databaseContext.Campaigns.FirstOrDefault().Id,
                        CreatedOn = DateTime.Now
                    };

                    databaseContext.Conversions.AddOrUpdate(currentItem);
                }

                databaseContext.SaveChanges();
            }
        }
    }
}
