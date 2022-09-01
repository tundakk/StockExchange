namespace StockExchange.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StockExchange.BLL.Infrastructure.Interfaces;
    using StockExchange.Domain.Model;

    [Route("api/[controller]")]
    [ApiController]
    public class EodPriceController : ControllerBase
    {
        private readonly IEodPriceService eodPriceService;
        public EodPriceController(IEodPriceService eodPriceService)
        {
            this.eodPriceService = eodPriceService;
        }
        [HttpGet("Get all EOD prices")]
        public ActionResult<List<EodPriceModel>> ListAllEodPrices()
        {
            var response = eodPriceService.GetAllEodPrices();
            return Ok(response);
        }
        //[HttpGet("Search for exchange by date")]
        //public ActionResult<ServiceResponse<EodPriceModel>> GetEodPriceByDate(DateTime date)
        //{
        //    var result = eodPriceService.GetByDate(date);

        //    return Ok(result);
        //}
        [HttpGet("Get EodPrice by ID")]
        public ActionResult<EodPriceModel> GetById(int id)
        {
            var result = eodPriceService.GetById(id);

            return Ok(result);
        }
        [HttpDelete("Delete eod price")]
        public void DeleteExchangeById(int id)
        {
            eodPriceService.DeleteById(id);
        }
        [HttpPut("Update an eod price")]
        public void UpdateExchange(EodPriceModel eodPriceModel)
        {
            eodPriceService.UpdateEodPrice(eodPriceModel);
        }
        [HttpPost("Create an eod price")]
        public void CreateEodPrice(EodPriceModel eodPriceModel)
        {
            eodPriceService.InsertEodPrice(eodPriceModel);
        }
    }
}
