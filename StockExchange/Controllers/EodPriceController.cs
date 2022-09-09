namespace StockExchange.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StockExchange.BLL.Infrastructure.Interfaces;
    using StockExchange.Domain.Model;
    using StockExchange.Domain.Model.Responses;

    [Route("api/[controller]")]
    [ApiController]
    public class EodPriceController : BaseApiController<EodPriceController>
    {
        private readonly IEodPriceService eodPriceService;
        public EodPriceController(IEodPriceService eodPriceService, ILogger<EodPriceController> logger) : base(logger)
        {
            this.eodPriceService = eodPriceService;
        }
        [HttpGet("Get all EOD prices")]
        public ActionResult<List<EodPriceModel>> ListAllEodPrices()
        {
            ServiceResponse<List<EodPriceModel>> response = eodPriceService.GetAllEodPrices();
            if (response.Data.Count == 0)
                return NotFound();

            return Ok(response);
        }
        //[HttpGet("Search for exchange by date")]
        //public ActionResult<EodPriceModel> GetEodPriceByDate(DateTime date)
        //{
        //    var result = eodPriceService.GetByDate(date);

        //    return Ok(result);
        //}
        [HttpGet("Get EodPrice by ID")]
        public ActionResult<EodPriceModel> GetById(int id)
        {

            if (id == 0)
                return BadRequest();

            ServiceResponse<EodPriceModel> response = eodPriceService.GetById(id);
            if (response.Data == null)
                return NotFound();

            return Ok(response.Data);
        }
        [HttpGet("Return a list of all EODPrices for a given stocksymbol within a certain date range")]
        public ActionResult<List<EodPriceModel>> GetEodsByStockDate(int stockId, DateTime from, DateTime to)
        {
            if (stockId == 0 || from.ToString() == "01-01-0001 00:00:00" || to.ToString() == "01-01-0001 00:00:00") //i am unsure if this works for every scenario or if its just swagger
                return BadRequest();

            ServiceResponse<List<EodPriceModel>> response = eodPriceService.GetEodsByStockIdWhereDate(stockId, from, to);
            if (response.Data.Count == 0)
                return NotFound();

            return Ok(response.Data);
        }
        [HttpDelete("Delete eod price")]
        public ActionResult<EodPriceModel> DeleteExchangeById(int id)
        {
            if (id == 0)
                return BadRequest();

            ServiceResponse<EodPriceModel> response = eodPriceService.DeleteById(id);
            if (response.Data == null)
                return NotFound();

            return Ok(response.Data);
        }
        [HttpPut("Update an eod price")]
        public ActionResult<EodPriceModel> UpdateExchange(EodPriceModel eodPriceModel)
        {
            if (eodPriceModel.ID == 0)
                return BadRequest();

            ServiceResponse<EodPriceModel> response = eodPriceService.UpdateEodPrice(eodPriceModel);
            if (response.Data == null)
                return NotFound();

            return Ok(response.Data);
        }
        [HttpPost("Create an eod price")]
        public ActionResult<EodPriceModel> CreateEodPrice(EodPriceModel eodPriceModel)
        {
            if (eodPriceModel.ID == 0)
                return BadRequest();

            ServiceResponse<EodPriceModel> response = eodPriceService.InsertEodPrice(eodPriceModel);
            if (response.Data == null)
                return NotFound();

            return Ok(response.Data);
        }
    }
}
