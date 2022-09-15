namespace StockExchange.BLL.Tests
{
    using AutoMapper;
    using Microsoft.Extensions.Logging;
    using Moq;
    using NUnit.Framework;
    using StockExchange.Base.Tests;
    using StockExchange.Base.Tests.FakeModelExtensions;
    using StockExchange.BLL.Infrastructure.Services;
    using StockExchange.DAL.Repos.Interface;
    using StockExchange.Domain.Model;
    using StockExchange.Domain.Model.Mapping;
    using StockExchange.Domain.Model.Responses;

    /// <summary>
    /// Tests for EodPriceService.
    /// </summary>
    [TestFixture]
    public class EodPriceServiceTests : BaseTest<EodPriceService>
    {
        private Mock<IEodPriceRepo>? mockEodPriceRepo;
        private Mock<ILogger<EodPriceService>>? mockLogger; // i dont think this is correctly formatted

        private EodPriceService? sut;
        private IMapper? mockMapper;

        /// <summary>
        /// Setup.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            mockEodPriceRepo = new Mock<IEodPriceRepo>();
            mockLogger = new Mock<ILogger<EodPriceService>>();

            var mockMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfiles());
            });

            mockMapper = mockMapperConfig.CreateMapper();

            sut = new EodPriceService(
                mockEodPriceRepo.Object,
                mockMapper,
                mockLogger.Object);
        }

        #region GetById

        /// <summary>
        /// Test with valid instance id.
        /// </summary>
        [Test]
        public void GetById_WithValidEodPriceID_ShouldReturnSuccessTrue()
        {
            //Arrange
            int id = 12;
            var eodPriceEntities = EodPriceEntityExtensions.BuildList().Where(e => e.ID == id).FirstOrDefault();

            mockEodPriceRepo?.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(eodPriceEntities);

            //Act
            ServiceResponse<EodPriceModel>? result = sut?.GetById(id);

            //Assert
            Assert.True(result?.Success);
        }

        ///// <summary>
        ///// Test with no existing instance id.
        ///// </summary>
        //[Test]
        //public void GetById_WithValidUserID_ShouldReturnDataNull()
        //{
        //    //Arrange
        //    EodPrice? eodPrice = null;
        //    mockEodPriceRepo.Setup(repo => repo.GetById(It.IsAny<int>(), It.IsAny<string[]>())).Returns(eodPrice);

        //    //Act
        //    ServiceResponse<EodPrice> result = eodPriceService.GetById(1234, false);

        //    //Assert
        //    Assert.AreEqual(null, result.Data);
        //}
        #endregion
    }
}
