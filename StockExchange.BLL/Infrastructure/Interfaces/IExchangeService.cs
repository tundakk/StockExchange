namespace StockExchange.BLL.Infrastructure.Interfaces
{
    using StockExchange.Domain.Model;
    using StockExchange.Domain.Model.Responses;
    using System.Collections.Generic;

    public interface IExchangeService
    {
        //GET
        ServiceResponse<ExchangeModel> GetByName(string name);
        List<ExchangeModel> GetAllExchanges();
        ExchangeModel GetById(int id);
        //PUT
        void UpdateExchange(ExchangeModel exchangeModel);

        //POST
        public void InsertExchange(ExchangeModel exchangeModel);

        //DELETE
        bool DeleteById(int id);
    }
}
