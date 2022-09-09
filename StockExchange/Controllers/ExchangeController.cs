namespace StockExchange.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StockExchange.BLL.Infrastructure.Interfaces;
    using StockExchange.Domain.Model;
    using StockExchange.Domain.Model.Responses;

    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController : BaseApiController<ExchangeController>
    {
        private readonly IExchangeService exchangeService;
        public ExchangeController(IExchangeService exchangeService, ILogger<ExchangeController> logger) : base(logger)
        {
            this.exchangeService = exchangeService;
        }
        [HttpGet("GetAllExchanges")]
        public ActionResult<List<ExchangeModel>> ListAllExchanges()
        {
            ServiceResponse<List<ExchangeModel>> response = exchangeService.GetAllExchanges();
            if (response.Data.Count == 0)
                return NotFound();

            return Ok(response.Data);
        }
        [HttpGet("Search for exchange by name")]
        public ActionResult<ExchangeModel> GetExchangeByName(string name)
        {
            if (String.IsNullOrEmpty(name))
                return BadRequest();

            ServiceResponse<ExchangeModel> response = exchangeService.GetByName(name);
            if (response.Data == null)
                return NotFound();

            return Ok(response);
        }

        [HttpGet("Get exchange by ID")]
        public ActionResult<ExchangeModel> GetExchangeById(int id)
        {
            if (id == 0)
                return BadRequest();

            ServiceResponse<ExchangeModel> response = exchangeService.GetExchangeById(id);
            if (response.Data == null)
                return NotFound();

            return Ok(response.Data);
        }
        [HttpDelete("Delete exchange")]
        public ActionResult<ExchangeModel> DeleteExchangeById(int id)
        {
            if (id == 0)
                return BadRequest();

            ServiceResponse<ExchangeModel> response = exchangeService.DeleteById(id);
            if (response.Data == null)
                return NotFound();

            return Ok(response.Data);
        }
        [HttpPut("Update an exchange")]
        public ActionResult<ExchangeModel> UpdateExchange(ExchangeModel exchangeModel)
        {
            if (exchangeModel.ID == 0)
                return BadRequest();

            ServiceResponse<ExchangeModel> response = exchangeService.UpdateExchange(exchangeModel);
            if (response.Data == null)
                return NotFound();

            return Ok(response.Data);
        }
        [HttpPost("Create an exchange")]
        public ActionResult<ExchangeModel> CreateExchange(ExchangeModel exchangeModel)
        {
            if (exchangeModel.ID == 0)
                return BadRequest();

            ServiceResponse<ExchangeModel> response = exchangeService.InsertExchange(exchangeModel);
            if (response.Data == null)
                return NotFound();

            return Ok(response.Data);
        }

    }
}
