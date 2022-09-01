namespace StockExchange.BLL.Conversions
{
    using StockExchange.DAL.DataModel;
    using StockExchange.Domain.Model;

    public static class ExchangeConvert
    {
        public static ExchangeModel DalToDomainExchange(Exchange exchange)
        {
            ExchangeModel responseModel = new ExchangeModel()
            {
                ID = exchange.ID,
                Name = exchange.Name,
                IsActive = exchange.IsActive,
                //StockSymbols = StockSymbolConvert.DalToDomainListOfStock(exchange.StockSymbols.ToList())
            };

            return responseModel;
        }
        public static ICollection<ExchangeModel> DalToDomainListOfExchanges(List<Exchange> exchange)
        {
            List<ExchangeModel> responseModel = new List<ExchangeModel>();

            foreach (var item in exchange)
            {
                responseModel.Add(DalToDomainExchange(item));
            };
            return responseModel.ToList();
        }

        public static ICollection<Exchange> DomainToDalListOfExchanges(List<ExchangeModel> exchangeModel)
        {
            List<Exchange> response = new List<Exchange>();

            foreach (var item in exchangeModel)
            {
                response.Add(DomainToDalExchange(item));
            };
            return response.ToList();
        }

        public static Exchange DomainToDalExchange(ExchangeModel exchangeModel)
        {
            Exchange response = new Exchange()
            {
                ID = exchangeModel.ID,
                Name = exchangeModel.Name,
                IsActive = exchangeModel.IsActive,
                StockSymbols = StockSymbolConvert.DomainToDalListOfStock(exchangeModel.StockSymbols.ToList()),
            };
            return response;
        }
    }
}
