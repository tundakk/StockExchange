namespace StockExchange.BLL.Infrastructure.Services
{
    using StockExchange.BLL.Conversions;
    using StockExchange.BLL.Infrastructure.Interfaces;
    using StockExchange.DAL.DataModel;
    using StockExchange.DAL.Repos.Interface;
    using StockExchange.Domain.Model;

    public class EodPriceService : IEodPriceService
    {
        private readonly IEodPriceRepo eodPriceRepo;
        public EodPriceService(IEodPriceRepo eodPriceRepo)
        {
            this.eodPriceRepo = eodPriceRepo;
        }

        public EodPriceModel GetById(int id)
        {
            EodPrice EodPrice = eodPriceRepo.GetById(id);

            EodPriceModel responseModel = EodPriceConvert.DalToDomainEodPrice(EodPrice);

            return responseModel;
        }
        // POST
        public void InsertEodPrice(EodPriceModel eodPriceModel) //should this return a bool?
        {
            EodPrice eodPrice = EodPriceConvert.DomainToDalEodPrice(eodPriceModel);

            eodPriceRepo.Insert(eodPrice);
        }
        // UPDATE
        public void UpdateEodPrice(EodPriceModel eodPriceModel)
        {
            EodPrice eodPrice = EodPriceConvert.DomainToDalEodPrice(eodPriceModel);

            eodPriceRepo.Update(eodPrice);
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
    }
}
