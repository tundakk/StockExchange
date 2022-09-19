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

        /// <summary>
        /// It gets a IEnumerable of all the EodPriceModel in the system.
        /// </summary>
        /// <returns> Returns an IEnumerable of populated EodPriceModel.</returns>
        public ServiceResponse<IEnumerable<EodPriceModel>> GetAll()
        {
            IEnumerable<EodPrice> eodPrice = eodPriceRepo.GetAll();

            if (eodPrice == null)
            {
                return new ServiceResponse<IEnumerable<EodPriceModel>>()
                {
                    Success = false,
                    Message = "No data from database",
                };
            }

            if (!eodPrice.Any())
            {
                return new ServiceResponse<IEnumerable<EodPriceModel>>()
                {
                    Success = false,
                    Message = "An empty list was returned",
                };
            }

            return new ServiceResponse<IEnumerable<EodPriceModel>>()
            {
                Data = mapper.Map<IEnumerable<EodPriceModel>>(eodPrice),
            };
        }

        /// <summary>
        /// It gets a particular EodPriceModel available in the system.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A populated EodPriceModel object.</returns>
        public ServiceResponse<EodPriceModel> GetById(int id)
        {
            if (id <= 0)
            {
                return new ServiceResponse<EodPriceModel>()
                {
                    Success = false,
                    Message = "The id cannot be 0 or less",
                };
            }

            EodPrice eodPrice;
            try
            {
                eodPrice = eodPriceRepo.GetById(id);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<EodPriceModel>()
                {
                    Success = false,
                    Message = ex.Message,
                };
            }

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
        /// It gets a list of EodPriceModel by id, from a range of dates.
        /// </summary>
        /// <param name="stockId">StockSymbolId.</param>
        /// <param name="from">From a specific date.</param>
        /// <param name="to">To a specific date.</param>
        /// <returns>A list of populated EodPriceModel. </returns>
        public ServiceResponse<IEnumerable<EodPriceModel>> GetEodsByStockIdWhereDate(int stockId, DateTime? from, DateTime? to)
        {
            if (stockId <= 0)
            {
                return new ServiceResponse<IEnumerable<EodPriceModel>>()
                {
                    Success = false,
                    Message = "The stockId cannot be 0 or less",
                };
            }

            if (from == null)
            {
                return new ServiceResponse<IEnumerable<EodPriceModel>>()
                {
                    Success = false,
                    Message = "The date 'from' cannot be null",
                };
            }

            if (to == null)
            {
                return new ServiceResponse<IEnumerable<EodPriceModel>>()
                {
                    Success = false,
                    Message = "The date 'to' cannot be null",
                };
            }

            IEnumerable<EodPrice> eodPrices;

            try
            {
                eodPrices = eodPriceRepo.GetByStockIdAndDate(stockId, from, to);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<EodPriceModel>>()
                {
                    Success = false,
                    Message = ex.Message,
                };
            }

            if (eodPrices == null)
            {
                return new ServiceResponse<IEnumerable<EodPriceModel>>()
                {
                    Success = false,
                    Message = "No object found. Null reference",
                };
            }

            if (!eodPrices.Any())
            {
                return new ServiceResponse<IEnumerable<EodPriceModel>>()
                {
                    Success = false,
                    Message = "No objects found in that date range",
                };
            }

            return new ServiceResponse<IEnumerable<EodPriceModel>>()
            {
                Data = mapper.Map<IEnumerable<EodPriceModel>>(eodPrices),
            };
        }

        // POST

        /// <summary>
        /// It inserts a particular EodPriceModel object.
        /// </summary>
        /// <param name="eodPriceModel"></param>
        /// <returns>returns a populated EodPriceModel object.</returns>
        public ServiceResponse<EodPriceModel> Insert(EodPriceModel eodPriceModel) // should this return a bool?
        {
            if (eodPriceModel == null)
            {
                return new ServiceResponse<EodPriceModel>()
                {
                    Success = false,
                    Message = "eodPriceModel object cannot be null",
                };
            }

            EodPrice eodPrice;

            try
            {
                eodPrice = mapper.Map<EodPrice>(eodPriceModel);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<EodPriceModel>()
                {
                    Success = false,
                    Message = ex.Message,
                };
            }

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
        /// It updates a particular EodPriceModel object.
        /// </summary>
        /// <param name="eodPriceModel"></param>
        /// <returns>Returns the update EodPriceModel object.</returns>
        public ServiceResponse<EodPriceModel> Update(EodPriceModel eodPriceModel)
        {
            if (eodPriceModel == null)
            {
                return new ServiceResponse<EodPriceModel>()
                {
                    Success = false,
                    Message = "eodPriceModel object cannot be null",
                };
            }

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
        /// It deletes a particular EodPriceModel object by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the deleted EodPriceModel object.</returns>
        public ServiceResponse<EodPriceModel> Delete(int id)
        {
            if (id <= 0)
            {
                return new ServiceResponse<EodPriceModel>()
                {
                    Success = false,
                    Message = "The id cannot be 0 or less",
                };
            }

            EodPrice? eodPrice;

            try
            {
                eodPrice = eodPriceRepo.GetById(id);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<EodPriceModel>()
                {
                    Success = false,
                    Message = ex.Message,
                };
            }

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
