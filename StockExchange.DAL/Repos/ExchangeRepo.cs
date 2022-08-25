namespace StockExchange.DAL.Repos
{
    using StockExchange.DAL.DataModel;
    using StockExchange.DAL.Repos.Base;
    using StockExchange.DAL.Repos.Interface;
    using System.Linq;

    public class ExchangeRepo : BaseRepo<ExchangeRepo>, IExchangeRepo
    {
        private readonly DataContext deliveryContext;

        public ExchangeRepo(DataContext deliveryContext) : base(deliveryContext)
        {
            this.deliveryContext = deliveryContext;
        }

        public void Delete(IExchangeRepo entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(IExchangeRepo entity)
        {
            throw new NotImplementedException();
        }

        public void Update(IExchangeRepo entity)
        {
            throw new NotImplementedException();
        }

        IQueryable<IExchangeRepo> IBaseRepo<IExchangeRepo>.GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a list of all Exchange objects in the db
        /// </summary>


    }
}
