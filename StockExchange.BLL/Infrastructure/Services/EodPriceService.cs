namespace StockExchange.BLL.Infrastructure.Services
{
    using StockExchange.BLL.Conversions;
    using StockExchange.BLL.Infrastructure.Interfaces;
    using StockExchange.DAL.DataModel;
    using StockExchange.DAL.Repos.Interface;
    using StockExchange.Domain.Model;
    using System;
    using System.Collections.Generic;

    public class EodPriceService : IEodPriceService
    {
        private readonly IEodPriceRepo eodPriceRepo;
        public EodPriceService(IEodPriceRepo eodPriceRepo)
        {
            this.eodPriceRepo = eodPriceRepo;
        }
        //GET
        public EodPriceModel GetById(int id)
        {
            EodPrice EodPrice = eodPriceRepo.GetById(id);

            EodPriceModel responseModel = EodPriceConvert.DalToDomainEodPrice(EodPrice);

            return responseModel;
        }
        public List<EodPriceModel> GetEodsByStockIdWhereDate(int stockId, DateTime from, DateTime to)
        {
            List<EodPrice> eodPrices = eodPriceRepo.GetByStockId(stockId, from, to).ToList();

            ICollection<EodPriceModel> responseModel = EodPriceConvert.DalToDomainListOfEod(eodPrices);

            return responseModel.ToList();
        }
        // POST
        public void InsertEodPrice(EodPriceModel eodPriceModel) //should this return a bool?
        {
            EodPrice eodPrice = EodPriceConvert.DomainToDalEodPrice(eodPriceModel);

            eodPriceRepo.Insert(eodPrice);
            eodPriceRepo.Save();

        }
        // UPDATE
        public void UpdateEodPrice(EodPriceModel eodPriceModel)
        {
            EodPrice eodPrice = EodPriceConvert.DomainToDalEodPrice(eodPriceModel);

            eodPriceRepo.Update(eodPrice);
            eodPriceRepo.Save();
        }
        // DELETE
        public bool DeleteById(int id)
        {
            EodPrice eodPrice = eodPriceRepo.GetById(id);
            if (eodPrice == null)
            {
                return false;
            }
            eodPriceRepo.Delete(eodPrice);
            eodPriceRepo.Save();
            return true;
        }

        public List<EodPriceModel> GetAllEodPrices()
        {
            List<EodPrice> eodPrice = eodPriceRepo.GetAll().ToList();

            //conversion from DAL model to DOMAIN model
            ICollection<EodPriceModel> responseModel = EodPriceConvert.DalToDomainListOfEod(eodPrice);

            return responseModel.ToList();
        }



        //public ServiceResponse<EodPriceModel> GetEodByDate(DateTime date)
        //{
        //    EodPrice eodPrice = eodPriceRepo.GetByDate(date);
        //    ServiceResponse<EodPriceModel> responseModel = new ServiceResponse<EodPriceModel>();

        //    if (eodPrice == null)//should i check on DAL model or domain model?
        //    {
        //        return new ServiceResponse<EodPriceModel>()
        //        {
        //            Success = false,
        //            Message = "An Exchange with that name wasn't found"
        //        };
        //    }
        //    return new ServiceResponse<EodPriceModel>()
        //    {
        //        Data = EodPriceConvert.DalToDomainEodPrice(eodPrice)
        //    };
        //}
    }
}
