namespace StockExchange.DAL.Repos
{
    using StockExchange.DAL.DataModel;
    using StockExchange.DAL.Repos.Base;
    using StockExchange.DAL.Repos.Interface;
    using System.Linq;

    public class StockSymbolsRepo : BaseRepo<StockSymbol>, IStockSymbolsRepo
    {

        public StockSymbolsRepo(DataContext deliveryContext) : base(deliveryContext)
        {
        }

        public override void Delete(StockSymbol entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Delete - Exchange must not be null");
            }

            deliveryContext.StockSymbols.Remove(entity);
        }

        public override IQueryable<StockSymbol> GetAll()
        {
            return deliveryContext.StockSymbols;
        }

        public StockSymbol GetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("GetByName - name must not be null or empty.");

            return this.GetAll().FirstOrDefault(s => string.Equals(s.CompanyName.ToLower(), name.ToLower()));  //does it iterate through the string and stops when theres a difference?
                                                                                                               //is it better than .Where?
                                                                                                               //is ToLower a good addition or should it be BL?
                                                                                                               //return this.GetAll().FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                                                                                                               //.Where(p => p.Name.ToLower().Contains(name.ToLower()))
        }

        public StockSymbol GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID must be greater than 0");

            return deliveryContext.StockSymbols.Find(id);
        }

        public List<StockSymbol> GetListOfStockByExchangeId(int exchangeId)
        {
            return GetAll().Where(s => s.ExchangeId == exchangeId).ToList();
        }

        public override void Insert(StockSymbol entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Insert - BlockFragment must not be null");
            }

            deliveryContext.StockSymbols.Add(entity);
        }

    }
}
