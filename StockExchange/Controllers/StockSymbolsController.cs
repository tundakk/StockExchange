namespace StockExchange.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StockExchange.BLL.Infrastructure.Interfaces;
    using StockExchange.Domain.Model;
    using StockExchange.Domain.Model.Responses;

    /// <summary>
    /// Endpoints related to configuring stocksymbols.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StockSymbolsController : BaseApiController<StockSymbolsController>
    {
        private readonly IStockSymbolService stockSymbolService;

        /// <summary>
        /// Default constructor for StockSymbolsController.
        /// </summary>
        /// <param name="stockSymbolService"></param>
        /// <param name="logger"></param>
        public StockSymbolsController(
            IStockSymbolService stockSymbolService,
            ILogger<StockSymbolsController> logger) : base(logger)
        {
            this.stockSymbolService = stockSymbolService;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("name")]
        public ActionResult<StockSymbolModel> GetStockSymbolByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest();
            }

            ServiceResponse<StockSymbolModel> response = stockSymbolService.GetByName(name);

            if (!response.Success)
            {
                return Problem(); // Should i return something here?
            }

            if (response.Data == null)
            {
                return NoContent();
            }

            return Ok(response.Data);
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<StockSymbolModel>> GetAllStockSymbols()
        {
            ServiceResponse<IEnumerable<StockSymbolModel>> response = stockSymbolService.GetAllStockSymbols();

            if (!response.Success)
            {
                return Problem();
            }

            if (response.Data == null)
            {
                return NoContent();
            }

            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        public ActionResult<StockSymbolModel> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            ServiceResponse<StockSymbolModel> response = stockSymbolService.GetById(id);

            if (!response.Success)
            {
                return Problem(); // Should i return something here?
            }

            if (response.Data == null)
            {
                return NoContent();
            }

            return Ok(response.Data);
        }

        [HttpGet("stocksymbol/{exchangeId}")]
        public ActionResult<IEnumerable<StockSymbolModel>> GetStockByExchangeId(int exchangeId)
        {
            if (exchangeId <= 0)
            {
                return BadRequest();
            }

            ServiceResponse<IEnumerable<StockSymbolModel>> response = stockSymbolService.GetStockByExchangeId(exchangeId);

            if (!response.Success)
            {
                return Problem(); // Should i return something here?
            }

            if (response.Data == null)
            {
                return NoContent();
            }

            return Ok(response.Data);
        }

        [HttpPut]
        public ActionResult<StockSymbolModel> UpdateStockSymbol(StockSymbolModel stockSymbolModel)
        {
            if (stockSymbolModel.ID <= 0)
            {
                return BadRequest();
            }

            ServiceResponse<StockSymbolModel> response = stockSymbolService.UpdateStockSymbol(stockSymbolModel);

            if (!response.Success)
            {
                return Problem(); // Should i return something here?
            }

            if (response.Data == null)
            {
                return NoContent();
            }

            return Ok(response.Data);
        }

        [HttpPost]
        public ActionResult<StockSymbolModel> CreateExchange(StockSymbolModel stockSymbolModel)
        {
            if (stockSymbolModel.ID <= 0)
            {
                return BadRequest();
            }

            ServiceResponse<StockSymbolModel> response = stockSymbolService.InsertStockSymbol(stockSymbolModel);

            if (!response.Success)
            {
                return Problem(); // Should i return something here?
            }

            if (response.Data == null)
            {
                return NoContent();
            }

            return Ok(response.Data);
        }

        [HttpDelete("{id}")]
        public ActionResult<StockSymbolModel> DeleteStockSymbolById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            ServiceResponse<StockSymbolModel> response = stockSymbolService.DeleteById(id);

            if (!response.Success)
            {
                return Problem(); // Should i return something here?
            }

            if (response.Data == null)
            {
                return NoContent();
            }

            return Ok(response.Data);
        }
    }
}
