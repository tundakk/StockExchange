namespace StockExchange.BLL.Tests
{
    using System.Collections.Generic;
    using AutoMapper;
    using Microsoft.Extensions.Logging;
    using Moq;
    using NUnit.Framework;
    using StockExchange.Base.Tests.FakeModelExtensions;
    using StockExchange.BLL.Infrastructure.Services;
    using StockExchange.DAL.DataModel;
    using StockExchange.DAL.Repos.Interface;
    using StockExchange.Domain.Model;
    using StockExchange.Domain.Model.Mapping;
    using StockExchange.Domain.Model.Responses;

    /// <summary>
    /// Tests for EodPriceService.
    /// </summary>
    public class EodPriceServiceTests
    {
        private Mock<IEodPriceRepo> mockEodPriceRepo;
        private Mock<ILogger<EodPriceService>> mockLogger; // i dont think this is correctly formatted

        private EodPriceService sut;
        private IMapper mockMapper;

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
            EodPrice eodPriceEntities = EodPriceEntityExtensions.Build();

            mockEodPriceRepo.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(eodPriceEntities);

            //Act
            ServiceResponse<EodPriceModel> result = sut.GetById(id);

            //Assert
            Assert.True(result.Success);
        }

        /// <summary>
        /// Test with no existing instance id.
        /// </summary>
        [Test]
        public void GetById_WithValidEodPriceID_ShouldReturnDataNull()
        {
            //Arrange

            EodPrice eodPrice = null;
            mockEodPriceRepo.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(eodPrice);

            //Act
            ServiceResponse<EodPriceModel> result = sut.GetById(1234);

            //Assert
            Assert.IsNull(result.Data);
        }

        /// <summary>
        /// Test with no existing instance id.
        /// </summary>
        [Test]
        public void GetById_WithValidEodPriceID_ShouldReturnException()
        {
            //Arrange
            mockEodPriceRepo.Setup(repo => repo.GetById(It.IsAny<int>())).Throws(new Exception());

            //Act
            ServiceResponse<EodPriceModel> result = sut.GetById(1234);

            //Assert
            Assert.False(result.Success);
            Assert.IsNotEmpty(result.Message); // Does this make sense?
        }

        /// <summary>
        /// test with invalid instance ID.
        /// </summary>
        [Test]
        public void GetById_WithInvalidEodPriceID_ShouldReturnSuccessFalse()
        {
            //Arrange
            int id = -12;

            //Act
            ServiceResponse<EodPriceModel> result = sut.GetById(id);

            //Assert
            Assert.False(result.Success);
        }

        #endregion

        #region GetAll

        /// <summary>
        /// test get all that returns null.
        /// </summary>
        [Test]
        public void GetAll_WithNoDataFromDatabase_ShouldReturnSuccessFalse()
        {
            //Arrange
            IQueryable<EodPrice> eodpriceNull = null;

            mockEodPriceRepo.Setup(repo => repo.GetAll()).Returns(eodpriceNull);

            //Act
            ServiceResponse<IEnumerable<EodPriceModel>> result = sut.GetAll();

            //Assert
            Assert.False(result.Success);
        }

        /// <summary>
        /// test get all that returns an empty array.
        /// </summary>
        [Test]
        public void GetAll_WithValidData_ShouldReturnSuccessFalse()
        {
            //Arrange
            IQueryable<EodPrice> eodpriceEmpty = new List<EodPrice>().AsQueryable();

            mockEodPriceRepo.Setup(repo => repo.GetAll()).Returns(eodpriceEmpty);

            //Act
            ServiceResponse<IEnumerable<EodPriceModel>> result = sut.GetAll();

            //Assert
            Assert.False(result.Success);
        }

        /// <summary>
        /// test get all that returns all valid entities.
        /// </summary>
        [Test]
        public void GetAll_WithValidData_ShouldReturnSuccessTrue()
        {
            //Arrange
            IQueryable<EodPrice> eodPriceEntities = EodPriceEntityExtensions.BuildList().AsQueryable();

            mockEodPriceRepo.Setup(repo => repo.GetAll()).Returns(eodPriceEntities);

            //Act
            ServiceResponse<IEnumerable<EodPriceModel>> result = sut.GetAll();

            //Assert
            Assert.True(result.Success);
        }

        #endregion

        #region GetEodsByStockIdWhereDate

        /// <summary>
        /// Test with valid StockSymbol id.
        /// </summary>
        [Test]
        public void GetEods_ByDateWithValidStockId_ShouldReturnSuccessTrue()
        {
            //Arrange
            int stockSymbolId = 12;
            DateTime from = new System.DateTime(2020, 12, 15, 23, 22, 11);
            DateTime to = new System.DateTime(2021, 12, 15, 23, 22, 11);

            IEnumerable<EodPrice> eodPriceEntities = EodPriceEntityExtensions.BuildList();

            mockEodPriceRepo.Setup(repo => repo.GetByStockIdAndDate(It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(eodPriceEntities);

            //Act
            ServiceResponse<IEnumerable<EodPriceModel>> result = sut.GetEodsByStockIdWhereDate(stockSymbolId, from, to);

            //Assert
            Assert.True(result.Success);
        }

        /// <summary>
        /// Test with valid stocksymbolid and no entities found.
        /// </summary>
        [Test]
        public void GetEods_ByDateWithValidStockId_ShouldReturnDataNull()
        {
            //Arrange
            int stockSymbolId = 12;
            DateTime from = new System.DateTime(2020, 12, 15, 23, 22, 11);
            DateTime to = new System.DateTime(2021, 12, 15, 23, 22, 11);
            IEnumerable<EodPrice> eodsNull = null;

            mockEodPriceRepo.Setup(repo => repo.GetByStockIdAndDate(It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(eodsNull);

            //Act
            ServiceResponse<IEnumerable<EodPriceModel>> result = sut.GetEodsByStockIdWhereDate(stockSymbolId, from, to);

            //Assert
            Assert.IsNull(result.Data);
        }

        /// <summary>
        /// Test with no existing instance id.
        /// </summary>
        [Test]
        public void GetEods_ByDateWithValidStockId_ShouldReturnException()
        {
            //Arrange
            int stockSymbolId = 12;
            DateTime from = new System.DateTime(2020, 12, 15, 23, 22, 11);
            DateTime to = new System.DateTime(2021, 12, 15, 23, 22, 11);
            mockEodPriceRepo.Setup(repo => repo.GetById(It.IsAny<int>())).Throws(new Exception());

            //Act
            ServiceResponse<IEnumerable<EodPriceModel>> result = sut.GetEodsByStockIdWhereDate(stockSymbolId, from, to);

            //Assert
            Assert.False(result.Success);
            Assert.IsNotEmpty(result.Message); // Does this make sense?
        }

        /// <summary>
        /// test with invalid stocksymbol ID.
        /// </summary>
        [Test]
        public void GetEods_ByDateWithInvalidStockId_ShouldReturnSuccessFalse()
        {
            //Arrange
            int stockSymbolId = -12;
            DateTime from = new System.DateTime(2020, 12, 15, 23, 22, 11);
            DateTime to = new System.DateTime(2021, 12, 15, 23, 22, 11);

            //Act
            ServiceResponse<IEnumerable<EodPriceModel>> result = sut.GetEodsByStockIdWhereDate(stockSymbolId, from, to);

            //Assert
            Assert.False(result.Success);
        }

        /// <summary>
        /// test with invalid dates.
        /// </summary>
        [Test]
        public void GetEods_ByDateWithInvalidDates_ShouldReturnSuccessFalse()
        {
            //Arrange
            int stockSymbolId = 12;
            DateTime from = new System.DateTime(2021, 12, 15, 23, 22, 11);
            DateTime to = new System.DateTime(2020, 12, 15, 23, 22, 11);

            //Act
            ServiceResponse<IEnumerable<EodPriceModel>> result = sut.GetEodsByStockIdWhereDate(stockSymbolId, from, to);

            //Assert
            Assert.False(result.Success);
        }

        #endregion

        #region Create

        /// <summary>
        /// test creating an entity which repo returns null.
        /// </summary>
        [Test]
        public void Create_WithInvalidObject_ShouldReturnDataNull()
        {
            //Arrange
            EodPrice eodPrice = null;

            EodPriceModel eodPrice1 = new EodPriceModel();

            mockEodPriceRepo.Setup(repo => repo.Insert(It.IsAny<EodPrice>())).Returns(eodPrice);

            //Act
            ServiceResponse<EodPriceModel> result = sut.Insert(eodPrice1);

            //Assert
            Assert.IsNull(result.Data);
        }

        /// <summary>
        /// test creating a valid entity where the repo returns the entity.
        /// </summary>
        [Test]
        public void Create_WithValidObject_ShouldReturnData()
        {
            //Arrange
            EodPrice eodPriceEntity = EodPriceEntityExtensions.Build();

            EodPriceModel eodPriceModel = EodPriceEntityExtensions.BuildDomainModel();
            mockEodPriceRepo.Setup(repo => repo.Insert(It.IsAny<EodPrice>())).Returns(eodPriceEntity);

            //Act
            ServiceResponse<EodPriceModel> result = sut.Insert(eodPriceModel);

            //Assert
            //Assert.True(names.Any());
            Assert.True(result.Success);
            Assert.IsNotNull(result.Data);
        }

        /// <summary>
        /// test creating an null entity where the repo returns ServiceResponse .Success set to false.
        /// </summary>
        [Test]
        public void Create_WithInvalidObject_ShouldReturnSuccessFalse()
        {
            //Arrange
            //EodPrice eodPriceEntity = EodPriceEntityExtensions.Build();

            EodPriceModel eodPriceModel = null;

            //Act
            ServiceResponse<EodPriceModel> result = sut.Insert(eodPriceModel);

            //Assert
            //Assert.True(names.Any());
            //Assert.True(result.Success);
            Assert.False(result.Success);
        }

        #endregion

        #region Update

        /// <summary>
        /// test updating with invalid entity where repo returns null.
        /// </summary>
        [Test]
        public void Update_WithInvalidObject_ShouldReturnDataNull()
        {
            //Arrange
            EodPrice eodPrice = null;

            EodPriceModel eodPriceModel = new EodPriceModel();

            mockEodPriceRepo.Setup(repo => repo.Update(It.IsAny<EodPrice>())).Returns(eodPrice);

            //Act
            ServiceResponse<EodPriceModel> result = sut.Update(eodPriceModel);

            //Assert
            Assert.IsNull(result.Data);
        }

        /// <summary>
        /// test updating a valid entity where the repo returns the entity.
        /// </summary>
        [Test]
        public void Update_WithValidObject_ShouldReturnData()
        {
            //Arrange
            EodPrice eodPriceEntity = EodPriceEntityExtensions.Build();

            EodPriceModel eodPriceModel = EodPriceEntityExtensions.BuildDomainModel();
            mockEodPriceRepo.Setup(repo => repo.Update(It.IsAny<EodPrice>())).Returns(eodPriceEntity);

            //Act
            ServiceResponse<EodPriceModel> result = sut.Update(eodPriceModel);

            //Assert
            Assert.True(result.Success);
            Assert.IsNotNull(result.Data);
        }

        /// <summary>
        /// test updating an null entity where the repo returns ServiceResponse .Success set to false.
        /// </summary>
        [Test]
        public void Update_WithInvalidObject_ShouldReturnSuccessFalse()
        {
            //Arrange
            //EodPrice eodPriceEntity = EodPriceEntityExtensions.Build();

            EodPriceModel eodPriceModel = null;

            //Act
            ServiceResponse<EodPriceModel> result = sut.Update(eodPriceModel);

            //Assert
            //Assert.True(names.Any());
            //Assert.True(result.Success);
            Assert.False(result.Success);
        }
        #endregion

        #region Delete

        /// <summary>
        /// test deleting with invalid id where repo returns null.
        /// </summary>
        [Test]
        public void Delete_WithValidId_ShouldReturnDataNull()
        {
            //Arrange
            EodPrice eodPrice = null;
            int id = 14;

            mockEodPriceRepo.Setup(repo => repo.Delete(It.IsAny<EodPrice>())).Returns(eodPrice);

            //Act
            ServiceResponse<EodPriceModel> result = sut.Delete(id);

            //Assert
            Assert.IsNull(result.Data);
        }

        /// <summary>
        /// test deleting a valid entity where the repo returns the entity.
        /// </summary>
        [Test]
        public void Delete_WithValidId_ShouldReturnData()
        {
            //Arrange
            EodPrice eodPriceEntity = EodPriceEntityExtensions.Build();
            int id = 31;
            mockEodPriceRepo.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(eodPriceEntity);
            mockEodPriceRepo.Setup(repo => repo.Delete(It.IsAny<EodPrice>())).Returns(eodPriceEntity);

            //Act
            ServiceResponse<EodPriceModel> result = sut.Delete(id);

            //Assert
            Assert.True(result.Success);
            Assert.IsNotNull(result.Data);
        }

        /// <summary>
        /// test deleting an entity where the id is invalid. Returns ServiceResponse .Success set to false.
        /// </summary>
        [Test]
        public void Delete_WithInvalidId_ShouldReturnSuccessFalse()
        {
            //Arrange
            //EodPrice eodPrice = null;
            int id = 0;
            //mockEodPriceRepo.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(eodPrice);
            //mockEodPriceRepo.Setup(repo => repo.Delete(It.IsAny<EodPrice>())).Returns(eodPrice);

            //Act
            ServiceResponse<EodPriceModel> result = sut.Delete(id);

            //Assert
            Assert.False(result.Success);
        }

        /// <summary>
        /// test deleting an null entity where Id is valid but the repo returns null.
        /// </summary>
        [Test]
        public void Delete_WithValidId_ShouldReturnSuccessFalse()
        {
            //Arrange
            EodPrice eodPrice = null;
            int id = 100000000;

            mockEodPriceRepo.Setup(repo => repo.Delete(It.IsAny<EodPrice>())).Returns(eodPrice);

            //Act
            ServiceResponse<EodPriceModel> result = sut.Delete(id);

            //Assert
            Assert.False(result.Success);
        }
        #endregion
    }
}
