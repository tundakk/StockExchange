namespace StockExchange.DAL.Repos.Interface
{
    using StockExchange.DAL.DataModel;
    using StockExchange.DAL.Repos.Base;

    public interface IEodPriceRepo : IBaseRepo<EodPrice>
    {
        //GET
        EodPrice GetById(int id);
        //EodPrice GetByDate(DateTime date);

        //get by date EodPrice GetByDate(string date);

        //PUT
        //POST
        //DELETE
    }
}
