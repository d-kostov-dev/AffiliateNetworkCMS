namespace AffiliateNetwork.Data.Migrations.Seeders
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    using AffiliateNetwork.Common.Enumerations;
    using AffiliateNetwork.Contracts;
    using AffiliateNetwork.Models;

    public class InfoPagesSeeder
    {
        public static void Seed(IDbContext databaseContext)
        {
            var pagesList = new List<InfoPage>()
            {
                new InfoPage()
                {
                    Id = 1,
                    Title = "About Us",
                    Content = @"<p></p>",
                    IsVisible = YesNo.True
                },
                new InfoPage()
                {
                    Id = 2,
                    Title = "FAQ",
                    Content = @"<p></p>",
                    IsVisible = YesNo.True
                },
                new InfoPage()
                {
                    Id = 3,
                    Title = "Contact Us",
                    Content = @"<p></p>",
                    IsVisible = YesNo.True
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
