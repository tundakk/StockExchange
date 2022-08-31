namespace StockExchange.BLL.Infrastructure.Interfaces
{
    using StockExchange.Domain.Model;
    using StockExchange.Domain.Model.Responses;

    public interface IStockSymbolService
    {
        //GET
        List<StockSymbolModel> GetAllStockSymbols();
        StockSymbolModel GetById(int id);
        ServiceResponse<StockSymbolModel> GetByName(string name);
        //PUT
        void UpdateStockSymbol(StockSymbolModel stockSymbolModel);
        // POST
        public void InsertStockSymbol(StockSymbolModel stockSymbolModel);
        // DELETE
        bool DeleteById(int id);

    }
}
