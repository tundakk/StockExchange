namespace StockExchange.DAL.Repos.Interface
{
    using StockExchange.DAL.DataModel;
    using StockExchange.DAL.Repos.Base;

    public interface IExchangeRepo : IBaseRepo<Exchange>
    {
        //GET
        Exchange GetById(int id);
        Exchange GetByName(string name);

        //PUT
        //POST
        //DELETE

    }
}
