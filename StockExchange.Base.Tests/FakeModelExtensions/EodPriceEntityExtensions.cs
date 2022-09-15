namespace StockExchange.Base.Tests.FakeModelExtensions
{
    using System.Collections.Generic;
    using StockExchange.DAL.DataModel;

    /// <summary>
    /// EodPrice entity extensions class.
    /// </summary>
    public static class EodPriceEntityExtensions
    {
        /// <summary>
        /// Builds a list of EodPrice.
        /// </summary>
        /// <returns>Returns a mock list of EodPrice objects.</returns>
        public static IEnumerable<EodPrice> BuildList()
        {
            return new List<EodPrice>
            {
                Build(),
                new EodPrice
                {
                    ID = 12,
                    Date = new System.DateTime(2021, 12, 15, 23, 22, 11),
                    ClosePrice = 10m,
                    StockSymbol = new StockSymbol
                    {
                        ID = 34,
                        CompanyName = "Dummy Company",
                        Ticker = new System.DateTime(2020, 1, 16, 0, 23, 12),
                        IsActive = false,
                        ExchangeId = 52,
                    },
                    StockSymbolId = 1,
                },

                new EodPrice
                {
                    ID = 13,
                    Date = new System.DateTime(2021, 10, 14, 20, 10, 21),
                    ClosePrice = 10.14m,
                    StockSymbol = new StockSymbol
                    {
                        ID = 61,
                        CompanyName = "Straton Oakmount",
                        Ticker = new System.DateTime(2019, 2, 17, 1, 24, 13),
                        IsActive = true,
                        ExchangeId = 23,
                    },
                    StockSymbolId = 2,
                },
            };
        }

        /// <summary>
        /// Builds a EodPrice object.
        /// </summary>
        /// <returns>Returns a mock EodPrice object.</returns>
        public static EodPrice Build()
        {
            return new EodPrice
            {
                ID = 31,
                Date = new System.DateTime(2019, 3, 13, 2, 14, 21),
                ClosePrice = 20.14m,
                StockSymbol = new StockSymbol
                {
                    ID = 51,
                    CompanyName = "Dunder Mifflin Paper Company",
                    Ticker = new System.DateTime(2017, 3, 4, 5, 6, 7),
                    IsActive = true,
                    ExchangeId = 63,
                },
                StockSymbolId = 3,
            };
        }
    }
}
