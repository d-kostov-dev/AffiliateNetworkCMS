namespace AffiliateNetwork.Data.Migrations.Seeders
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    using AffiliateNetwork.Common.Enumerations;
    using AffiliateNetwork.Contracts;
    using AffiliateNetwork.Models;
    using System;

    public class InfoPagesSeeder
    {
        public static void Seed(IDbContext databaseContext)
        {
            var pagesList = new List<InfoPage>()
            {
                new InfoPage()
                {
                    Id = 1,
                    SeoUrl = "AboutUs",
                    Title = "About Us",
                    Content = @"<p></p>",
                    Order = 1,
                    CreatedOn = DateTime.Now
                },
                new InfoPage()
                {
                    Id = 2,
                    SeoUrl = "FAQ",
                    Title = "FAQ",
                    Content = @"<p></p>",
                    Order = 2,
                    CreatedOn = DateTime.Now
                },
                new InfoPage()
                {
                    Id = 3,
                    SeoUrl = "Contacts",
                    Title = "Contact Us",
                    Content = @"<p></p>",
                    Order = 3,
                    CreatedOn = DateTime.Now
                },
            };

            for (int i = 0; i < pagesList.Count; i++)
            {
                databaseContext.InfoPages.AddOrUpdate(pagesList[i]);
            }

            databaseContext.SaveChanges();
        }
    }
}
