namespace StockExchange.Base.Tests
{
    using Microsoft.Extensions.Logging;
    using Moq;

    /// <summary>
    /// BaseTest.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseTest<T> where T : class
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