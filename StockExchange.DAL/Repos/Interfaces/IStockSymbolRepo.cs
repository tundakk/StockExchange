namespace StockExchange.DAL.Repos.Interface
{
    using StockExchange.DAL.DataModel;
    using StockExchange.DAL.Repos.Base;

    /// <summary>
    /// Interface for repository for StockSymbolsRepo.
    /// </summary>
    public interface IStockSymbolRepo : IBaseRepo<StockSymbol>
    {
        //GET

        /// <summary>
        /// Get StockSymbol object by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a populated StockSymbol object.</returns>
        StockSymbol? GetById(int id);

        /// <summary>
        /// Get StockSymbol object by name property.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Returns a populated StockSymbol object.</returns>
        StockSymbol? GetByName(string name);

        /// <summary>
        /// Get StockSymbol object by name property.
        /// </summary>
        /// <param name="exchangeId"></param>
        /// <returns>Returns a populated List of stocksymbol objects.</returns>
        IEnumerable<StockSymbol> GetListOfStockByExchangeId(int exchangeId);

        //PUT
        //POST
        //DELETE
    }
}
