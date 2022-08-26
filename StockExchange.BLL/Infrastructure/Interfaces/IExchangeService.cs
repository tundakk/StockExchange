namespace StockExchange.BLL.Infrastructure.Interfaces
{
    using StockExchange.DAL.DataModel;
    using System.Collections.Generic;

    public interface IExchangeService
    {
        //GET
        List<StockSymbol> GetAllExchanges();
        //PUT
        //POST
        //Exchange CreateExchange(Exchange exchange);
        //DELETE
    }
}
