namespace StockExchange.BLL.Infrastructure.Interfaces
{
    using StockExchange.Domain.Model;
    using StockExchange.Domain.Model.Responses;

    public interface IStockSymbolService
    {
        //GET
        ServiceResponse<List<StockSymbolModel>> GetAllStockSymbols();
        ServiceResponse<StockSymbolModel> GetById(int id);
        ServiceResponse<StockSymbolModel> GetByName(string name);
        ServiceResponse<List<StockSymbolModel>> GetStockByExchangeId(int exchangeId);
        //PUT
        ServiceResponse<StockSymbolModel> UpdateStockSymbol(StockSymbolModel stockSymbolModel);
        // POST
        ServiceResponse<StockSymbolModel> InsertStockSymbol(StockSymbolModel stockSymbolModel);
        // DELETE
        ServiceResponse<StockSymbolModel> DeleteById(int id);
    }
}
