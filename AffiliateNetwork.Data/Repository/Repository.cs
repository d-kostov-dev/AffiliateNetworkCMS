namespace AffiliateNetwork.Data.Repository
{
    using System.Data.Entity;
    using System.Linq;

    using AffiliateNetwork.Contracts;

    public class Repository<T> : IRepository<T> where T : class
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
            return this.entitiesSet;
        }

        public T Find(object id)
        {
            return this.entitiesSet.Find(id);
        }

        public void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public T Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
            return entity;
        }

        public T Delete(object id)
        {
            var entity = this.Find(id);
            this.Delete(entity);
            return entity;
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
