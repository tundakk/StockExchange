namespace StockExchange.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StockExchange.BLL.Infrastructure.Interfaces;
    using StockExchange.DAL.DataModel;
    using StockExchange.Domain.Model.Responses;

    [Route("api/[controller]")]
    [ApiController]
    public class StockSymbolController : ControllerBase
    {
        private readonly IStockSymbolService stockSymbolService;
        public StockSymbolController(IStockSymbolService stockSymbolService)
        {
            this.stockSymbolService = stockSymbolService;
        }
        [HttpGet("StockSymbol by name")]
        public ActionResult<ServiceResponse<StockSymbol>> GetStockSymbolByName(string name)
        {
            var result = stockSymbolService.GetByName(name);

            return Ok(result);
        }
    }
}
