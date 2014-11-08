﻿namespace AffiliateNetwork.Contracts
{
    using System.Linq;

    using AffiliateNetwork.Models.Base;
    
    public interface IRepository<T> where T : class, IAuditInfo
    {
        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();

        T Find(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(object id);

        int SaveChanges();
    }
}
