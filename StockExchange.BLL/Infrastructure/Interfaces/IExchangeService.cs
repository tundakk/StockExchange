namespace StockExchange.BLL.Infrastructure.Interfaces
{
    using System.Collections.Generic;
    using StockExchange.Domain.Model;
    using StockExchange.Domain.Model.Responses;

    /// <summary>
    /// Exchange Service interface.
    /// </summary>
    public interface IExchangeService
    {
        //GET

        /// <summary>
        /// It gets a particular Eod Price available in the system.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Returns a populated EodPriceModel object.</returns>
        ServiceResponse<ExchangeModel> GetByName(string name);

        /// <summary>
        /// It gets a list of all the Exchanges in the system.
        /// </summary>
        /// <returns>Returns a list of populated ExchangeModel.</returns>
        ServiceResponse<IEnumerable<ExchangeModel>> GetAllExchanges();

        /// <summary>
        /// It gets a particular ExchangeModel object available in the system.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a populated ExchangeModel object.</returns>
        ServiceResponse<ExchangeModel> GetById(int id);

        //PUT

        /// <summary>
        /// Updates a ExchangeModel object in the database.
        /// </summary>
        /// <param name="exchangeModel"></param>
        /// <returns>Returns a populated ExchangeModel object.</returns>
        ServiceResponse<ExchangeModel> UpdateExchange(ExchangeModel exchangeModel);

        //POST

        /// <summary>
        /// Inserts a ExchangeModel object into the database.
        /// </summary>
        /// <param name="exchangeModel"></param>
        /// <returns>Returns a populated ExchangeModel.</returns>
        ServiceResponse<ExchangeModel> InsertExchange(ExchangeModel exchangeModel);

        //DELETE

        /// <summary>
        /// A method for deleting an entity from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a populated ExchangeModel object matching the deleted entity.</returns>
        ServiceResponse<ExchangeModel> DeleteById(int id);
    }
}
