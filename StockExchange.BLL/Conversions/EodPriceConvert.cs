namespace StockExchange.BLL.Conversions
{
    using StockExchange.DAL.DataModel;
    using StockExchange.Domain.Model;
    using System.Collections.Generic;

    public static class EodPriceConvert
    {
        public static ICollection<EodPriceModel> DalToDomainListOfEod(List<EodPrice> eodPrice)
        {
            List<EodPriceModel> responseModel = new List<EodPriceModel>();

            foreach (var item in eodPrice)
            {
                responseModel.Add(DalToDomainEodPrice(item));
            };
            return responseModel.ToList();
        }

        public static ICollection<EodPrice> DomainToDalListOfEod(List<EodPriceModel> eodPriceModel)
        {
            List<EodPrice> responseModel = new List<EodPrice>();

            foreach (var item in eodPriceModel)
            {
                responseModel.Add(DomainToDalEodPrice(item));
            };
            return responseModel.ToList();
        }
        public static EodPriceModel DalToDomainEodPrice(EodPrice eodPrice)
        {
            EodPriceModel responseModel = new EodPriceModel()
            {
                ID = eodPrice.ID,
                Date = eodPrice.Date,
                ClosePrice = eodPrice.ClosePrice,
                StockSymbolId = eodPrice.StockSymbolId,
                //stockSymbolModel = StockSymbolConvert.DalToDomainStockSymbol(eodPrice.stockSymbol)
            };
            return responseModel;
        }
        public static EodPrice DomainToDalEodPrice(EodPriceModel eodPriceModel)
        {
            EodPrice response = new EodPrice()
            {
                ID = eodPriceModel.ID,
                Date = eodPriceModel.Date,
                ClosePrice = eodPriceModel.ClosePrice,
                StockSymbolId = eodPriceModel.StockSymbolId,
                //stockSymbol = StockSymbolConvert.DomainToDalStockSymbol(eodPriceModel.stockSymbolModel)

            };
            return response;
        }
    }
}

