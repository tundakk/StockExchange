namespace StockExchange.BLL.Infrastructure.Services
{
    using AutoMapper;
    using Microsoft.Extensions.Logging;
    using StockExchange.BLL.Infrastructure.Interfaces;
    using StockExchange.DAL.DataModel;
    using StockExchange.DAL.Repos.Interface;
    using StockExchange.Domain.Model;
    using StockExchange.Domain.Model.Responses;
    using System.Collections.Generic;

    public class StockSymbolService : BaseService<StockSymbolService>, IStockSymbolService
    {
        private readonly IStockSymbolsRepo stockSymbolsRepo;
        private readonly IMapper mapper;

        public StockSymbolService(IStockSymbolsRepo stockSymbolsRepo, IMapper mapper, ILogger<StockSymbolService> logger) : base(logger)
        {
            this.stockSymbolsRepo = stockSymbolsRepo;
            this.mapper = mapper;
        }
        // GET
        public ServiceResponse<StockSymbolModel> GetById(int id)
        {
            StockSymbol stockSymbol = stockSymbolsRepo.GetById(id);
            if (stockSymbol == null)
            {
                return new ServiceResponse<StockSymbolModel>()
                {
                    Success = false,
                    Message = "An id wasn't found with that input"
                };

            }
            return new ServiceResponse<StockSymbolModel>()
            {
                Data = mapper.Map<StockSymbolModel>(stockSymbol)
            };
        }
        public ServiceResponse<StockSymbolModel> GetByName(string name)
        {
            StockSymbol stockSymbol = stockSymbolsRepo.GetByName(name);

            if (stockSymbol == null)//should i check on DAL model or domain model?
            {
                return new ServiceResponse<StockSymbolModel>()
                {
                    Success = false,
                    Message = "A Stocksymbol with that name wasn't found"
                };
            }
            return new ServiceResponse<StockSymbolModel>()
            {
                Data = mapper.Map<StockSymbolModel>(stockSymbol)
            };
        }
        public ServiceResponse<List<StockSymbolModel>> GetAllStockSymbols()
        {
            List<StockSymbol> stockSymbols = stockSymbolsRepo.GetAll().ToList();

            if (stockSymbols == null)//should i check on DAL model or domain model?
            {
                return new ServiceResponse<List<StockSymbolModel>>()
                {
                    Success = false,
                    Message = "The object returned from the database was null"
                };
            }
            return new ServiceResponse<List<StockSymbolModel>>()
            {
                Data = mapper.Map<List<StockSymbolModel>>(stockSymbols)
            };

            // ICollection and lists. im doing something wrong i think
        }
        // POST
        public ServiceResponse<StockSymbolModel> InsertStockSymbol(StockSymbolModel stockSymbolModel)
        {
            StockSymbol stockSymbol = mapper.Map<StockSymbol>(stockSymbolModel);

            if (stockSymbol == null)
            {
                return new ServiceResponse<StockSymbolModel>()
                {
                    Success = false,
                    Message = "The stocksymbol could not be created"
                };
            }
            StockSymbol responseStock = stockSymbolsRepo.Insert(stockSymbol);
            stockSymbolsRepo.Save();

            return new ServiceResponse<StockSymbolModel>()
            {
                Data = mapper.Map<StockSymbolModel>(stockSymbol)
            };
        }
        // UPDATE
        public ServiceResponse<StockSymbolModel> UpdateStockSymbol(StockSymbolModel stockSymbolModel)
        {
            StockSymbol stockSymbol = mapper.Map<StockSymbol>(stockSymbolModel);

            if (stockSymbol == null)
            {
                return new ServiceResponse<StockSymbolModel>()
                {
                    Success = false,
                    Message = "The stocksymbol could not be updated"
                };
            }
            StockSymbol responseStock = stockSymbolsRepo.Update(stockSymbol);
            stockSymbolsRepo.Save();
            return new ServiceResponse<StockSymbolModel>()
            {
                Data = mapper.Map<StockSymbolModel>(responseStock)
            };
        }
        // DELETE
        public ServiceResponse<StockSymbolModel> DeleteById(int id)
        {
            StockSymbol stockSymbol = stockSymbolsRepo.GetById(id);
            if (stockSymbol == null)
            {
                return new ServiceResponse<StockSymbolModel>()
                {
                    Success = false,
                    Message = "The stocksymbol could not be deleted"
                };
            }
            StockSymbol responseStock = stockSymbolsRepo.Delete(stockSymbol);
            stockSymbolsRepo.Save();

            return new ServiceResponse<StockSymbolModel>()
            {
                Data = mapper.Map<StockSymbolModel>(responseStock)
            };
        }
        public ServiceResponse<List<StockSymbolModel>> GetStockByExchangeId(int exchangeId)
        {
            List<StockSymbol> stockSymbols = stockSymbolsRepo.GetListOfStockByExchangeId(exchangeId);

            if (stockSymbols == null)
            {
                return new ServiceResponse<List<StockSymbolModel>>()
                {
                    Success = false,
                    Message = $"Could not create a list of StockSymbols with an ExchangeId of: {exchangeId}"
                };
            }
            //return - convert to domain
            return new ServiceResponse<List<StockSymbolModel>>()
            {
                Data = mapper.Map<List<StockSymbolModel>>(stockSymbols)
            };
        }
    }
}
