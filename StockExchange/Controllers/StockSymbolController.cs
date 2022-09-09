namespace StockExchange.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StockExchange.BLL.Infrastructure.Interfaces;
    using StockExchange.Domain.Model;
    using StockExchange.Domain.Model.Responses;

    [Route("api/[controller]")]
    [ApiController]
    public class StockSymbolController : BaseApiController<StockSymbolController>
    {
        private readonly IStockSymbolService stockSymbolService;
        public StockSymbolController(IStockSymbolService stockSymbolService, ILogger<StockSymbolController> logger) : base(logger)
        {
            this.stockSymbolService = stockSymbolService;
        }
        [HttpGet("StockSymbol by name")]
        public ActionResult<StockSymbolModel> GetStockSymbolByName(string name)
        {
            if (String.IsNullOrEmpty(name))
                return BadRequest();

            ServiceResponse<StockSymbolModel> response = stockSymbolService.GetByName(name);
            if (response.Data == null)
                return NotFound();

            return Ok(response.Data);
        }
        [HttpGet("List all stocksymbols")]
        public ActionResult<List<StockSymbolModel>> GetAllStockSymbols()
        {
            ServiceResponse<List<StockSymbolModel>> response = stockSymbolService.GetAllStockSymbols();
            if (response.Data.Count == 0)
                return NotFound();

            return Ok(response.Data);
        }
        [HttpGet("Get stocksymbol ID")]
        public ActionResult<StockSymbolModel> GetById(int id)
        {
            if (id == 0)
                return BadRequest();

            ServiceResponse<StockSymbolModel> response = stockSymbolService.GetById(id);
            if (response.Data == null)
                return NotFound();

            return Ok(response.Data);
        }
        [HttpGet("Get stocksymbols by exchange ID")]
        public ActionResult<List<StockSymbolModel>> GetStockByExchangeId(int exchangeId)
        {
            if (exchangeId == 0)
                return BadRequest();

            ServiceResponse<List<StockSymbolModel>> response = stockSymbolService.GetStockByExchangeId(exchangeId);
            if (response.Data.Count == 0)
                return NotFound();

            return Ok(response.Data);
        }

        //make return types
        [HttpPut("Update stocksymbol")]
        public ActionResult<StockSymbolModel> UpdateStockSymbol(StockSymbolModel stockSymbolModel)
        {
            if (stockSymbolModel.ID == 0)
                return BadRequest();

            ServiceResponse<StockSymbolModel> response = stockSymbolService.UpdateStockSymbol(stockSymbolModel);
            if (response.Data == null)
                return NotFound();

            return Ok(response.Data);
        }

        [HttpPost("Create a stocksymbol")]
        public ActionResult<StockSymbolModel> CreateExchange(StockSymbolModel stockSymbolModel)
        {
            if (stockSymbolModel.ID == 0)
                return BadRequest();
            ServiceResponse<StockSymbolModel> response = stockSymbolService.InsertStockSymbol(stockSymbolModel);
            if (response.Data == null)
                return NotFound();

            return Ok(response.Data);
        }

        [HttpDelete("Delete stocksymbol")]
        public ActionResult<StockSymbolModel> DeleteStockSymbolById(int id)
        {
            if (id == 0)
                return BadRequest();

            ServiceResponse<StockSymbolModel> response = stockSymbolService.DeleteById(id);
            if (response.Data == null)
                return NotFound();

            return Ok(response.Data);
        }
    }
}
