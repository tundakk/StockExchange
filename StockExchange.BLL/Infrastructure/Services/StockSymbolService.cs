namespace StockExchange.BLL.Infrastructure.Services
{
    using StockExchange.BLL.Conversions;
    using StockExchange.BLL.Infrastructure.Interfaces;
    using StockExchange.DAL.DataModel;
    using StockExchange.DAL.Repos.Interface;
    using StockExchange.Domain.Model;
    using StockExchange.Domain.Model.Responses;
    using System.Collections.Generic;

    public class StockSymbolService : IStockSymbolService
    {
        private readonly IStockSymbolsRepo stockSymbolsRepo;
        public StockSymbolService(IStockSymbolsRepo stockSymbolsRepo)
        {
            this.stockSymbolsRepo = stockSymbolsRepo;
        }

        // GET
        public StockSymbolModel GetById(int id)
        {
            StockSymbol stockSymbol = stockSymbolsRepo.GetById(id);
            StockSymbolModel responseModel = StockSymbolConvert.DalToDomainStockSymbol(stockSymbol);

            return responseModel;
        }
        public ServiceResponse<StockSymbolModel> GetByName(string name)
        {
            StockSymbol stocksymbol = stockSymbolsRepo.GetByName(name);

            if (stocksymbol == null)//should i check on DAL model or domain model?
            {
                return new ServiceResponse<StockSymbolModel>()
                {
                    Success = false,
                    Message = "A Stocksymbol with that name wasn't found"
                };

            }

            return new ServiceResponse<StockSymbolModel>()
            {
                Data = StockSymbolConvert.DalToDomainStockSymbol(stocksymbol)
            };
        }
        public List<StockSymbolModel> GetAllStockSymbols()
        {

            List<StockSymbol> stockSymbol = stockSymbolsRepo.GetAll().ToList();

            //conversion from DAL model to DOMAIN model
            ICollection<StockSymbolModel> responseModel = StockSymbolConvert.DalToDomainListOfStock(stockSymbol);

            return responseModel.ToList(); // ICollection and lists. im doing something wrong  ithink


        }
        // POST
        public void InsertStockSymbol(StockSymbolModel stockSymbolModel) //should this return a bool?
        {
            StockSymbol stockSymbol = StockSymbolConvert.DomainToDalStockSymbol(stockSymbolModel);

            stockSymbolsRepo.Insert(stockSymbol);
        }
        // UPDATE
        public void UpdateStockSymbol(StockSymbolModel stockSymbolModel)
        {
            StockSymbol stockSymbol = StockSymbolConvert.DomainToDalStockSymbol(stockSymbolModel);

            stockSymbolsRepo.Update(stockSymbol);
        }
        // DELETE
        public bool DeleteById(int id)
        {
            StockSymbol stockSymbol = stockSymbolsRepo.GetById(id);
            if (stockSymbol == null)
                return false;

            stockSymbolsRepo.Delete(stockSymbol);
            stockSymbolsRepo.Save();
            return true;
        }


    }
}
