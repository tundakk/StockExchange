namespace StockExchange.DAL.Repos
{
    using System.Collections.Generic;
    using System.Linq;
    using StockExchange.DAL.DataModel;
    using StockExchange.DAL.Repos.Base;
    using StockExchange.DAL.Repos.Interface;

    /// <summary>
    /// Repository class for Eod Price.
    /// </summary>
    public class EodPriceRepo : BaseRepo<EodPrice>, IEodPriceRepo
    {
        /// <summary>
        /// Default constructor for EodPriceRepo.
        /// </summary>
        /// <param name="deliveryContext">Public readonly property on the BaseRepo class.</param>
        public EodPriceRepo(DataContext deliveryContext) : base(deliveryContext)
        {
        }

        /// <summary>
        /// Deletes an eod price.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>returns the eod price that was deleted.</returns>
        /// <exception cref="ArgumentException"></exception>
        public override EodPrice Delete(EodPrice entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Delete - EodPrice must not be null");
            }

            DeliveryContext.EodPrices.Remove(entity);
            return entity;
        }

        /// <summary>
        /// Gets all entities from EodPrice table.
        /// </summary>
        /// <returns>returns a populated list of type EodPrice, of all entities in the database.</returns>
        public override IQueryable<EodPrice> GetAll()
        {
            return DeliveryContext.EodPrices;
        }

        /// <summary>
        /// Get EodPrice object by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a populated EodPrice object by matching ID.</returns>
        /// <exception cref="ArgumentException"></exception>
        public EodPrice? GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("GetById - id must be greater than 0");
            }

            return DeliveryContext.EodPrices.Find(id);
        }

        /// <summary>
        /// Gets a list of EOD price objects with specific StockSymbolId and a date range.
        /// </summary>
        /// <param name="stockId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public IEnumerable<EodPrice> GetByStockExchangeIdAndDate(int stockId, DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null)
            {
                throw new ArgumentException("GetByStockExchangeIdAndDate - startDate cannot be null");
            }

            if (endDate == null)
            {
                throw new ArgumentException("GetByStockExchangeIdAndDate - endDate cannot be null");
            }

            if (startDate > endDate)
            {
                throw new ArgumentException("GetByStockExchangeIdAndDate - something is wrong with the dates");
            }

            if (stockId <= 0)
            {
                throw new ArgumentException("GetByStockExchangeIdAndDate - ID must be greater than 0");
            }

            return DeliveryContext.EodPrices.Where(s => s.StockSymbolId == stockId && s.Date < endDate && s.Date > startDate);
        }

        /// <summary>
        /// Inserts an eod price into the database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>returns the populated eod price that was inserted.</returns>
        /// <exception cref="ArgumentException"></exception>
        public override EodPrice Insert(EodPrice entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Insert - EodPrice must not be null");
            }

            DeliveryContext.EodPrices.Add(entity);

            return entity;
        }
    }
}
