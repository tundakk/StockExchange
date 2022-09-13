namespace StockExchange.DAL.Repos.Interface
{
    using StockExchange.DAL.DataModel;
    using StockExchange.DAL.Repos.Base;

    /// <summary>
    /// Interface for repository for StockSymbolsRepo.
    /// </summary>
    public interface IExchangeRepo : IBaseRepo<Exchange>
    {
        //GET

        /// <summary>
        /// Get Exchange object by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a populated Exchange object.</returns>
        Exchange? GetById(int id);

        /// <summary>
        /// Get Exchange object by name property.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Returns a populated Exchange object.</returns>
        Exchange? GetByName(string name);

        //PUT
        //POST
        //DELETE

    }
}
