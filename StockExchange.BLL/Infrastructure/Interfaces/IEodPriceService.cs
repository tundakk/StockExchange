namespace StockExchange.BLL.Infrastructure.Interfaces
{
    using StockExchange.Domain.Model;
    using StockExchange.Domain.Model.Responses;

    public interface IEodPriceService
    {
        //GET
        //ServiceResponse<EodPriceModel> GetByDate(DateTime date);
        ServiceResponse<List<EodPriceModel>> GetAllEodPrices();
        ServiceResponse<List<EodPriceModel>> GetEodsByStockIdWhereDate(int stockId, DateTime from, DateTime to);

        ServiceResponse<EodPriceModel> GetById(int id);
        //Delete
        ServiceResponse<EodPriceModel> DeleteById(int id);
        // POST
        ServiceResponse<EodPriceModel> InsertEodPrice(EodPriceModel eodPriceModel);
        // PUT
        ServiceResponse<EodPriceModel> UpdateEodPrice(EodPriceModel eodPriceModel);


    }
}