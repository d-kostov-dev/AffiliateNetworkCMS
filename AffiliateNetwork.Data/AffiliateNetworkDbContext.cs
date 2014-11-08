namespace AffiliateNetwork.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
