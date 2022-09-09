namespace StockExchange.BLL.Infrastructure.Services
{
    using Microsoft.Extensions.Logging;

    public abstract class BaseService<T>
        where T : BaseService<T>
    {
        protected readonly ILogger<T> Logger;

        public BaseService(ILogger<T> logger)
        {
            Logger = logger;
        }
    }
}
