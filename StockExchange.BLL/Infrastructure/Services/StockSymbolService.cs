namespace StockExchange.BLL.Infrastructure.Services
{
    using StockExchange.BLL.Infrastructure.Interfaces;
    using StockExchange.DAL.DataModel;
    using StockExchange.DAL.Repos.Interface;
    using StockExchange.Domain.Model.Responses;

    public class StockSymbolService : IStockSymbolService
    {
        private readonly IStockSymbolsRepo stockSymbolsRepo;
        public StockSymbolService(IStockSymbolsRepo stockSymbolsRepo)
        {
            this.stockSymbolsRepo = stockSymbolsRepo;
        }
        public bool Delete(int id)
        {
            StockSymbol stockSymbol = stockSymbolsRepo.GetById(id);
            if (stockSymbol == null)
                return false;

            stockSymbolsRepo.Delete(stockSymbol);
            stockSymbolsRepo.Save();
            return true;
        }
        public StockSymbol GetById(int id)
        {
            StockSymbol response = stockSymbolsRepo.GetById(id);

            return response;
        }
        public ServiceResponse<StockSymbol> GetByName(string name)
        {
            var response = new ServiceResponse<StockSymbol>();
            StockSymbol stocksymbol = stockSymbolsRepo.GetByName(name);
            if (stocksymbol == null)
            {
                response.Success = false;
                response.Message = "A Stocksymbol with that name wasn't found";
            }
            else
                response.Data = stocksymbol;

            return response;
        }
    }
}
