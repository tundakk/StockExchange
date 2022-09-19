namespace StockExchange.DAL.Repos.Base
{
    using System.Linq;
    using StockExchange.DAL.DataModel;

    /// <summary>
    /// The base repository class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseRepo<T> : IBaseRepo<T> where T : class, new()
    {
        /// <summary>
        /// Public readonly property used as DI for classes.
        /// </summary>
        public readonly DataContext DataContext;

        /// <summary>
        /// default constructor for the BaseRepo class.
        /// </summary>
        /// <param name="dataContext"></param>
        public BaseRepo(DataContext dataContext)
        {
            this.DataContext = dataContext;
        }

        /// <summary>
        /// The abstract Delete method.
        /// </summary>
        /// <param name="entity"></param>
        public abstract T Delete(T entity);

        /// <summary>
        /// The abstract GetAll method.
        /// </summary>
        public abstract IQueryable<T> GetAll();

        /// <summary>
        /// The abstract Insert method.
        /// </summary>
        public abstract T Insert(T entity);

        /// <summary>
        /// The abstract Update method.
        /// </summary>
        public virtual T Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Update - Entity must not be null");
            }

            DataContext.SetModified(entity);
            return entity;
        }

        /// <summary>
        /// The default Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                this.DataContext.SaveChanges();
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
