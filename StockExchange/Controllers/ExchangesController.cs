namespace StockExchange.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StockExchange.BLL.Infrastructure.Interfaces;
    using StockExchange.Domain.Model;
    using StockExchange.Domain.Model.Responses;

    [Route("api/[controller]")]
    [ApiController]
    public class ExchangesController : BaseApiController<ExchangesController>
    {
        private readonly IExchangeService exchangeService;
        public ExchangesController(IExchangeService exchangeService, ILogger<ExchangesController> logger) : base(logger)
        {
            this.exchangeService = exchangeService;
        }
        [HttpGet("")]
        public ActionResult<List<ExchangeModel>> ListAllExchanges()
        {
            ServiceResponse<List<ExchangeModel>> response = exchangeService.GetAllExchanges();
            if (response.Data.Count == 0)
                return NoContent();

            return Ok(response.Data);
        }
        [HttpGet("name")] //dunno about this
        public ActionResult<ExchangeModel> GetExchangeByName(string name)
        {
            if (String.IsNullOrEmpty(name))
                return BadRequest();

            ServiceResponse<ExchangeModel> response = exchangeService.GetByName(name);
            if (response.Data == null)
                return NoContent();

            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        public ActionResult<ExchangeModel> GetExchangeById(int id)
        {
            if (id <= 0)
                return BadRequest();

            ServiceResponse<ExchangeModel> response = exchangeService.GetExchangeById(id);
            if (response.Data == null)
                return NoContent();

            return Ok(response.Data);
        }
        [HttpDelete("{id}")]
        public ActionResult<ExchangeModel> DeleteExchangeById(int id)
        {
            if (id <= 0)
                return BadRequest();

            ServiceResponse<ExchangeModel> response = exchangeService.DeleteById(id);
            if (response.Data == null)
                return NoContent();

            return Ok(response.Data);
        }
        [HttpPut]
        public ActionResult<ExchangeModel> UpdateExchange(ExchangeModel exchangeModel)
        {
            if (exchangeModel.ID <= 0)
                return BadRequest();

            ServiceResponse<ExchangeModel> response = exchangeService.UpdateExchange(exchangeModel);
            if (response.Data == null)
                return NoContent();

            return Ok(response.Data);
        }
        [HttpPost]
        public ActionResult<ExchangeModel> CreateExchange(ExchangeModel exchangeModel)
        {
            if (exchangeModel.ID <= 0)
                return BadRequest();

            ServiceResponse<ExchangeModel> response = exchangeService.InsertExchange(exchangeModel);
            if (response.Data == null)
                return NoContent();

            return Ok(response.Data);
        }

    }
}
