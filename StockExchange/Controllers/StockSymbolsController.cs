namespace StockExchange.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StockExchange.BLL.Infrastructure.Interfaces;
    using StockExchange.Domain.Model;
    using StockExchange.Domain.Model.Responses;

    [Route("api/[controller]")]
    [ApiController]
    public class StockSymbolsController : BaseApiController<StockSymbolsController>
    {
        private readonly IStockSymbolService stockSymbolService;
        public StockSymbolsController(IStockSymbolService stockSymbolService, ILogger<StockSymbolsController> logger) : base(logger)
        {
            this.stockSymbolService = stockSymbolService;
        }
        [HttpGet("name")] //dunno about this?
        public ActionResult<StockSymbolModel> GetStockSymbolByName(string name)
        {
            if (String.IsNullOrEmpty(name))
                return BadRequest();

            ServiceResponse<StockSymbolModel> response = stockSymbolService.GetByName(name);
            if (response.Data == null)
                return NoContent();

            return Ok(response.Data);
        }
        [HttpGet("")]
        public ActionResult<List<StockSymbolModel>> GetAllStockSymbols()
        {
            ServiceResponse<List<StockSymbolModel>> response = stockSymbolService.GetAllStockSymbols();
            if (response.Data.Count == 0)
                return NoContent();

            return Ok(response.Data);
        }
        [HttpGet("{id}")]
        public ActionResult<StockSymbolModel> GetById(int id)
        {
            if (id <= 0)
                return BadRequest();

            ServiceResponse<StockSymbolModel> response = stockSymbolService.GetById(id);
            if (response.Data == null)
                return NoContent();

            return Ok(response.Data);
        }
        [HttpGet("stocksymbol/{exchangeId}")]//dunno about this ?
        public ActionResult<List<StockSymbolModel>> GetStockByExchangeId(int exchangeId)
        {
            if (exchangeId <= 0)
                return BadRequest();

            ServiceResponse<List<StockSymbolModel>> response = stockSymbolService.GetStockByExchangeId(exchangeId);
            if (response.Data.Count == 0)
                return NoContent();

            return Ok(response.Data);
        }

        [HttpPut]
        public ActionResult<StockSymbolModel> UpdateStockSymbol(StockSymbolModel stockSymbolModel)
        {
            if (stockSymbolModel.ID <= 0)
                return BadRequest();

            ServiceResponse<StockSymbolModel> response = stockSymbolService.UpdateStockSymbol(stockSymbolModel);
            if (response.Data == null)
                return NoContent();

            return Ok(response.Data);
        }

        [HttpPost]
        public ActionResult<StockSymbolModel> CreateExchange(StockSymbolModel stockSymbolModel)
        {
            if (stockSymbolModel.ID <= 0)
                return BadRequest();
            ServiceResponse<StockSymbolModel> response = stockSymbolService.InsertStockSymbol(stockSymbolModel);
            if (response.Data == null)
                return NoContent();

            return Ok(response.Data);
        }

        [HttpDelete("{id}")]
        public ActionResult<StockSymbolModel> DeleteStockSymbolById(int id)
        {
            if (id <= 0)
                return BadRequest();

            ServiceResponse<StockSymbolModel> response = stockSymbolService.DeleteById(id);
            if (response.Data == null)
                return NoContent();

            return Ok(response.Data);
        }
    }
}
