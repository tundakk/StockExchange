namespace StockExchange.BLL.Infrastructure.Interfaces
{
    using StockExchange.DAL.DataModel;
    using StockExchange.Domain.Model.Responses;

    public interface IStockSymbolService
    {
        StockSymbol GetById(int id);
        ServiceResponse<StockSymbol> GetByName(string name);

    }
}
