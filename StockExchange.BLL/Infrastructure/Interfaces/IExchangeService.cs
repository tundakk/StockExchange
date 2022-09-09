namespace StockExchange.BLL.Infrastructure.Interfaces
{
    using StockExchange.Domain.Model;
    using StockExchange.Domain.Model.Responses;
    using System.Collections.Generic;

    public interface IExchangeService
    {
        //GET
        ServiceResponse<ExchangeModel> GetByName(string name);
        ServiceResponse<List<ExchangeModel>> GetAllExchanges();
        ServiceResponse<ExchangeModel> GetExchangeById(int id);
        //PUT
        ServiceResponse<ExchangeModel> UpdateExchange(ExchangeModel exchangeModel);

        //POST
        ServiceResponse<ExchangeModel> InsertExchange(ExchangeModel exchangeModel);

        //DELETE
        ServiceResponse<ExchangeModel> DeleteById(int id);
    }
}
