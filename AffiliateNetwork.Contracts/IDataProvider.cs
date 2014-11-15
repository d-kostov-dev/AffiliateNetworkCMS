namespace AffiliateNetwork.Contracts
{
    using AffiliateNetwork.Models;

    public interface IDataProvider
    {
        IRepository<User> Users { get; }

        IRepository<InfoPage> InfoPages { get; }

        IRepository<SiteSetting> SiteSettings { get; }

        IRepository<Campaign> Campaigns { get; }

        IRepository<Banner> Banners { get; }

        IRepository<Conversion> Conversions { get; }

        IRepository<Click> Clicks { get; }

        IRepository<Category> Categories { get; }

        IRepository<ProfilePhoto> ProfilePhotos { get; }

        int SaveChanges();
    }
}
