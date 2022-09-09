namespace StockExchange.DAL.Repos
{
    using StockExchange.DAL.DataModel;
    using StockExchange.DAL.Repos.Base;
    using StockExchange.DAL.Repos.Interface;
    using System.Collections.Generic;
    using System.Linq;

    public class EodPriceRepo : BaseRepo<EodPrice>, IEodPriceRepo
    {

        public EodPriceRepo(DataContext deliveryContext) : base(deliveryContext)
        {

        }

        public override EodPrice Delete(EodPrice entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Delete - EodPrice must not be null");
            }

            deliveryContext.EodPrices.Remove(entity);
            return entity;

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

        public List<EodPrice> GetByStockExchangeIdAndDate(int stockId, DateTime startDate, DateTime endDate)
        {

            if (startDate > endDate)
                throw new ArgumentException("something is wrong with the dates");

            if (stockId <= 0)
                throw new ArgumentException("ID must be greater than 0");

            return deliveryContext.EodPrices.Where(s => s.StockSymbolId == stockId && s.Date < endDate && s.Date > startDate).ToList();
        }

        public override EodPrice Insert(EodPrice entity)
        {
            if (entity == null)
                throw new ArgumentException("Insert - EodPrice must not be null");

            deliveryContext.EodPrices.Add(entity);

            return entity;
        }
        //public EodPrice GetByDate(DateTime date)
        //{
        //    if (string.IsNullOrEmpty(date))
        //        throw new ArgumentException("GetByName - name must not be null or empty.");

        //    return this.GetAll().Where(s => DateTime.Equals(s.Date.Date, date));                                                                                      
        //}

    }
}