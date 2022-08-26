namespace StockExchange.DAL.Repos
{
    using StockExchange.DAL.DataModel;
    using StockExchange.DAL.Repos.Base;
    using StockExchange.DAL.Repos.Interface;
    using System.Linq;

    public class ExchangeRepo : BaseRepo<Exchange>, IExchangeRepo
    {
        /// <summary>
        /// I can call deliveryContext because its public in BaseRepo. pretty smart!
        /// </summary>
        /// <param name="deliveryContext"></param>
        private readonly DataContext deliveryContext;


        public ExchangeRepo(DataContext deliveryContext) : base(deliveryContext)
        {
            this.deliveryContext = deliveryContext;
        }

        public ExchangeRepo() : base()
        {

        }

        public override void Delete(Exchange entity)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Exchange> GetAll()
        {
            return deliveryContext.Exchanges; //does this return a list of Exhange objects?
        }

        public override void Insert(Exchange entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(Exchange entity)
        {
            throw new NotImplementedException();
        }
    }
}
