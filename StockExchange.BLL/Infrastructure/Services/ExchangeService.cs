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
    /// testestes.
    /// </summary>
    public class ExchangeService : BaseService<ExchangeService>, IExchangeService
    {
        private readonly IExchangeRepo exchangeRepo;
        private readonly IMapper mapper;

        public ExchangeService(IExchangeRepo exchangeRepo, IMapper mapper, ILogger<ExchangeService> logger) : base(logger)
        {
            this.exchangeRepo = exchangeRepo;
            this.mapper = mapper;
        }

        //GET
        public ServiceResponse<List<ExchangeModel>> GetAllExchanges()
        {
            List<Exchange> exchanges = exchangeRepo.GetAll().ToList();

            if (exchanges == null)
            {
                return new ServiceResponse<List<ExchangeModel>>()
                {
                    Success = false,
                    Message = "did not recieve list of exhanges from database",
                };
            }

            return new ServiceResponse<List<ExchangeModel>>()
            {
                Data = mapper.Map<List<ExchangeModel>>(exchanges),
            };
        }

        public ServiceResponse<ExchangeModel> GetExchangeById(int id)
        {
            Exchange exchange = exchangeRepo.GetById(id);

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

        public ServiceResponse<ExchangeModel> GetByName(string name)
        {
            Exchange exchange = exchangeRepo.GetByName(name);
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

        public ServiceResponse<ExchangeModel> InsertExchange(ExchangeModel exchangeModel) //should this return a bool?
        {
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
            //convert by dal back to domain
            //return updated model
        }

        // UPDATE
        public ServiceResponse<ExchangeModel> UpdateExchange(ExchangeModel exchangeModel)
        {
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

        public ServiceResponse<ExchangeModel> DeleteById(int id)
        {
            Exchange exchange = exchangeRepo.GetById(id);

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
