namespace StockExchange.Base.Tests.FakeModelExtensions
{
    using System.Collections.Generic;
    using StockExchange.DAL.DataModel;

    /// <summary>
    /// StockSymbol entity extensions class.
    /// </summary>
    public static class StockSymbolEntityExtensions
    {
        /// <summary>
        /// Builds a list of StockSymbol.
        /// </summary>
        /// <returns>Returns a mock list of StockSymbol objects.</returns>
        public static IEnumerable<StockSymbol> BuildList()
        {
            return new List<StockSymbol>
            {
                Build(),
                new StockSymbol
                {
                    ID = 21,
                    CompanyName = "Straton Oakmount",
                    Ticker = new System.DateTime(2017, 5, 6, 7, 8, 9),
                    IsActive = false,
                    ExchangeId = 14,
                },
                new StockSymbol
                {
                    ID = 51,
                    CompanyName = "Apple",
                    Ticker = new System.DateTime(2017, 2, 3, 4, 5, 4),
                    IsActive = true,
                    ExchangeId = 28,
                },
                new StockSymbol
                {
                    ID = 25,
                    CompanyName = "Alphabet",
                    Ticker = new System.DateTime(2017, 10, 10, 10, 10, 7),
                    IsActive = true,
                    ExchangeId = 61,
                },
            };
        }

        /// <summary>
        /// Builds a StockSymbol object.
        /// </summary>
        /// <returns>Returns a mock StockSymbol object.</returns>
        public static StockSymbol Build()
        {
            return new StockSymbol
            {
                ID = 21,
                CompanyName = "Straton Oakmount",
                Ticker = new System.DateTime(2017, 5, 6, 7, 8, 9),
                IsActive = false,
                ExchangeId = 14,
            };
        }
    }
}
