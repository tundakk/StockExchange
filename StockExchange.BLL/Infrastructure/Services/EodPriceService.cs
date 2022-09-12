namespace StockExchange.BLL.Infrastructure.Services
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Microsoft.Extensions.Logging;
    using StockExchange.BLL.Infrastructure.Interfaces;
    using StockExchange.DAL.DataModel;
    using StockExchange.DAL.Repos.Interface;
    using StockExchange.Domain.Model;
    using StockExchange.Domain.Model.Responses;

    /// <summary>
    /// EodPrice Service.
    /// </summary>
    public class EodPriceService : BaseService<EodPriceService>, IEodPriceService
    {
        private readonly IEodPriceRepo eodPriceRepo;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="EodPriceService"/> class.
        /// </summary>
        /// <param name="eodPriceRepo"></param>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        public EodPriceService(IEodPriceRepo eodPriceRepo, IMapper mapper, ILogger<EodPriceService> logger) : base(logger)
        {
            this.eodPriceRepo = eodPriceRepo;
            this.mapper = mapper;
        }

        // GET

        /// <inheritdoc/>
        public ServiceResponse<IEnumerable<EodPriceModel>> GetAllEodPrices()
        {
            IEnumerable<EodPrice> eodPrice = eodPriceRepo.GetAll().ToList();

            if (eodPrice == null)
            {
                return new ServiceResponse<IEnumerable<EodPriceModel>>()
                {
                    Success = false,
                    Message = "No data from database",
                };
            }

            return new ServiceResponse<IEnumerable<EodPriceModel>>()
            {
                Data = mapper.Map<IEnumerable<EodPriceModel>>(eodPrice),
            };
        }

        /// <summary>
        /// testestes.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResponse<EodPriceModel> GetById(int id)
        {
            EodPrice eodPrice = eodPriceRepo.GetById(id);

            if (eodPrice == null)
            {
                return new ServiceResponse<EodPriceModel>()
                {
                    Success = false,
                    Message = "No object found. Null reference",
                };
            }

            return new ServiceResponse<EodPriceModel>()
            {
                Data = mapper.Map<EodPriceModel>(eodPrice),
            };
        }

        /// <summary>
        /// testestes.
        /// </summary>
        public ServiceResponse<IEnumerable<EodPriceModel>> GetEodsByStockIdWhereDate(int stockId, DateTime from, DateTime to)
        {
            List<EodPrice> eodPrices = eodPriceRepo.GetByStockExchangeIdAndDate(stockId, from, to).ToList();

            if (eodPrices == null)
            {
                return new ServiceResponse<IEnumerable<EodPriceModel>>()
                {
                    Success = false,
                    Message = "No object found. Null reference",
                };
            }

            return new ServiceResponse<IEnumerable<EodPriceModel>>()
            {
                Data = mapper.Map<IEnumerable<EodPriceModel>>(eodPrices),
            };
        }

        // POST

        public ServiceResponse<EodPriceModel> InsertEodPrice(EodPriceModel eodPriceModel) // should this return a bool?
        {
            EodPrice eodPrice = mapper.Map<EodPrice>(eodPriceModel);
            if (eodPrice == null)
            {
                return new ServiceResponse<EodPriceModel>()
                {
                    Success = false,
                    Message = "No object found. Null reference",
                };
            }

            EodPrice responseEodPrice = this.eodPriceRepo.Insert(eodPrice);
            this.eodPriceRepo.Save();
            return new ServiceResponse<EodPriceModel>()
            {
                Data = mapper.Map<EodPriceModel>(responseEodPrice),
            };
        }

        // UPDATE

        /// <summary>
        /// testestes.
        /// </summary>
        public ServiceResponse<EodPriceModel> UpdateEodPrice(EodPriceModel eodPriceModel)
        {
            EodPrice eodPrice = mapper.Map<EodPrice>(eodPriceModel);

            if (eodPrice == null)
            {
                return new ServiceResponse<EodPriceModel>()
                {
                    Success = false,
                    Message = "No object found. Null reference",
                };
            }

            EodPrice responseEodPrice = eodPriceRepo.Update(eodPrice);

            eodPriceRepo.Save();

            return new ServiceResponse<EodPriceModel>()
            {
                Data = mapper.Map<EodPriceModel>(responseEodPrice),
            };
        }

        // DELETE

        /// <summary>
        /// testestes.
        /// </summary>
        public ServiceResponse<EodPriceModel> DeleteById(int id)
        {
            EodPrice eodPrice = eodPriceRepo.GetById(id);

            if (eodPrice == null)
            {
                return new ServiceResponse<EodPriceModel>()
                {
                    Success = false,
                    Message = $"No object found with ID: {id}",
                };
            }

            EodPrice responseEodPrice = eodPriceRepo.Delete(eodPrice);
            eodPriceRepo.Save();

            return new ServiceResponse<EodPriceModel>()
            {
                Data = mapper.Map<EodPriceModel>(responseEodPrice),
            };
        }
    }
}
