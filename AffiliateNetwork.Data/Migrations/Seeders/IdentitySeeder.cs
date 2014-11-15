namespace AffiliateNetwork.Data.Migrations.Seeders
{
    using System;
    using System.Linq;

    using AffiliateNetwork.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using AffiliateNewtork.Common;

    public class IdentitySeeder
    {
        public static void Seed(AffiliateNetworkDbContext databaseContext)
        {
            if (!databaseContext.Roles.Any(r => r.Name == GlobalConstants.AdminRole))
            {
                var store = new RoleStore<IdentityRole>(databaseContext);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = GlobalConstants.AdminRole };

                manager.Create(role);
            }

            if (!databaseContext.Roles.Any(r => r.Name == GlobalConstants.UserRole))
            {
                var store = new RoleStore<IdentityRole>(databaseContext);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = GlobalConstants.UserRole };

                manager.Create(role);
            }

            if (!databaseContext.Users.Any(u => u.UserName == "admin@abv.bg"))
            {
                var store = new UserStore<User>(databaseContext);
                var manager = new UserManager<User>(store);
                var user = new User { UserName = "admin@abv.bg", Email = "admin@abv.bg", CompanyName = "Affiliate Masters ltd.", CreatedOn = DateTime.Now };

                manager.Create(user, "123456");
                manager.AddToRole(user.Id, GlobalConstants.AdminRole);
            }


            if (!databaseContext.Users.Any(u => u.UserName == "user@abv.bg"))
            {
                var store = new UserStore<User>(databaseContext);
                var manager = new UserManager<User>(store);
                var user = new User { UserName = "user@abv.bg", Email = "user@abv.bg", CompanyName = "User Promotion ltd.", CreatedOn = DateTime.Now };

                manager.Create(user, "123456");
                manager.AddToRole(user.Id, GlobalConstants.UserRole);
            }

            databaseContext.SaveChanges();
        }
    }
}
