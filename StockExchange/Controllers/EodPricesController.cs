namespace StockExchange.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StockExchange.BLL.Infrastructure.Interfaces;
    using StockExchange.Domain.Model;
    using StockExchange.Domain.Model.Responses;

    /// <summary>
    /// Endpoints related to configuring Eod Prices.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EodPricesController : BaseApiController<EodPricesController>
    {
        private readonly IEodPriceService eodPriceService;

        /// <summary>
        /// Default constructor for EodPricesController.
        /// </summary>
        /// <param name="eodPriceService"></param>
        /// <param name="logger"></param>
        public EodPricesController(
            IEodPriceService eodPriceService,
            ILogger<EodPricesController> logger) : base(logger)
        {
            this.eodPriceService = eodPriceService;
        }

        /// <summary>
        /// Get all EodPriceModel objects from database.
        /// </summary>
        /// <returns>Returns a list of all EodPriceModel objects.</returns>
        [HttpGet("")]
        public ActionResult<IEnumerable<EodPriceModel>> ListAllEodPrices()
        {
            ServiceResponse<IEnumerable<EodPriceModel>> response = eodPriceService.GetAllEodPrices();

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
        /// Gets an EodPriceModel object.
        /// </summary>
        /// <param name="id">id of an EodPriceModel object.</param>
        /// <returns>Returns a populated EodPriceModel object.</returns>
        [HttpGet("{id}")]
        public ActionResult<EodPriceModel> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            ServiceResponse<EodPriceModel> response = eodPriceService.GetById(id);

            if (response.Data == null)
            {
                return NoContent();
            }

            if (!response.Success)
            {
                return Problem(); // Should i return something here?
            }

            return Ok(response.Data);
        }

        /// <summary>
        /// Gets a list of eodprice by stockid, from a range of dates.
        /// </summary>
        /// <param name="stockId"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns>Returns a populated list of EodPriceModel objects.</returns>
        [HttpGet("bystockid/{stockId}")]
        public ActionResult<IEnumerable<EodPriceModel>> GetEodsByStockDate([FromRoute] int stockId, [FromQuery] DateTime? from, [FromQuery] DateTime? to)
        {
            if (stockId <= 0 || to.ToString() == "01-01-0001 00:00:00")
            {
                return BadRequest();
            }

            // should these be null?

            if (to.ToString() == "01-01-0001 00:00:00")
            {
                return BadRequest(to);
            }

            if (from.ToString() == "01-01-0001 00:00:00")
            {
                return BadRequest(from);
            }

            ServiceResponse<IEnumerable<EodPriceModel>> response = eodPriceService.GetEodsByStockIdWhereDate(stockId, from, to);

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
        /// Deletes a EodPriceModel object by its ID.
        /// </summary>
        /// <param name="id">The id of EodPriceModel object.</param>
        /// <returns>Returns a EodPriceModel object of the deleted entity.</returns>
        [HttpDelete("{id}")]
        public ActionResult<EodPriceModel> DeleteExchangeById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            ServiceResponse<EodPriceModel> response = eodPriceService.DeleteById(id);

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
        /// Updates an EodPriceModel object.
        /// </summary>
        /// <param name="eodPriceModel"></param>
        /// <returns>Returns the updated EodPriceModel object.</returns>
        [HttpPut]
        public ActionResult<EodPriceModel> UpdateExchange(EodPriceModel eodPriceModel)
        {
            if (eodPriceModel.ID <= 0)
            {
                return BadRequest();
            }

            ServiceResponse<EodPriceModel> response = eodPriceService.UpdateEodPrice(eodPriceModel);

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
        /// Creates an EodPriceModel object.
        /// </summary>
        /// <param name="eodPriceModel"></param>
        /// <returns>Returns the created EodPriceModel object.</returns>
        [HttpPost]
        public ActionResult<EodPriceModel> CreateEodPrice(EodPriceModel eodPriceModel)
        {
            if (eodPriceModel.ID <= 0)
            {
                return BadRequest();
            }

            ServiceResponse<EodPriceModel> response = eodPriceService.InsertEodPrice(eodPriceModel);

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
