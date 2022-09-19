namespace StockExchange.DAL.Tests
{
    using Microsoft.Extensions.Logging;
    using Moq;
    using NUnit.Framework;
    using StockExchange.Base.Tests.FakeModelExtensions;
    using StockExchange.DAL.DataModel;
    using StockExchange.DAL.Helpers;
    using StockExchange.DAL.Repos;

    /// <summary>
    /// EodPrice repository tests.
    /// </summary>
    [TestFixture]
    public class EodPriceRepoTests
    {
        private Mock<DataContext> mockDataContext;
        private Mock<ILogger<EodPriceRepo>> mockLogger;

        private EodPriceRepo sut;

        /// <summary>
        /// Setup to be ran before every test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            mockDataContext = new Mock<DataContext>();
            mockLogger = new Mock<ILogger<EodPriceRepo>>(); // i need to implement this
            sut = new EodPriceRepo(mockDataContext.Object);
        }

        /// <summary>
        /// Test - Get by ID with valid instance id. Throws exception.
        /// </summary>
        #region GetById
        [Test]
        public void GetById_WithValidId_ThrowsException()
        {
            // Arrange
            mockDataContext.Setup(dataContext => dataContext.Set<EodPrice>()).Throws(new Exception());

            // Act & Assert
            Assert.Throws<Exception>(() => sut.GetById(123));
        }

        /// <summary>
        /// Test - Get by ID with valid instance id.
        /// </summary>
        [Test]
        public void GetById_WithValidId_ShouldReturnEodPriceEntity()
        {
            //TEST DEN EHR KLASSE I MORGEN TIDLIG. HAR LIGE LAVET VIRTUAL I DBCONTEXT

            // Arrange
            EodPrice eodPrice = EodPriceEntityExtensions.Build();
            List<EodPrice> eodPriceS = EodPriceEntityExtensions.BuildList().ToList();
            var mockDbSet = RepoTestHelper.GetQueryableMockDbSet(eodPriceS);

            mockDataContext.Setup(dataContext => dataContext.EodPrices).Returns(mockDbSet.Object);

            mockDataContext.Setup(dataContext => dataContext.Set<EodPrice>()).Returns(mockDbSet.Object);

            // Act
            var result = sut.GetById(123);
            // Assert
            Assert.IsNotNull(result);
        }
        #endregion
    }
}
