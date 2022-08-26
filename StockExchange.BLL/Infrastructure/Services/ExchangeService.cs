namespace StockExchange.BLL.Infrastructure.Services
{

    using StockExchange.BLL.Infrastructure.Interfaces;
    using StockExchange.DAL.DataModel;
    using StockExchange.DAL.Repos.Interface;

    public class ExchangeService : IExchangeService
    {
        private readonly IExchangeRepo exchangeRepo;
        public ExchangeService(IExchangeRepo exchangeRepo)
        {
            this.exchangeRepo = exchangeRepo;
        }

        public List<StockSymbol> GetAllExchanges()
        {
            IQueryable<StockSymbol> exchanges = exchangeRepo.GetAll();

            return exchanges
                .ToList(); // i should ask about the logic here. do i make a lot of redundant stuff?
        }

    }
}
