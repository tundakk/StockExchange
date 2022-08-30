namespace StockExchange.BLL.Infrastructure.Interfaces
{
    using StockExchange.DAL.DataModel;
    using StockExchange.Domain.Model.Responses;
    using System.Collections.Generic;

    public interface IExchangeService
    {
        //GET
        ServiceResponse<Exchange> GetByName(string name);
        List<Exchange> GetAllExchanges();
        Exchange GetById(int id);
        //PUT
        //POST
        //Exchange CreateExchange(Exchange exchange);
        //DELETE
        bool Delete(int id);
    }
}
