namespace StockExchange.BLL.Infrastructure.Services
{
    using System.Collections.Generic;
    using AutoMapper;
    using Microsoft.Extensions.Logging;
    using StockExchange.BLL.Infrastructure.Interfaces;
    using StockExchange.DAL.DataModel;
    using StockExchange.DAL.Repos.Interface;
    using StockExchange.Domain.Model;
    using StockExchange.Domain.Model.Responses;

    /// <summary>
    /// StockSymbol Service.
    /// </summary>
    public class StockSymbolService : BaseService<StockSymbolService>, IStockSymbolService
    {
        private readonly IStockSymbolsRepo stockSymbolsRepo;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="StockSymbolService"/> class.
        /// </summary>
        /// <param name="stockSymbolsRepo"></param>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        public StockSymbolService(IStockSymbolsRepo stockSymbolsRepo, IMapper mapper, ILogger<StockSymbolService> logger) : base(logger)
        {
            this.stockSymbolsRepo = stockSymbolsRepo;
            this.mapper = mapper;
        }

        // GET

        /// <summary>
        /// It gets a particular stocksymbol available in the system.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A populated StockSymbolModel object.</returns>
        public ServiceResponse<StockSymbolModel> GetById(int id)
        {
            if (id <= 0)
            {
                return new ServiceResponse<StockSymbolModel>()
                {
                    Success = false,
                    Message = "The id cannot be 0 or less",
                };
            }

            StockSymbol? stockSymbol = stockSymbolsRepo.GetById(id);

            if (stockSymbol == null)
            {
                return new ServiceResponse<StockSymbolModel>()
                {
                    Success = false,
                    Message = "An id wasn't found with that input",
                };
            }

            return new ServiceResponse<StockSymbolModel>()
            {
                Data = mapper.Map<StockSymbolModel>(stockSymbol),
            };
        }

        /// <summary>
        /// It gets a particular StockSymbolModel by name property.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>returns a populated StockSymbolModel object.</returns>
        public ServiceResponse<StockSymbolModel> GetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return new ServiceResponse<StockSymbolModel>()
                {
                    Success = false,
                    Message = "string name cannot be null or empty",
                };
            }

            StockSymbol? stockSymbol = stockSymbolsRepo.GetByName(name);

            if (stockSymbol == null)
            {
                return new ServiceResponse<StockSymbolModel>()
                {
                    Success = false,
                    Message = "A Stocksymbol with that name wasn't found",
                };
            }

