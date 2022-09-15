namespace StockExchange.Base.Tests.FakeModelExtensions
{
    using System.Collections.Generic;
    using StockExchange.DAL.DataModel;

    /// <summary>
    /// Exchange entity extensions class.
    /// </summary>
    public static class ExchangeEntityExtensions
    {
        /// <summary>
        /// Builds a list of Exchange.
        /// </summary>
        /// <returns>Returns a mock list of Exchange objects.</returns>
        public static IEnumerable<Exchange> BuildList()
        {
            return new List<Exchange>
            {
                Build(),
                new Exchange
                {
                    ID = 1,
                    Name = "The New York Stock Exchange",
                    IsActive = true,
                },

                new Exchange
                {
                    ID = 2,
                    Name = "NASDAQ Stock Exchange",
                    IsActive = true,
                },
                new Exchange
                {
                    ID = 3,
                    Name = "Bombay Stock Exchange",
                    IsActive = false,
                },
            };
        }

        /// <summary>
        /// Builds a Exchange object.
        /// </summary>
        /// <returns>Returns a mock Exchange object.</returns>
        public static Exchange Build()
        {
            return new Exchange
            {
                ID = 52,
                Name = "Dummy Exchange",
                IsActive = true,
            };
        }
    }
}
