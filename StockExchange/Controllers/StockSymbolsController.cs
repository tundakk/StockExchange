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
        /// Get a StockSymbol object by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Returns a populated StockSymbol object.</returns>
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

        /// <summary>
        /// Get all StockSymbolModel objects from database.
        /// </summary>
        /// <returns>Returns ba list of all StockSymbolModel objects.</returns>
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

        /// <summary>
        /// Gets an StockSymbolModel object.
        /// </summary>
        /// <param name="id">id of an StockSymbolModel object.</param>
        /// <returns>Returns a populated StockSymbolModel object.</returns>
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

        /// <summary>
        /// Get a list of StockSymbolModel objects.
        /// </summary>
        /// <param name="exchangeId">Parent Id of a StockSymbolModel object.</param>
        /// <returns>Returns a list of StockSymbolModel objects of exchangeId.</returns>
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

        /// <summary>
        /// Updates an StockSymbolModel object.
        /// </summary>
        /// <param name="stockSymbolModel"></param>
        /// <returns>Returns the updated StockSymbolModel object.</returns>
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

        /// <summary>
        /// Creates a StockSymbolModel object.
        /// </summary>
        /// <param name="stockSymbolModel"></param>
        /// <returns>Returns the created StockSymbolModel object.</returns>
        [HttpPost]
        public ActionResult<StockSymbolModel> CreateStockSymbol(StockSymbolModel stockSymbolModel)
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

        /// <summary>
        /// Deletes a StockSymbolModel object by its ID.
        /// </summary>
        /// <param name="id">The id of StockSymbolModel object.</param>
        /// <returns>Returns a StockSymbolModel object of the deleted entity.</returns>
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
