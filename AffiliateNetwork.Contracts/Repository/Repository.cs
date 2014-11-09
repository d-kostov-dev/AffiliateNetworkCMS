namespace AffiliateNetwork.Contracts.Repository
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using AffiliateNetwork.Models.Base;

    public class Repository<T> : IRepository<T> where T : class, IAuditInfo
    {
        private IDbContext databaseContext;
        private IDbSet<T> entitiesSet;

        public Repository(IDbContext context)
        {
            this.databaseContext = context;
            this.entitiesSet = this.databaseContext.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.entitiesSet.Where(x => x.DeletedOn == null);
        }

        public IQueryable<T> AllWithDeleted()
        {
            return this.entitiesSet;
        }

        public T Find(object id)
        {
            return this.entitiesSet.Find(id);
        }

        public void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
            entity.CreatedOn = DateTime.Now;
        }

        public void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
            entity.ModifiedOn = DateTime.Now;
        }

        public void Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
            entity.DeletedOn = DateTime.Now;
        }

        public void Delete(object id)
        {
            var entity = this.Find(id);
            this.Delete(entity);
        }

        public void TotalDelete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }

        public int SaveChanges()
        {
            return this.databaseContext.SaveChanges();
        }

        private void ChangeState(T entity, EntityState state)
        {
            var entry = this.databaseContext.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.entitiesSet.Attach(entity);
            }

            entry.State = state;
        }
    }
}
