namespace StockExchange.BLL.Infrastructure.Services
{
    using Microsoft.Extensions.Logging;
    using StockExchange.BLL.Conversions;
    using StockExchange.BLL.Infrastructure.Interfaces;
    using StockExchange.DAL.DataModel;
    using StockExchange.DAL.Repos.Interface;
    using StockExchange.Domain.Model;
    using StockExchange.Domain.Model.Responses;
    using System;
    using System.Collections.Generic;

    public class EodPriceService : BaseService<EodPriceService>, IEodPriceService
    {
        private readonly IEodPriceRepo eodPriceRepo;
        public EodPriceService(IEodPriceRepo eodPriceRepo, ILogger<EodPriceService> logger) : base(logger)
        {
            this.eodPriceRepo = eodPriceRepo;
        }
        //GET
        public ServiceResponse<List<EodPriceModel>> GetAllEodPrices()
        {
            List<EodPrice> eodPrice = eodPriceRepo.GetAll().ToList();

            if (eodPrice == null)//should i check on DAL model or domain model?
            {
                return new ServiceResponse<List<EodPriceModel>>()
                {
                    Success = false,
                    Message = "No data from database"
                };
            }

            return new ServiceResponse<List<EodPriceModel>>()
            {
                Data = EodPriceConvert.DalToDomainListOfEod(eodPrice).ToList()
            };
        }

        public ServiceResponse<EodPriceModel> GetById(int id)
        {
            EodPrice eodPrice = eodPriceRepo.GetById(id);

            if (eodPrice == null)
            {
                return new ServiceResponse<EodPriceModel>()
                {
                    Success = false,
                    Message = "No object found. Null reference"
                };
            }
            return new ServiceResponse<EodPriceModel>()
            {
                Data = EodPriceConvert.DalToDomainEodPrice(eodPrice)
            };
        }
        public ServiceResponse<List<EodPriceModel>> GetEodsByStockIdWhereDate(int stockId, DateTime from, DateTime to)
        {
            List<EodPrice> eodPrices = eodPriceRepo.GetByStockExchangeIdAndDate(stockId, from, to).ToList();

            if (eodPrices == null)
            {
                return new ServiceResponse<List<EodPriceModel>>()
                {
                    Success = false,
                    Message = "No object found. Null reference"
                };
            }
            return new ServiceResponse<List<EodPriceModel>>()
            {
                Data = EodPriceConvert.DalToDomainListOfEod(eodPrices).ToList()
            };
        }
        // POST
        public ServiceResponse<EodPriceModel> InsertEodPrice(EodPriceModel eodPriceModel) //should this return a bool?
        {
            EodPrice eodPrice = EodPriceConvert.DomainToDalEodPrice(eodPriceModel);
            if (eodPrice == null)
            {
                return new ServiceResponse<EodPriceModel>()
                {
                    Success = false,
                    Message = "No object found. Null reference"
                };
            }
            EodPrice ResponseEodPrice = eodPriceRepo.Insert(eodPrice);
            eodPriceRepo.Save();
            return new ServiceResponse<EodPriceModel>()
            {
                Data = EodPriceConvert.DalToDomainEodPrice(ResponseEodPrice)
            };
        }
        // UPDATE
        public ServiceResponse<EodPriceModel> UpdateEodPrice(EodPriceModel eodPriceModel)
        {
            EodPrice eodPrice = EodPriceConvert.DomainToDalEodPrice(eodPriceModel);

            if (eodPrice == null)
            {
                return new ServiceResponse<EodPriceModel>()
                {
                    Success = false,
                    Message = "No object found. Null reference"
                };
            }
            EodPrice ResponseEodPrice = eodPriceRepo.Update(eodPrice);

            eodPriceRepo.Save();

            return new ServiceResponse<EodPriceModel>()
            {
                Data = EodPriceConvert.DalToDomainEodPrice(ResponseEodPrice)
            };
        }
        // DELETE
        public ServiceResponse<EodPriceModel> DeleteById(int id)
        {
            EodPrice eodPrice = eodPriceRepo.GetById(id);

            if (eodPrice == null)
            {
                return new ServiceResponse<EodPriceModel>()
                {
                    Success = false,
                    Message = $"No object found with ID: {id}"
                };
            }
            EodPrice ResponseEodPrice = eodPriceRepo.Delete(eodPrice);
            eodPriceRepo.Save();

            return new ServiceResponse<EodPriceModel>()
            {
                Data = EodPriceConvert.DalToDomainEodPrice(ResponseEodPrice)
            };
        }
    }
}
