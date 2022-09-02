namespace StockExchange.BLL.Infrastructure.Services
{
    using StockExchange.BLL.Conversions;
    using StockExchange.BLL.Infrastructure.Interfaces;
    using StockExchange.DAL.DataModel;
    using StockExchange.DAL.Repos.Interface;
    using StockExchange.Domain.Model;
    using StockExchange.Domain.Model.Responses;

    public class ExchangeService : IExchangeService
    {
        private readonly IExchangeRepo exchangeRepo;
        public ExchangeService(IExchangeRepo exchangeRepo)
        {
            this.exchangeRepo = exchangeRepo;
        }

        //GET
        public List<ExchangeModel> GetAllExchanges()
        {
            List<Exchange> exchanges = exchangeRepo.GetAll().ToList();

            //conversion from DAL model to DOMAIN model
            ICollection<ExchangeModel> responseModel = ExchangeConvert.DalToDomainListOfExchanges(exchanges);

            return responseModel.ToList(); // ICollection and lists. im doing something wrong  ithink

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
        public void InsertExchange(ExchangeModel exchangeModel) //should this return a bool?
        {
            if (exchangeModel == null)
                throw new ArgumentNullException(nameof(exchangeModel));
            Exchange exchange = ExchangeConvert.DomainToDalExchange(exchangeModel);

            exchangeRepo.Insert(exchange);
            exchangeRepo.Save();
        }
        // UPDATE
        public void UpdateExchange(ExchangeModel exchangeModel)
        {
            Exchange exchange = ExchangeConvert.DomainToDalExchange(exchangeModel);

            exchangeRepo.Update(exchange);
            exchangeRepo.Save();
        }
        // DELETE
        public bool DeleteById(int id)
        {
            Exchange exchange = exchangeRepo.GetById(id);

            if (exchange == null)
            {
                return false;
            }

            exchangeRepo.Delete(exchange);
            exchangeRepo.Save();
            return true;
        }
    }
}
