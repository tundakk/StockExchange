namespace StockExchange.DAL.Repos.Base
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;

    /// <summary>
    /// OBS. THIS MODEL IS NOT IN USE
    /// </summary>
    public abstract class BaseRepo<T> : IBaseRepo<T> where T : class, new()
    {
        public readonly DbContext deliveryContext;

        public BaseRepo(DbContext deliveryContext)
        {
            this.deliveryContext = deliveryContext;
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
