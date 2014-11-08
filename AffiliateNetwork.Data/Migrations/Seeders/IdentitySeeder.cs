namespace AffiliateNetwork.Data.Migrations.Seeders
{
    using System.Linq;

    using AffiliateNetwork.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;

    public class IdentitySeeder
    {
        public static void Seed(AffiliateNetworkDbContext databaseContext)
        {
            if (!databaseContext.Roles.Any(r => r.Name == "Administrator"))
            {
                var store = new RoleStore<IdentityRole>(databaseContext);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Administrator" };

                manager.Create(role);
            }

            if (!databaseContext.Roles.Any(r => r.Name == "Customer"))
            {
                var store = new RoleStore<IdentityRole>(databaseContext);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Customer" };

                manager.Create(role);
            }

            if (!databaseContext.Roles.Any(r => r.Name == "Affiliate"))
            {
                var store = new RoleStore<IdentityRole>(databaseContext);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Affiliate" };

                manager.Create(role);
            }

            if (!databaseContext.Users.Any(u => u.UserName == "admin@abv.bg"))
            {
                var store = new UserStore<User>(databaseContext);
                var manager = new UserManager<User>(store);
                var user = new User { UserName = "admin@abv.bg", Email = "admin@abv.bg", CompanyName = "Affiliate Masters ltd.", CreatedOn = DateTime.Now };

                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "Administrator");
            }

            if (!databaseContext.Users.Any(u => u.UserName == "customer@abv.bg"))
            {
                var store = new UserStore<User>(databaseContext);
                var manager = new UserManager<User>(store);
                var user = new User { UserName = "customer@abv.bg", Email = "customer@abv.bg", CompanyName = "T-Shirt Hell", CreatedOn = DateTime.Now };

                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "Customer");
            }

            if (!databaseContext.Users.Any(u => u.UserName == "user@abv.bg"))
            {
                var store = new UserStore<User>(databaseContext);
                var manager = new UserManager<User>(store);
                var user = new User { UserName = "user@abv.bg", Email = "user@abv.bg", CreatedOn = DateTime.Now };

                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "Affiliate");
            }

            databaseContext.SaveChanges();
        }
    }
}
