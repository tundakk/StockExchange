namespace StockExchange.DAL.Repos
{
    using StockExchange.DAL.DataModel;
    using StockExchange.DAL.Repos.Base;
    using StockExchange.DAL.Repos.Interface;
    using System.Linq;

    public class EodPriceRepo : BaseRepo<EodPrice>, IEodPriceRepo
    {

        public EodPriceRepo(DataContext deliveryContext) : base(deliveryContext)
        {

        }

        public override void Delete(EodPrice entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Delete - Exchange must not be null");
            }

            deliveryContext.EodPrices.Remove(entity);
        }

        public override IQueryable<EodPrice> GetAll()
        {
            return deliveryContext.EodPrices;
        }

        public EodPrice GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID must be greater than 0");

            return deliveryContext.EodPrices.Find(id);
        }

        public override void Insert(EodPrice entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Insert - BlockFragment must not be null");
            }

            deliveryContext.EodPrices.Add(entity);
        }

    }
}