namespace StockExchange.BLL.Infrastructure.Interfaces
{
    using StockExchange.Domain.Model;

    public interface IEodPriceService
    {
        EodPriceModel GetById(int id);

    }
}
