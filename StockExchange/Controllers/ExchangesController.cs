﻿namespace StockExchange.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StockExchange.BLL.Infrastructure.Interfaces;
    using StockExchange.Domain.Model;
    using StockExchange.Domain.Model.Responses;

    /// <summary>
    /// Endpoints related to configuring exchanges.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangesController : BaseApiController<ExchangesController>
    {
        private readonly IExchangeService exchangeService;

        /// <summary>
        /// Default constructor for ExchangesController.
        /// </summary>
        /// <param name="exchangeService"></param>
        /// <param name="logger"></param>
        public ExchangesController(
            IExchangeService exchangeService,
            ILogger<ExchangesController> logger) : base(logger)
        {
            this.exchangeService = exchangeService;
        }

        /// <summary>
        /// Get all exchanges from database.
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public ActionResult<IEnumerable<ExchangeModel>> ListAllExchanges()
        {
            ServiceResponse<IEnumerable<ExchangeModel>> response = exchangeService.GetAllExchanges();

            if (!response.Success)
            {
                Problem();
            }

            if (response.Data == null)
            {
                return NoContent();
            }

            return Ok(response.Data);
        }

        /// <summary>
        /// Get all exchanges by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("name")]
        public ActionResult<ExchangeModel> GetExchangeByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest();
            }

            ServiceResponse<ExchangeModel> response = exchangeService.GetByName(name);

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
        public ActionResult<ExchangeModel> GetExchangeById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            ServiceResponse<ExchangeModel> response = exchangeService.GetById(id);

            if (!response.Success)
            {
                Problem();
            }

            if (response.Data == null)
            {
                return NoContent();
            }

            return Ok(response.Data);
        }

        /// <summary>
        /// Deletes a Exchange by its ID.
        /// </summary>
        /// <param name="id">The id of Exchange</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult<ExchangeModel> DeleteExchangeById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            ServiceResponse<ExchangeModel> response = exchangeService.DeleteById(id);

            if (!response.Success)
            {
                Problem();
            }

            if (response.Data == null)
            {
                return NoContent();
            }

            return Ok(response.Data);
        }

        [HttpPut]
        public ActionResult<ExchangeModel> UpdateExchange(ExchangeModel exchangeModel)
        {
            if (exchangeModel.ID <= 0)
            {
                return BadRequest();
            }

            ServiceResponse<ExchangeModel> response = exchangeService.UpdateExchange(exchangeModel);

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

        [HttpPost]
        public ActionResult<ExchangeModel> CreateExchange(ExchangeModel exchangeModel)
        {
            if (exchangeModel.ID <= 0)
            {
                return BadRequest();
            }

            ServiceResponse<ExchangeModel> response = exchangeService.InsertExchange(exchangeModel);

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
