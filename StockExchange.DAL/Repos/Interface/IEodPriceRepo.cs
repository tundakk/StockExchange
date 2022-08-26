namespace StockExchange.DAL.Repos.Interface
{
    using StockExchange.DAL.DataModel;
    using StockExchange.DAL.Repos.Base;

    public interface IEodPriceRepo : IBaseRepo<EodPrice>
    {
        //GET
        EodPrice GetByEodPriceID(int id);
        //get by date EodPrice GetByDate(string date);

        //PUT
        //POST
        //DELETE
    }
}
