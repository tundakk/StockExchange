namespace StockExchange.DAL.Tests
{
    using Microsoft.Extensions.Logging;
    using Moq;

    /// <summary>
    /// Mocked BaseTest class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseTests<T> where T : class
    {
        /// <summary>
        /// Return  Logger Mock for each test.
        /// </summary>
        protected Mock<ILogger<T>> LoggerMock
        {
            get
            {
                return new Mock<ILogger<T>>();
            }
        }
    }
}
