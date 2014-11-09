namespace AffiliateNetwork.Data.Migrations.Seeders
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using AffiliateNetwork.Contracts;
    using AffiliateNetwork.Models;
    
    public class CategorySeeder
    {
        public static void Seed(IDbContext databaseContext)
        {
            if (!databaseContext.Categories.Any())
            {

                var categoriesNames = new string[]
                {
                    "Sports",
                    "Books",
                    "Financial",
                    "Health",
                    "Gardening",
                    "Toys",
                    "Clothing",
                    "Automotive",
                    "Art",
                    "Internet",
                    "Games",
                    "Phones",
                    "Computers",
                    "Electronics",
                    "Business",
                    "News",
                    "Shopping",
                    "Education",
                    "Food",
                    "Travel",
                };

                for (int i = 1; i <= categoriesNames.Length; i++)
                {
                    var currentCategory = new Category()
                    {
                        Id = i,
                        Name = categoriesNames[i - 1],
                        CreatedOn = DateTime.Now,
                    };

                    databaseContext.Categories.AddOrUpdate(currentCategory);
                }

                databaseContext.SaveChanges();
            }
        }
    }
}
