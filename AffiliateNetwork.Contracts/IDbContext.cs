namespace AffiliateNetwork.Contracts
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using AffiliateNetwork.Models;

    public interface IDbContext
    {
        IDbSet<InfoPage> InfoPages { get; set; }

        IDbSet<SiteSetting> SiteSettings { get; set; }

        IDbSet<Campaign> Campaigns { get; set; }

        IDbSet<Banner> Banners { get; set; }

        IDbSet<Conversion> Conversions { get; set; }

        IDbSet<Click> Clicks { get; set; }

        IDbSet<Category> Categories { get; set; }

        int SaveChanges();

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
