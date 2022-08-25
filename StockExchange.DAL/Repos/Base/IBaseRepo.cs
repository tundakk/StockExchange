namespace StockExchange.DAL.Repos.Base
{

    /// <summary>
    /// Try to implement the implemented class BaseRepo and the interface generic type T
    /// </summary>
    public interface IBaseRepo<T> where T : class
    {
        IQueryable<T> GetAll();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
        //void GetAll();
        //void Insert();
        //void Update();
        //void Delete();
        //void Save();
    }
}
