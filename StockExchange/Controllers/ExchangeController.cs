namespace StockExchange.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StockExchange.BLL.Infrastructure.Interfaces;

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
        //[HttpPut("Create an Exchange")]
        //public ActionResult CreateExchange(Exchange exchange)
        //{
        //    var response = exchangeService
        //}

    }
}
