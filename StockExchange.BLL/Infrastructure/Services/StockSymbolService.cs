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
        private readonly IStockSymbolRepo stockSymbolsRepo;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="StockSymbolService"/> class.
        /// </summary>
        /// <param name="stockSymbolsRepo"></param>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        public StockSymbolService(IStockSymbolRepo stockSymbolsRepo, IMapper mapper, ILogger<StockSymbolService> logger) : base(logger)
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

            StockSymbol? stockSymbol;
            try
            {
                stockSymbol = stockSymbolsRepo.GetById(id);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<StockSymbolModel>()
                {
                    Success = false,
                    Message = ex.Message,
                };
            }

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

            StockSymbol stockSymbol;

            try
            {
                stockSymbol = stockSymbolsRepo.GetByName(name);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<StockSymbolModel>()
                {
                    Success = false,
                    Message = ex.Message,
                };
            }

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
        public ServiceResponse<IEnumerable<StockSymbolModel>> GetAll()
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

            if (!stockSymbols.Any())
            {
                return new ServiceResponse<IEnumerable<StockSymbolModel>>()
                {
                    Success = false,
                    Message = "An empty list was returned",
                };
            }

            return new ServiceResponse<IEnumerable<StockSymbolModel>>()
            {
                Data = mapper.Map<IEnumerable<StockSymbolModel>>(stockSymbols),
            };
        }

        // POST

        /// <summary>
        /// It inserts a particular StockSymbolModel object.
        /// </summary>
        /// <param name="stockSymbolModel"></param>
        /// <returns>returns a populated StockSymbolModel object.</returns>
        public ServiceResponse<StockSymbolModel> Insert(StockSymbolModel stockSymbolModel)
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
        public ServiceResponse<StockSymbolModel> Update(StockSymbolModel stockSymbolModel)
        {
            if (stockSymbolModel == null)
            {
                return new ServiceResponse<StockSymbolModel>()
                {
                    Success = false,
                    Message = "The stockSymbolModel input cannot be null.",
                };
            }

            StockSymbol stockSymbol = mapper.Map<StockSymbol>(stockSymbolModel);

            if (stockSymbol == null)
            {
                return new ServiceResponse<StockSymbolModel>()
                {
                    Success = false,
                    Message = "The stocksymbol could not be updated.",
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
        public ServiceResponse<StockSymbolModel> Delete(int id)
        {
            if (id <= 0)
            {
                return new ServiceResponse<StockSymbolModel>()
                {
                    Success = false,
                    Message = "The id cannot be 0 or less.",
                };
            }

            StockSymbol? stockSymbol = stockSymbolsRepo.GetById(id);

            if (stockSymbol == null)
            {
                return new ServiceResponse<StockSymbolModel>()
                {
                    Success = false,
                    Message = "The stocksymbol could not be deleted.",
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
                    Message = "The exchangeId cannot be 0 or less.",
                };
            }

            IEnumerable<StockSymbol> stockSymbols;

            try
            {
                stockSymbols = stockSymbolsRepo.GetListOfStockByExchangeId(exchangeId);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<StockSymbolModel>>()
                {
                    Success = false,
                    Message = ex.Message,
                };
            }

            if (stockSymbols == null)
            {
                return new ServiceResponse<IEnumerable<StockSymbolModel>>()
                {
                    Success = false,
                    Message = $"Could not create a list of StockSymbols with an ExchangeId of: {exchangeId}.",
                };
            }

            if (!stockSymbols.Any())
            {
                return new ServiceResponse<IEnumerable<StockSymbolModel>>()
                {
                    Success = false,
                    Message = "Database returned an empty list.",
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
