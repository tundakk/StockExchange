namespace StockExchange.BLL.Infrastructure.Interfaces
{
    using StockExchange.Domain.Model;
    using StockExchange.Domain.Model.Responses;

    /// <summary>
    /// EodPrice Service interface.
    /// </summary>
    public interface IEodPriceService
    {
        // GET

        // ServiceResponse<EodPriceModel> GetByDate(DateTime date);

        /// <summary>
        /// It gets a list of all the Eod prices in the system.
        /// </summary>
        /// <returns>a list of populated EodPriceModel.</returns>
        ServiceResponse<IEnumerable<EodPriceModel>> GetAllEodPrices();

        /// <summary>
        /// It gets a list of eodprice by id, from a range of dates.
        /// </summary>
        /// <param name="stockId">stocksymbolId.</param>
        /// <param name="from">From a specific date.</param>
        /// <param name="to">To a specific date.</param>
        /// <returns>A list of populated EodPriceModel. </returns>
        ServiceResponse<IEnumerable<EodPriceModel>> GetEodsByStockIdWhereDate(int stockId, DateTime from, DateTime to);

        /// <summary>
        /// It gets a particular Eod Price available in the system.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A populated EodPriceModel object.</returns>
        ServiceResponse<EodPriceModel> GetById(int id);

        // Delete

        /// <summary>
        /// A method for deleting
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A populated EodPriceModel object matching the deleted entity.</returns>
        ServiceResponse<EodPriceModel> DeleteById(int id);

        // POST
        ServiceResponse<EodPriceModel> InsertEodPrice(EodPriceModel eodPriceModel);

        // PUT
        ServiceResponse<EodPriceModel> UpdateEodPrice(EodPriceModel eodPriceModel);
    }
}