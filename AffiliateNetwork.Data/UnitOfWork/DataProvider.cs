namespace AffiliateNetwork.Data.UnitOfWork
{   
    using System;
    using System.Collections.Generic;

    using AffiliateNetwork.Contracts;
    using AffiliateNetwork.Data.Repository;
    using AffiliateNetwork.Models;

    public class DataProvider : IDataProvider
    {
        private IDbContext databaseContext;
        private IDictionary<Type, object> createdRepositories;

        public DataProvider(IDbContext context)
        {
            this.databaseContext = context;
            this.createdRepositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<InfoPage> InfoPages
        {
            get { return this.GetRepository<InfoPage>(); }
        }

        public IRepository<SiteSetting> SiteSettings
        {
            get { return this.GetRepository<SiteSetting>(); }
        }

        public IRepository<Campaign> Campaigns
        {
            get { return this.GetRepository<Campaign>(); }
        }

        public IRepository<Banner> Banners
        {
            get { return this.GetRepository<Banner>(); }
        }

        public IRepository<Conversion> Conversions
        {
            get { return this.GetRepository<Conversion>(); }
        }

        public IRepository<Click> Clicks
        {
            get { return this.GetRepository<Click>(); }
        }

        public int SaveChanges()
        {
            return this.databaseContext.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);

            if (!this.createdRepositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(Repository<T>), this.databaseContext);
                this.createdRepositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.createdRepositories[typeOfRepository];
        }
    }
}
