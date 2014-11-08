namespace AffiliateNetwork.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using AffiliateNetwork.Contracts;
    using AffiliateNetwork.Data.Migrations;
    using AffiliateNetwork.Models;
    using AffiliateNetwork.Models.Base;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class AffiliateNetworkDbContext : IdentityDbContext<User>, IDbContext
    {
        public AffiliateNetworkDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<AffiliateNetworkDbContext, Configuration>());
        }

        public virtual IDbSet<InfoPage> InfoPages { get; set; }

        public virtual IDbSet<SiteSetting> SiteSettings { get; set; }

        public virtual IDbSet<Campaign> Campaigns { get; set; }

        public virtual IDbSet<Banner> Banners { get; set; }

        public virtual IDbSet<Conversion> Conversions { get; set; }

        public virtual IDbSet<Click> Clicks { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public static AffiliateNetworkDbContext Create()
        {
            return new AffiliateNetworkDbContext();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        //public override int SaveChanges()
        //{
        //    this.ApplyAuditInfoRules();
        //    this.ApplyDeletableEntityRules();
        //    return base.SaveChanges();
        //}

        //private void ApplyAuditInfoRules()
        //{
        //    var allEntries =
        //        this.ChangeTracker
        //        .Entries()
        //        .Where(e => (e.State == EntityState.Added) || (e.State == EntityState.Modified));

        //    foreach (var entry in allEntries)
        //    {
        //        var entity = (IAuditInfo)entry.Entity;

        //        if (entry.State == EntityState.Added)
        //        {
        //            if (!entity.PreserveCreatedOn)
        //            {
        //                entity.CreatedOn = DateTime.Now;
        //            }
        //        }
        //        else
        //        {
        //            entity.ModifiedOn = DateTime.Now;

        //            // If deleted item is edited it is UnDeleted again
        //            entity.DeletedOn = null;
        //        }
        //    }
        //}

        //private void ApplyDeletableEntityRules()
        //{
        //    var allEntries = this.ChangeTracker
        //        .Entries()
        //        .Where(e => e.State == EntityState.Deleted);

        //    foreach (var entry in allEntries)
        //    {
        //        var entity = (IAuditInfo)entry.Entity;

        //        entity.DeletedOn = DateTime.Now;
        //        entry.State = EntityState.Modified;
        //    }
        //}
    }
}
