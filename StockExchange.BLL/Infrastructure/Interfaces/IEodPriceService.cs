namespace StockExchange.BLL.Infrastructure.Interfaces
{
    using StockExchange.Domain.Model;

    public interface IEodPriceService
    {
        //GET
        //ServiceResponse<EodPriceModel> GetByDate(DateTime date);
        List<EodPriceModel> GetAllEodPrices();
        List<EodPriceModel> GetEodsByStockIdWhereDate(int stockId, DateTime from, DateTime to);

        EodPriceModel GetById(int id);
        //Delete
        bool DeleteById(int id);
        // POST
        void InsertEodPrice(EodPriceModel eodPriceModel);
        // PUT
        void UpdateEodPrice(EodPriceModel eodPriceModel);


    }
}