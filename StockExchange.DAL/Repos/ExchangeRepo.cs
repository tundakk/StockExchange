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
        //private readonly DataContext deliveryContext;


        public ExchangeRepo(DataContext deliveryContext) : base(deliveryContext)
        {
        }

        //GET

        public override IQueryable<Exchange> GetAll()
        {
            return deliveryContext.Exchanges; //does this return a list of Exhange objects?
        }

        public Exchange GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID must be greater than 0");

            return deliveryContext.Exchanges.Find(id);
        }

        public Exchange GetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("GetByName - name must not be null or empty.");

            return this.GetAll()
                .FirstOrDefault(s => string.Equals(s.Name.ToLower(), name.ToLower()));  //does it iterate through the string and stops when theres a difference?
                                                                                        //is it better than .Where?
        }

        // POST
        public override void Insert(Exchange entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Insert - BlockFragment must not be null");
            }

            deliveryContext.Exchanges.Add(entity);
        }
        // DELETE
        public override void Delete(Exchange entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Delete - Exchange must not be null");
            }

            deliveryContext.Exchanges.Remove(entity);
        }


    }
}
