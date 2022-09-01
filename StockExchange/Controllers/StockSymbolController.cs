namespace StockExchange.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StockExchange.BLL.Infrastructure.Interfaces;
    using StockExchange.DAL.DataModel;
    using StockExchange.Domain.Model;
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
        [HttpGet("List all stocksymbols")]
        public ActionResult<List<StockSymbolModel>> GetAllStockSymbols()
        {

            var result = stockSymbolService.GetAllStockSymbols();
            return Ok(result);
        }
        [HttpGet("Get stocksymbol ID")]
        public ActionResult<StockSymbolModel> GetById(int id)
        {
            var result = stockSymbolService.GetById(id);

            return Ok(result);
        }
        [HttpGet("Get stocksymbols by exchange ID")]
        public ActionResult<List<StockSymbolModel>> GetStockByExchangeId(int exchangeId)
        {
            var result = stockSymbolService.GetStockByExchangeId(exchangeId);
            return Ok(result);
        }
        [HttpPut("Update stocksymbol")]
        public void UpdateStockSymbol(StockSymbolModel stockSymbolModel)
        {
            stockSymbolService.UpdateStockSymbol(stockSymbolModel);
        }
        [HttpDelete("Delete stocksymbol")]
        public void DeleteStockSymbolById(int id)
        {
            stockSymbolService.DeleteById(id);
        }
        [HttpPost("Create a stocksymbol")]
        public void CreateExchange(StockSymbolModel stockSymbolModel)
        {
            stockSymbolService.InsertStockSymbol(stockSymbolModel);

        }
    }
}
