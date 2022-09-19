namespace StockExchange.BLL.Infrastructure.Interfaces
{
    using StockExchange.Domain.Model;
    using StockExchange.Domain.Model.Responses;

    /// <summary>
    /// StockSymbol Service interface.
    /// </summary>
    public interface IStockSymbolService
    {
        //GET

        /// <summary>
        /// It gets a list of all the StockSymbols in the system.
        /// </summary>
        /// <returns>Returns a list of populated StockSymbolModel.</returns>
        ServiceResponse<IEnumerable<StockSymbolModel>> GetAll();

        /// <summary>
        /// It gets a particular StockSymbolModel object available in the system.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a populated StockSymbolModel object.</returns>
        ServiceResponse<StockSymbolModel> GetById(int id);

        /// <summary>
        /// It gets a particular StockSymbolModel object available in the system.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Returns a populated EodPriceModel object.</returns>
        ServiceResponse<StockSymbolModel> GetByName(string name);

        /// <summary>
        /// It gets a list of StockSymbolModel objects available in the system with the property exchangeId set to input.
        /// </summary>
        /// <param name="exchangeId"></param>
        /// <returns>Returns a populated list of StockSymbolModel objects.</returns>
        ServiceResponse<IEnumerable<StockSymbolModel>> GetStockByExchangeId(int exchangeId);

        //PUT

        /// <summary>
        /// Updates a StockSymbolModel object in the database.
        /// </summary>
        /// <param name="stockSymbolModel"></param>
        /// <returns>Returns a populated StockSymbolModel object.</returns>
        ServiceResponse<StockSymbolModel> Update(StockSymbolModel stockSymbolModel);

        // POST

        /// <summary>
        /// Inserts a StockSymbolModel object into the database.
        /// </summary>
        /// <param name="stockSymbolModel"></param>
        /// <returns>Returns a populated StockSymbolModel object.</returns>
        ServiceResponse<StockSymbolModel> Insert(StockSymbolModel stockSymbolModel);
        // DELETE

        /// <summary>
        /// A method for deleting an entity from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a populated StockSymbolModel object matching the deleted entity.</returns>
        ServiceResponse<StockSymbolModel> Delete(int id);
    }
}
