namespace StockExchange.DAL.Repos.Base
{
    using StockExchange.DAL.DataModel;
    using System.Linq;

    public abstract class BaseRepo<T> : IBaseRepo<T> where T : class, new()
    {
        public readonly DataContext deliveryContext;


        public BaseRepo(DataContext deliveryContext)
        {
            this.deliveryContext = deliveryContext;
        }

        public abstract void Delete(T entity);

        public abstract IQueryable<T> GetAll();


        public abstract void Insert(T entity);
        public virtual void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentException("Update - Entity must not be null");

            deliveryContext.SetModified(entity);
        }

        public void Save()
        {
            try
            {
                this.deliveryContext.SaveChanges();
            }
            catch (Exception ex)
            {
                var newEx = new Exception($"DAL Save - Could not be completed: {ex.Message}.", ex);
                throw newEx;
            }
        }
        //public void Include(T entity, params Expression<Func<T, object>>[] joinedEntities)
        //{
        //    DbEntityEntry<T> entry = (deliveryContext as DataContext).Entry(entity);

        //    foreach (Expression<Func<T, object>> join in joinedEntities)
        //    {
        //        entry.Reference(join).Load();
        //    }
        //}

    }
}