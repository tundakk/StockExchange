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
        [HttpGet("Get exchange by ID")]
        public ActionResult<ExchangeModel> GetExchangeById(int id)
        {
            var result = exchangeService.GetExchangeById(id);

            return Ok(result);
        }
        [HttpDelete("Delete exchange")]
        public void DeleteExchangeById(int id)
        {
            exchangeService.DeleteById(id);
        }
        [HttpPut("Update an exchange")]
        public void UpdateExchange(ExchangeModel exchangeModel)
        {
            exchangeService.UpdateExchange(exchangeModel);
        }
        [HttpPost("Create an exchange")]
        public void CreateExchange(ExchangeModel exchangeModel)
        {
            exchangeService.InsertExchange(exchangeModel);
        }

    }
}
