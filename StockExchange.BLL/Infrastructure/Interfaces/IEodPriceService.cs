namespace StockExchange.BLL.Infrastructure.Interfaces
{
    using StockExchange.Domain.Model;

    public interface IEodPriceService
    {
        //GET
        EodPriceModel GetById(int id);
        //Delete
        bool DeleteById(int id);
        // POST
        void InsertEodPrice(EodPriceModel eodPriceModel);
        // PUT
        void UpdateEodPrice(EodPriceModel eodPriceModel);


    }
}