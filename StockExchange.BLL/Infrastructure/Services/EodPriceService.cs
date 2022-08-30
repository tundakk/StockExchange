namespace StockExchange.BLL.Infrastructure.Services
{
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
        public bool Delete(int id)
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
        /// <summary>
        /// this does not feel smart. i should make the covnersion elsewhere in a generic method i can call.
        /// It also feels redundant to write it every conversion, especially when i have models in domain model.
        /// I dictate manually which properties that is passed, so why use DTO's?
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>        
        public EodPriceModel GetById(int id)
        {
            EodPrice EodPrice = eodPriceRepo.GetById(id);
            EodPriceModel responseModel = new EodPriceModel()
            {
                ID = EodPrice.ID,
                Date = EodPrice.Date,
                ClosePrice = EodPrice.ClosePrice,
                StockSymbolId = EodPrice.StockSymbolId
            };
            return responseModel;
        }
    }
}