            return new ServiceResponse<StockSymbolModel>()
            {
                Data = mapper.Map<StockSymbolModel>(stockSymbol),
            };
        }

        /// <summary>
        /// It gets a IEnumerable of all the StockSymbolModel in the system.
        /// </summary>
        /// <returns> Returns an IEnumerable of populated StockSymbolModel.</returns>
        public ServiceResponse<IEnumerable<StockSymbolModel>> GetAllStockSymbols()
        {
            IEnumerable<StockSymbol> stockSymbols = stockSymbolsRepo.GetAll();

            if (stockSymbols == null)
            {
                return new ServiceResponse<IEnumerable<StockSymbolModel>>()
                {
                    Success = false,
                    Message = "The list returned from the database was null",
                };
            }

            return new ServiceResponse<IEnumerable<StockSymbolModel>>()
            {
                Data = mapper.Map<IEnumerable<StockSymbolModel>>(stockSymbols),
            };

            // ICollection and lists. im doing something wrong i think
        }

        // POST

        /// <summary>
        /// It inserts a particular StockSymbolModel object.
        /// </summary>
        /// <param name="stockSymbolModel"></param>
        /// <returns>returns a populated StockSymbolModel object.</returns>
        public ServiceResponse<StockSymbolModel> InsertStockSymbol(StockSymbolModel stockSymbolModel)
        {
            if (stockSymbolModel == null)
            {
                return new ServiceResponse<StockSymbolModel>()
                {
                    Success = false,
                    Message = "The stockSymbolModel input cannot be null",
                };
            }

            StockSymbol stockSymbol = mapper.Map<StockSymbol>(stockSymbolModel);

            if (stockSymbol == null)
            {
                return new ServiceResponse<StockSymbolModel>()
                {
                    Success = false,
                    Message = "The stocksymbol could not be created",
                };
            }

            StockSymbol responseStock = stockSymbolsRepo.Insert(stockSymbol);

            stockSymbolsRepo.Save();

            return new ServiceResponse<StockSymbolModel>()
            {
                Data = mapper.Map<StockSymbolModel>(responseStock),
            };
        }

        // UPDATE

        /// <summary>
        /// It updates a particular StockSymbolModel object.
        /// </summary>
        /// <param name="stockSymbolModel"></param>
        /// <returns>Returns the updated StockSymbolModel object.</returns>
        public ServiceResponse<StockSymbolModel> UpdateStockSymbol(StockSymbolModel stockSymbolModel)
        {
            if (stockSymbolModel == null)
            {
                return new ServiceResponse<StockSymbolModel>()
                {
                    Success = false,
                    Message = "The stockSymbolModel input cannot be null",
                };
            }

            StockSymbol stockSymbol = mapper.Map<StockSymbol>(stockSymbolModel);

            if (stockSymbol == null)
            {
                return new ServiceResponse<StockSymbolModel>()
                {
                    Success = false,
                    Message = "The stocksymbol could not be updated",
                };
            }

            StockSymbol responseStock = stockSymbolsRepo.Update(stockSymbol);

            stockSymbolsRepo.Save();

            return new ServiceResponse<StockSymbolModel>()
            {
                Data = mapper.Map<StockSymbolModel>(responseStock),
            };
        }

        // DELETE

        /// <summary>
        /// It deletes a particular StockSymbolModel object by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the deleted StockSymbolModel object.</returns>
        public ServiceResponse<StockSymbolModel> DeleteById(int id)
        {
            if (id <= 0)
            {
                return new ServiceResponse<StockSymbolModel>()
                {
                    Success = false,
                    Message = "The id cannot be 0 or less",
                };
            }

            StockSymbol? stockSymbol = stockSymbolsRepo.GetById(id);

            if (stockSymbol == null)
            {
                return new ServiceResponse<StockSymbolModel>()
                {
                    Success = false,
                    Message = "The stocksymbol could not be deleted",
                };
            }

            StockSymbol responseStock = stockSymbolsRepo.Delete(stockSymbol);
            stockSymbolsRepo.Save();

            return new ServiceResponse<StockSymbolModel>()
            {
                Data = mapper.Map<StockSymbolModel>(responseStock),
            };
        }

        /// <summary>
        /// It gets a list of StockSymbolModel objects available in the system with the property exchangeId set to input.
        /// </summary>
        /// <param name="exchangeId"></param>
        /// <returns>Returns a populated list of StockSymbolModel objects.</returns>
        public ServiceResponse<IEnumerable<StockSymbolModel>> GetStockByExchangeId(int exchangeId)
        {
            if (exchangeId <= 0)
            {
                return new ServiceResponse<IEnumerable<StockSymbolModel>>()
                {
                    Success = false,
                    Message = "The exchangeId cannot be 0 or less",
                };
            }

            IEnumerable<StockSymbol> stockSymbols = stockSymbolsRepo.GetListOfStockByExchangeId(exchangeId);

            if (stockSymbols == null)
            {
                return new ServiceResponse<IEnumerable<StockSymbolModel>>()
                {
                    Success = false,
                    Message = $"Could not create a list of StockSymbols with an ExchangeId of: {exchangeId}",
                };
            }

            //return - convert to domain
            return new ServiceResponse<IEnumerable<StockSymbolModel>>()
            {
                Data = mapper.Map<IEnumerable<StockSymbolModel>>(stockSymbols),
            };
        }
    }
}
