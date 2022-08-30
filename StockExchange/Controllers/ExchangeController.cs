namespace StockExchange.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StockExchange.BLL.Infrastructure.Interfaces;
    using StockExchange.DAL.DataModel;
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
        public ActionResult ListAllExchanges()
        {
            var response = exchangeService.GetAllExchanges();
            return Ok(response);
        }
        [HttpGet("Search for exchange by name")]
        public ActionResult<ServiceResponse<Exchange>> GetExchangeByName(string name)
        {
            var result = exchangeService.GetByName(name);

            return Ok(result);
        }
        //[HttpPut("Create an Exchange")]
        //public ActionResult CreateExchange(Exchange exchange)
        //{
        //    var response = exchangeService
        //}

    }
}
