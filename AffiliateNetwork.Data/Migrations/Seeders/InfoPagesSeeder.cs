namespace AffiliateNetwork.Data.Migrations.Seeders
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    using AffiliateNetwork.Contracts;
    using AffiliateNetwork.Models;
    
    public class InfoPagesSeeder
    {
        private const string DefaultContentText = "<strong>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</strong>";

        public static void Seed(IDbContext databaseContext)
        {
            var pagesList = new List<InfoPage>()
            {
                new InfoPage()
                {
                    Id = 1,
                    SeoUrl = "AboutUs",
                    Title = "About Us",
                    Content = DefaultContentText,
                    Order = 1,
                    CreatedOn = DateTime.Now
                },
                new InfoPage()
                {
                    Id = 2,
                    SeoUrl = "FAQ",
                    Title = "FAQ",
                    Content = DefaultContentText,
                    Order = 2,
                    CreatedOn = DateTime.Now
                },
                new InfoPage()
                {
                    Id = 3,
                    SeoUrl = "Contacts",
                    Title = "Contact Us",
                    Content = DefaultContentText,
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
