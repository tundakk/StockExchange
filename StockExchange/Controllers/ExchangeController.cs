namespace StockExchange.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StockExchange.BLL.Infrastructure.Interfaces;
    using StockExchange.Domain.Model;
    using StockExchange.Domain.Model.Responses;

    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController : ControllerBase
    {
        private readonly IExchangeService exchangeService;
        public ExchangeController(IExchangeService exchangeService)
        {
            this.exchangeService = exchangeService;
        }
        [HttpGet("GetAllExchanges")]
        public ActionResult<List<ExchangeModel>> ListAllExchanges()
        {
            var response = exchangeService.GetAllExchanges();
            return Ok(response);
        }
        [HttpGet("Search for exchange by name")]
        public ActionResult<ServiceResponse<ExchangeModel>> GetExchangeByName(string name)
        {
            var result = exchangeService.GetByName(name);

            return Ok(result);
        }
        [HttpGet("Get exchange ID")]
        public ActionResult<ExchangeModel> GetById(int id)
        {
            var result = exchangeService.GetById(id);

            return Ok(result);
        }
        //[HttpGet("Get exchange by ID")]
        //public ActionResult<ExchangeModel>
        [HttpDelete("Delete exchange")]
        public void DeleteExchangeById(int id)
        {
            exchangeService.DeleteById(id);
        }
    }
}
