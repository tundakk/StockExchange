namespace StockExchange.BLL.Infrastructure.Services
{
    using Microsoft.Extensions.Logging;
    using StockExchange.BLL.Conversions;
    using StockExchange.BLL.Infrastructure.Interfaces;
    using StockExchange.DAL.DataModel;
    using StockExchange.DAL.Repos.Interface;
    using StockExchange.Domain.Model;
    using StockExchange.Domain.Model.Responses;

    public class ExchangeService : BaseService<ExchangeService>, IExchangeService
    {
        private readonly IExchangeRepo exchangeRepo;
        public ExchangeService(IExchangeRepo exchangeRepo, ILogger<ExchangeService> logger) : base(logger)
        {
            this.exchangeRepo = exchangeRepo;
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
                    Message = "Could not send List from database"
                };
            }
            return new ServiceResponse<List<ExchangeModel>>()
            {
                Data = ExchangeConvert.DalToDomainListOfExchanges(exchanges).ToList()
            };
        }



        public ServiceResponse<ExchangeModel> GetExchangeById(int id)
        {
            Exchange response = exchangeRepo.GetById(id);

            if (response == null)
            {
                return new ServiceResponse<ExchangeModel>()
                {
                    Success = false,
                    Message = "An Exchange with that id wasn't found"
                };
            }
            return new ServiceResponse<ExchangeModel>()
            {
                Data = ExchangeConvert.DalToDomainExchange(response)
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
                    Message = "An Exchange with that name wasn't found"
                };
            }
            return new ServiceResponse<ExchangeModel>()
            {
                Data = ExchangeConvert.DalToDomainExchange(exchange)
            };
        }

        // POST
        public ServiceResponse<ExchangeModel> InsertExchange(ExchangeModel exchangeModel) //should this return a bool?
        {
            Exchange exchange = ExchangeConvert.DomainToDalExchange(exchangeModel);
            if (exchange == null)
            {
                return new ServiceResponse<ExchangeModel>()
                {
                    Success = false,
                    Message = "An Exchange with that name wasn't found"
                };
            }
            Exchange responseExchange = exchangeRepo.Insert(exchange);
            exchangeRepo.Save();
            return new ServiceResponse<ExchangeModel>()
            {
                Data = ExchangeConvert.DalToDomainExchange(responseExchange)
            };
            //convert by dal back to domain
            //return updated model
        }
        // UPDATE
        public ServiceResponse<ExchangeModel> UpdateExchange(ExchangeModel exchangeModel)
        {
            Exchange exchange = ExchangeConvert.DomainToDalExchange(exchangeModel);

            if (exchange == null)
            {
                return new ServiceResponse<ExchangeModel>()
                {
                    Success = false,
                    Message = "An Exchange wasn't found"
                };
            }
            Exchange responseExchange = exchangeRepo.Update(exchange);
            exchangeRepo.Save();
            return new ServiceResponse<ExchangeModel>()
            {
                Data = ExchangeConvert.DalToDomainExchange(responseExchange)
            };
        }
        // DELETE
        public ServiceResponse<ExchangeModel> DeleteById(int id)
        {
            Exchange exchange = exchangeRepo.GetById(id);

            if (exchange == null)
            {
                return new ServiceResponse<ExchangeModel>()
                {
                    Success = false,
                    Message = "Could not delete Exhange"
                };
            }
            Exchange responseExchange = exchangeRepo.Delete(exchange);
            exchangeRepo.Save();
            return new ServiceResponse<ExchangeModel>()
            {
                Data = ExchangeConvert.DalToDomainExchange(responseExchange)
            };
        }

    }
}
