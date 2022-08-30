namespace StockExchange.BLL.Infrastructure.Services
{

    using StockExchange.BLL.Infrastructure.Interfaces;
    using StockExchange.DAL.DataModel;
    using StockExchange.DAL.Repos.Interface;
    using StockExchange.Domain.Model.Responses;

    public class ExchangeService : IExchangeService
    {
        private readonly IExchangeRepo exchangeRepo;
        public ExchangeService(IExchangeRepo exchangeRepo)
        {
            this.exchangeRepo = exchangeRepo;
        }

        public bool Delete(int id)
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

        public List<Exchange> GetAllExchanges()
        {
            IQueryable<Exchange> exchanges = exchangeRepo.GetAll();

            return exchanges
                .ToList(); // i should ask about the logic here. do i make a lot of redundant stuff?
        }

        public Exchange GetById(int id)
        {
            Exchange response = exchangeRepo.GetById(id);

            return response;
        }
        public ServiceResponse<Exchange> GetByName(string name)
        {
            var response = new ServiceResponse<Exchange>();
            Exchange exchange = exchangeRepo.GetByName(name);
            if (exchange == null)
            {
                response.Success = false;
                response.Message = "An exchange with that name wasn't found";
            }
            else
                response.Data = exchange;

            return response;
        }
    }
}
