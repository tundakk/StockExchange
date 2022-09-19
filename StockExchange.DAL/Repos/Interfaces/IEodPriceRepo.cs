namespace StockExchange.DAL.Repos.Interface
{
    using StockExchange.DAL.DataModel;
    using StockExchange.DAL.Repos.Base;

    /// <summary>
    /// Interface for repository for EodPriceRepo.
    /// </summary>
    public interface IEodPriceRepo : IBaseRepo<EodPrice>
    {
        // GET

        /// <summary>
        /// Get Eod Price object by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a populated eodprice object.</returns>
        EodPrice GetById(int id);

        /// <summary>
        /// Get a list of Eod Price objects by stockSymbolId and a range of dates.
        /// </summary>
        /// <param name="stockId"></param>
        /// <param name="from">The start date.</param>
        /// <param name="to">The end date.</param>
        /// <returns>Returns a list of EodPrice by stockSymbolId where datetime from to datetime to.</returns>
        IEnumerable<EodPrice> GetByStockIdAndDate(int stockId, DateTime? from, DateTime? to);
        // EodPrice GetByDate(DateTime date);

        // get by date EodPrice GetByDate(string date);

        // PUT
        // POST
        // DELETE
    }
}
