namespace AffiliateNetwork.Data.Migrations.Seeders
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using AffiliateNetwork.Contracts;
    using AffiliateNetwork.Models;

    public class SettingsSeeder
    {
        public static void Seed(IDbContext databaseContext)
        {
            if (!databaseContext.SiteSettings.Any())
            {
                var pagesList = new List<SiteSetting>()
                {
                    new SiteSetting()
                    {
                       Name = "ItemsPerPage",
                       Value = "10",
                       Description = "Items to show per page in the gird controls."
                    },
                };

                for (int i = 0; i < pagesList.Count; i++)
                {
                    var currentItem = pagesList[i];
                    currentItem.Id = i + 1;
                    currentItem.CreatedOn = DateTime.Now;

                    databaseContext.SiteSettings.AddOrUpdate(currentItem);
                }

                databaseContext.SaveChanges();
            }
        }
    }
}
