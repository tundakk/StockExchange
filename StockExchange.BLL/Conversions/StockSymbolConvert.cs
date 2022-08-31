namespace StockExchange.BLL.Conversions
{
    using StockExchange.DAL.DataModel;
    using StockExchange.Domain.Model;

    public static class StockSymbolConvert
    {
        /// <summary>
        /// Conversion from DAL layer model of StockSymbol to domain layer model
        /// </summary>
        /// <param name="stockSymbol"></param>
        /// <returns></returns>
        public static StockSymbolModel DalToDomainStockSymbol(StockSymbol stockSymbol)
        {
            StockSymbolModel responseModel = new StockSymbolModel()
            {
                ID = stockSymbol.ID,
                CompanyName = stockSymbol.CompanyName,
                Ticker = stockSymbol.Ticker,
                IsActive = stockSymbol.IsActive,
                ExchangeId = stockSymbol.ExchangeId,
                EodPrices = EodPriceConvert.DalToDomainListOfEod(stockSymbol.EodPrices.ToList()),
            };
            return responseModel;
        }

        public static ICollection<StockSymbolModel> DalToDomainListOfStock(List<StockSymbol> stockSymbol)
        {

            List<StockSymbolModel> responseModel = new List<StockSymbolModel>();

            foreach (var item in stockSymbol)
            {
                responseModel.Add(DalToDomainStockSymbol(item));
            };
            return responseModel.ToList();
        }
        public static List<StockSymbol> DomainToDalListOfStock(List<StockSymbolModel> stockSymbolModel)
        {
            List<StockSymbol> responseModel = new List<StockSymbol>();

            foreach (var item in stockSymbolModel)
            {
                responseModel.Add(DomainToDalStockSymbol(item));
            };
            return responseModel.ToList();
        }
        public static StockSymbol DomainToDalStockSymbol(StockSymbolModel stockSymbolModel)
        {
            StockSymbol responseModel = new StockSymbol()
            {
                ID = stockSymbolModel.ID,
                CompanyName = stockSymbolModel.CompanyName,
                Ticker = stockSymbolModel.Ticker,
                IsActive = stockSymbolModel.IsActive,
                ExchangeId = stockSymbolModel.ExchangeId,
                EodPrices = EodPriceConvert.DomainToDalListOfEod(stockSymbolModel.EodPrices.ToList()),
            };
            return responseModel;
        }
    }
}


