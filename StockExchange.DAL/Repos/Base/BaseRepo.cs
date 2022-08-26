namespace StockExchange.DAL.Repos.Base
{
    using StockExchange.DAL.DataModel;
    using System.Linq;

    /// <summary>
    /// OBS. THIS MODEL IS NOT IN USE
    /// </summary>
    public abstract class BaseRepo<T> : IBaseRepo<T> where T : class, new()
    {
        public readonly DataContext deliveryContext;
        public BaseRepo()
        {
        }

        public BaseRepo(DataContext deliveryContext)
        {
            this.deliveryContext = deliveryContext;
        }

        public abstract void Delete(T entity);

        public abstract IQueryable<T> GetAll();


        public abstract void Insert(T entity);
        public abstract void Update(T entity);


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

    }
}
