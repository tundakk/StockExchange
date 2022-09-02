namespace StockExchange.DAL.Repos.Interface
{
    using StockExchange.DAL.DataModel;
    using StockExchange.DAL.Repos.Base;

    public interface IEodPriceRepo : IBaseRepo<EodPrice>
    {
        //GET
        EodPrice GetById(int id);
        List<EodPrice> GetByStockId(int stockId, DateTime from, DateTime to);
        //EodPrice GetByDate(DateTime date);

        //get by date EodPrice GetByDate(string date);

        //PUT
        //POST
        //DELETE
    }
}
