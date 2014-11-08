namespace AffiliateNetwork.Contracts
{
    using AffiliateNetwork.Models.Base;
    using System.Linq;

    public interface IRepository<T> where T : class, IAuditInfo
    {
        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();

        T Find(object id);

        void Add(T entity);

        void Update(T entity);

        T Delete(T entity);

        T Delete(object id);

        int SaveChanges();
    }
}
