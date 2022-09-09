namespace StockExchange.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public abstract class BaseApiController<T> : ControllerBase
        where T : BaseApiController<T>
    {
        protected readonly ILogger<T> Logger;

        public BaseApiController(ILogger<T> logger)
        {
            Logger = logger;
        }
    }
}
