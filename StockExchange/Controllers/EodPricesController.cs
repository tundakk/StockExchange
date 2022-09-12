namespace StockExchange.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StockExchange.BLL.Infrastructure.Interfaces;
    using StockExchange.Domain.Model;
    using StockExchange.Domain.Model.Responses;

    /// <summary>
    /// Endpoints related to configuring ContentSources.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EodPricesController : BaseApiController<EodPricesController>
    {
        private readonly IEodPriceService eodPriceService;

        /// <summary>
        /// Default constructor for Eod Price controller.
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
        /// List of all Eod Prices.
        /// </summary>
        /// <returns></returns>
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

        [HttpGet("{id}")]
        public ActionResult<EodPriceModel> GetById(int id)
        {
            if (id <= 0)
                return BadRequest();

            ServiceResponse<EodPriceModel> response = eodPriceService.GetById(id);
            if (response.Data == null)
                return NoContent();
            if (!response.Success)
            {
                return Problem(); // Should i return something here?
            }

            return Ok(response.Data);
        }
        [HttpGet("{stockId}")]
        public ActionResult<List<EodPriceModel>> GetEodsByStockDate([FromRoute] int stockId, [FromQuery] DateTime? from, [FromQuery] DateTime? to)
        {
            if (stockId <= 0 || to.ToString() == "01-01-0001 00:00:00") //i am unsure if this works for every scenario or if its just swagger
                return BadRequest();

            if (to.ToString() == "01-01-0001 00:00:00") // i am unsure if this works for every scenario or if its just swagger
                return BadRequest();

            if (from.ToString() == "01-01-0001 00:00:00")
            {
                return BadRequest();

            }
            ServiceResponse<List<EodPriceModel>> response = eodPriceService.GetEodsByStockIdWhereDate(stockId, from, to);
            if (response.Data.Count == 0)
                return NoContent();

            return Ok(response.Data);
        }
        [HttpDelete("{id}")]
        public ActionResult<EodPriceModel> DeleteExchangeById(int id)
        {
            if (id <= 0)
                return BadRequest();

            ServiceResponse<EodPriceModel> response = eodPriceService.DeleteById(id);
            if (response.Data == null)
                return NoContent();

            return Ok(response.Data);
        }
        [HttpPut]
        public ActionResult<EodPriceModel> UpdateExchange(EodPriceModel eodPriceModel)
        {
            if (eodPriceModel.ID <= 0)
                return BadRequest();

            ServiceResponse<EodPriceModel> response = eodPriceService.UpdateEodPrice(eodPriceModel);
            if (response.Data == null)
                return NoContent();

            return Ok(response.Data);
        }
        [HttpPost]
        public ActionResult<EodPriceModel> CreateEodPrice(EodPriceModel eodPriceModel)
        {
            if (eodPriceModel.ID <= 0)
                return BadRequest();

            ServiceResponse<EodPriceModel> response = eodPriceService.InsertEodPrice(eodPriceModel);
            if (response.Data == null)
                return NoContent();

            return Ok(response.Data);
        }
    }
}
