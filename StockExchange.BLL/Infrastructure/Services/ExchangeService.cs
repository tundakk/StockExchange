namespace StockExchange.BLL.Infrastructure.Services
{
    using AutoMapper;
    using Microsoft.Extensions.Logging;

    using StockExchange.BLL.Infrastructure.Interfaces;
    using StockExchange.DAL.DataModel;
    using StockExchange.DAL.Repos.Interface;
    using StockExchange.Domain.Model;
    using StockExchange.Domain.Model.Responses;

    /// <summary>
    /// Exchange Service.
    /// </summary>
    public class ExchangeService : BaseService<ExchangeService>, IExchangeService
    {
        private readonly IExchangeRepo exchangeRepo;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExchangeService"/> class.
        /// </summary>
        /// <param name="exchangeRepo"></param>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        public ExchangeService(IExchangeRepo exchangeRepo, IMapper mapper, ILogger<ExchangeService> logger) : base(logger)
        {
            this.exchangeRepo = exchangeRepo;
            this.mapper = mapper;
        }

        // GET

        /// <summary>
        /// It gets a IEnumerable of all the Exchanges in the system.
        /// </summary>
        /// <returns> Returns a IEnumerable of populated ExchangeModel.</returns>
        public ServiceResponse<IEnumerable<ExchangeModel>> GetAll()
        {
            IEnumerable<Exchange> exchanges = exchangeRepo.GetAll();

            if (exchanges == null)
            {
                return new ServiceResponse<IEnumerable<ExchangeModel>>()
                {
                    Success = false,
                    Message = "did not recieve list of exhanges from database",
                };
            }

            if (!exchanges.Any())
            {
                return new ServiceResponse<IEnumerable<ExchangeModel>>()
                {
                    Success = false,
                    Message = "An empty list was returned",
                };
            }

            return new ServiceResponse<IEnumerable<ExchangeModel>>()
            {
                Data = mapper.Map<IEnumerable<ExchangeModel>>(exchanges),
            };
        }

        /// <summary>
        /// It gets a particular exchange available in the system.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A populated ExchangeModel object.</returns>
        public ServiceResponse<ExchangeModel> GetById(int id)
        {
            if (id <= 0)
            {
                return new ServiceResponse<ExchangeModel>()
                {
                    Success = false,
                    Message = "id cannot be 0 or less",
                };
            }

            Exchange? exchange;
            try
            {
                exchange = exchangeRepo.GetById(id);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<ExchangeModel>()
                {
                    Success = false,
                    Message = ex.Message,
                };
            }

            if (exchange == null)
            {
                return new ServiceResponse<ExchangeModel>()
                {
                    Success = false,
                    Message = "An Exchange with that id wasn't found",
                };
            }

            return new ServiceResponse<ExchangeModel>()
            {
                Data = mapper.Map<ExchangeModel>(exchange),
            };
        }

        /// <summary>
        /// It gets a particular exchangemodel by name property.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>returns a populated exhange object.</returns>
        public ServiceResponse<ExchangeModel> GetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return new ServiceResponse<ExchangeModel>()
                {
                    Success = false,
                    Message = "string name cannot be null or empty",
                };
            }

            Exchange? exchange;

            try
            {
                exchange = exchangeRepo.GetByName(name);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<ExchangeModel>()
                {
                    Success = false,
                    Message = ex.Message,
                };
            }

            if (exchange == null)
            {
                return new ServiceResponse<ExchangeModel>()
                {
                    Success = false,
                    Message = "An Exchange with that name wasn't found",
                };
            }

            return new ServiceResponse<ExchangeModel>()
            {
                Data = mapper.Map<ExchangeModel>(exchange),
            };
        }

        /// <summary>
        /// It inserts a particular exchange object.
        /// </summary>
        /// <param name="exchangeModel"></param>
        /// <returns>returns a populated exhange object.</returns>
        public ServiceResponse<ExchangeModel> Insert(ExchangeModel exchangeModel) //should this return a bool?
        {
            if (exchangeModel == null)
            {
                return new ServiceResponse<ExchangeModel>()
                {
                    Success = false,
                    Message = "exchangeModel object cannot be null",
                };
            }

            Exchange exchange = mapper.Map<Exchange>(exchangeModel);
            if (exchange == null)
            {
                return new ServiceResponse<ExchangeModel>()
                {
                    Success = false,
                    Message = "An Exchange with that name wasn't found",
                };
            }

            Exchange responseExchange = exchangeRepo.Insert(exchange);

            exchangeRepo.Save();

            return new ServiceResponse<ExchangeModel>()
            {
                Data = mapper.Map<ExchangeModel>(responseExchange),
            };
        }

        // UPDATE

        /// <summary>
        /// It updates a particular ExchangeModel object.
        /// </summary>
        /// <param name="exchangeModel"></param>
        /// <returns>Returns the updated ExchangeModel object.</returns>
        public ServiceResponse<ExchangeModel> Update(ExchangeModel exchangeModel)
        {
            if (exchangeModel == null)
            {
                return new ServiceResponse<ExchangeModel>()
                {
                    Success = false,
                    Message = "exchangeModel object cannot be null",
                };
            }

            Exchange exchange = mapper.Map<Exchange>(exchangeModel);

            if (exchange == null)
            {
                return new ServiceResponse<ExchangeModel>()
                {
                    Success = false,
                    Message = "An Exchange wasn't found",
                };
            }

            Exchange responseExchange = exchangeRepo.Update(exchange);

            exchangeRepo.Save();

            return new ServiceResponse<ExchangeModel>()
            {
                Data = mapper.Map<ExchangeModel>(responseExchange),
            };
        }

        // DELETE

        /// <summary>
        /// It deletes a particular exchange object by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the deleted exhange object.</returns>
        public ServiceResponse<ExchangeModel> Delete(int id)
        {
            if (id <= 0)
            {
                return new ServiceResponse<ExchangeModel>()
                {
                    Success = false,
                    Message = "The id cannot be 0 or less",
                };
            }

            Exchange? exchange = exchangeRepo.GetById(id);

            if (exchange == null)
            {
                return new ServiceResponse<ExchangeModel>()
                {
                    Success = false,
                    Message = "Could not delete Exhange",
                };
            }

            Exchange responseExchange = exchangeRepo.Delete(exchange);

            exchangeRepo.Save();

            return new ServiceResponse<ExchangeModel>()
            {
                Data = mapper.Map<ExchangeModel>(responseExchange),
            };
        }
    }
}
