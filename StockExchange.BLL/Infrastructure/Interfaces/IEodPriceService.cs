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

        /// <summary>
        /// It gets a list of all the Eod prices in the system.
        /// </summary>
        /// <returns>Returns a list of populated EodPriceModel.</returns>
        ServiceResponse<IEnumerable<EodPriceModel>> GetAll();

        /// <summary>
        /// It gets a list of eodprice by id, from a range of dates.
        /// </summary>
        /// <param name="stockId">stocksymbolId.</param>
        /// <param name="from">From a specific date.</param>
        /// <param name="to">To a specific date.</param>
        /// <returns>A list of populated EodPriceModel. </returns>
        ServiceResponse<IEnumerable<EodPriceModel>> GetEodsByStockIdWhereDate(int stockId, DateTime? from, DateTime? to);

        /// <summary>
        /// It gets a particular EodPriceModel object available in the system.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a populated EodPriceModel object.</returns>
        ServiceResponse<EodPriceModel> GetById(int id);

        // Delete

        /// <summary>
        /// A method for deleting an entity from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a populated EodPriceModel object matching the deleted entity.</returns>
        ServiceResponse<EodPriceModel> Delete(int id);

        // POST

        /// <summary>
        /// Inserts a EodPriceModel object into the database.
        /// </summary>
        /// <param name="eodPriceModel"></param>
        /// <returns>Returns a populated EodPriceModel object.</returns>
        ServiceResponse<EodPriceModel> Insert(EodPriceModel eodPriceModel);

        // PUT

        /// <summary>
        /// Updates a EodPriceModel object in the database.
        /// </summary>
        /// <param name="eodPriceModel"></param>
        /// <returns>Returns a populated EodPriceModel object.</returns>
        ServiceResponse<EodPriceModel> Update(EodPriceModel eodPriceModel);
    }
}
