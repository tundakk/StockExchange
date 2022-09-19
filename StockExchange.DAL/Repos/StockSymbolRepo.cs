namespace StockExchange.DAL.Repos
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using StockExchange.DAL.DataModel;
    using StockExchange.DAL.Repos.Base;
    using StockExchange.DAL.Repos.Interface;

    /// <summary>
    /// Repository class for stocksymbol.
    /// </summary>
    public class StockSymbolRepo : BaseRepo<StockSymbol>, IStockSymbolRepo
    {
        /// <summary>
        /// Default constructor for StockSymbolsRepo.
        /// </summary>
        /// <param name="dataContext">Public readonly property on the BaseRepo class.</param>
        public StockSymbolRepo(DataContext dataContext) : base(dataContext)
        {
        }

        /// <summary>
        /// Deletes a stocksymbol.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>returns the stocksymbol that was deleted.</returns>
        /// <exception cref="ArgumentException"></exception>
        public override StockSymbol Delete(StockSymbol entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Delete - Exchange must not be null");
            }

            DataContext.StockSymbols.Remove(entity);
            return entity;
        }

        /// <summary>
        /// Gets all entities from stocksymbol table.
        /// </summary>
        /// <returns>returns a populated list of type StockSymbol, of all entities in the database.</returns>
        public override IQueryable<StockSymbol> GetAll()
        {
            return DataContext.StockSymbols;
        }

        /// <summary>
        /// It gets an object of type StockSymbol from repo by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>a populated StockSymbol object.</returns>
        /// <exception cref="ArgumentException"></exception>
        public StockSymbol GetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("GetByName - name must not be null or empty.");
            }

            return this.GetAll().FirstOrDefault(s => string.Equals(s.CompanyName.ToLower(), name.ToLower()));

            // does it iterate through the string and stops when theres a difference?
            // is it better than .Where?
            // is ToLower a good addition or should it be BL?
            // return this.GetAll().FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            // .Where(p => p.Name.ToLower().Contains(name.ToLower()))
        }

        /// <summary>
        /// Get StockSymbol object by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a populated StockSymbol object by matching ID.</returns>
        /// <exception cref="ArgumentException"></exception>
        public StockSymbol GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID must be greater than 0");
            }

            return DataContext.StockSymbols.Find(id);
        }

        /// <summary>
        /// Gets a list of StockSymbol by exchangeId.
        /// </summary>
        /// <param name="exchangeId"></param>
        /// <returns>Returns a list of StockSymbol all entities with exchangeId set to input.</returns>
        /// <exception cref="ArgumentException"></exception>
        public IEnumerable<StockSymbol> GetListOfStockByExchangeId(int exchangeId)
        {
            if (exchangeId <= 0)
            {
                throw new ArgumentException("GetListOfStockByExchangeId - exchangeId cant be equal or less than 0");
            }

            var response = new List<StockSymbol>();

            response = GetAll().Where(s => s.ExchangeId == exchangeId)
               .Include(e => e.EodPrices)
               .Include(sv => sv.Exchange)
               .ToList();
            return response;
        }

        /// <summary>
        /// Inserts a stocksymbol into the database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>returns the populated stocksymbol that was inserted.</returns>
        /// <exception cref="ArgumentException"></exception>
        public override StockSymbol Insert(StockSymbol entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Insert - BlockFragment must not be null");
            }

            DataContext.StockSymbols.Add(entity);
            return entity;
        }
    }
}
