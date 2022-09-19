namespace StockExchange.BLL.Tests
{
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
    /// Tests for StockSymbol Service.
    /// </summary>
    public class StockSymbolServiceTests
    {
        private Mock<IStockSymbolRepo> mockStockSymbolRepo;
        private Mock<ILogger<StockSymbolService>> mockLogger;

        private StockSymbolService sut;
        private IMapper mockMapper;

        /// <summary>
        /// Setup.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            mockStockSymbolRepo = new Mock<IStockSymbolRepo>();
            mockLogger = new Mock<ILogger<StockSymbolService>>();

            var mockMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfiles());
            });

            mockMapper = mockMapperConfig.CreateMapper();

            sut = new StockSymbolService(
                mockStockSymbolRepo.Object,
                mockMapper,
                mockLogger.Object);
        }

        #region GetById

        /// <summary>
        /// Test with valid instance id.
        /// </summary>
        [Test]
        public void GetById_WithValidStockSymbolID_ShouldReturnSuccessTrue()
        {
            //Arrange
            int id = 12;
            StockSymbol stockSymbolEntities = StockSymbolEntityExtensions.Build();

            mockStockSymbolRepo.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(stockSymbolEntities);

            //Act
            ServiceResponse<StockSymbolModel> result = sut.GetById(id);

            //Assert
            Assert.True(result.Success);
        }

        /// <summary>
        /// Test with no existing instance id.
        /// </summary>
        [Test]
        public void GetById_WithValidStockSymbolID_ShouldReturnDataNull()
        {
            //Arrange

            StockSymbol stockSymbol = null;
            mockStockSymbolRepo.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(stockSymbol);

            //Act
            ServiceResponse<StockSymbolModel> result = sut.GetById(1234);

            //Assert
            Assert.IsNull(result.Data);
        }

        /// <summary>
        /// Test with no existing instance id.
        /// </summary>
        [Test]
        public void GetById_WithValidStockSymbolID_ShouldReturnException()
        {
            //Arrange
            mockStockSymbolRepo.Setup(repo => repo.GetById(It.IsAny<int>())).Throws(new Exception());

            //Act
            ServiceResponse<StockSymbolModel> result = sut.GetById(1234);

            //Assert
            Assert.False(result.Success);
            Assert.IsNotEmpty(result.Message); // Does this make sense?
        }

        /// <summary>
        /// test with invalid instance ID.
        /// </summary>
        [Test]
        public void GetById_WithInvalidStockSymbolID_ShouldReturnSuccessFalse()
        {
            //Arrange
            int id = -12;

            //Act
            ServiceResponse<StockSymbolModel> result = sut.GetById(id);

            //Assert
            Assert.False(result.Success);
        }

        #endregion

        #region GetByExchangeId

        /// <summary>
        /// Test with valid exchangeId.
        /// </summary>
        [Test]
        public void GetById_WithValidExchangeID_ShouldReturnSuccessTrue()
        {
            //Arrange
            int exchangeId = 12;
            IEnumerable<StockSymbol> stockSymbolEntities = StockSymbolEntityExtensions.BuildList();

            mockStockSymbolRepo.Setup(repo => repo.GetListOfStockByExchangeId(It.IsAny<int>())).Returns(stockSymbolEntities);

            //Act
            ServiceResponse<IEnumerable<StockSymbolModel>> result = sut.GetStockByExchangeId(exchangeId);

            //Assert
            Assert.True(result.Success);
        }

        /// <summary>
        /// Test with none existing object but valid exchangeId.
        /// </summary>
        [Test]
        public void GetById_WithValidExchangeID_ShouldReturnDataNull()
        {
            //Arrange

            IEnumerable<StockSymbol> stockSymbol = null;
            mockStockSymbolRepo.Setup(repo => repo.GetListOfStockByExchangeId(It.IsAny<int>())).Returns(stockSymbol);

            //Act
            ServiceResponse<IEnumerable<StockSymbolModel>> result = sut.GetStockByExchangeId(1234);

            //Assert
            Assert.IsNull(result.Data);
        }

        /// <summary>
        /// Test with no existing instance id.
        /// </summary>
        [Test]
        public void GetById_WithValidExchangeID_ShouldReturnException()
        {
            //Arrange
            mockStockSymbolRepo.Setup(repo => repo.GetListOfStockByExchangeId(It.IsAny<int>())).Throws(new Exception());

            //Act
            ServiceResponse<IEnumerable<StockSymbolModel>> result = sut.GetStockByExchangeId(1234);

            //Assert
            Assert.False(result.Success);
            Assert.IsNotEmpty(result.Message); // Does this make sense?
        }

        /// <summary>
        /// test with invalid instance ID.
        /// </summary>
        [Test]
        public void GetById_WithInvalidExchangeID_ShouldReturnSuccessFalse()
        {
            //Arrange
            int id = -12;

            //Act
            ServiceResponse<IEnumerable<StockSymbolModel>> result = sut.GetStockByExchangeId(id);

            //Assert
            Assert.False(result.Success);
        }

        #endregion

        #region GetByName

        /// <summary>
        /// Test with valid instance name.
        /// </summary>
        [Test]
        public void GetByName_WithValidName_ShouldReturnSuccessTrue()
        {
            //Arrange
            StockSymbol stockSymbolEntities = StockSymbolEntityExtensions.Build();

            mockStockSymbolRepo.Setup(repo => repo.GetByName(It.IsAny<string>())).Returns(stockSymbolEntities);

            //Act
            ServiceResponse<StockSymbolModel> result = sut.GetByName("test");

            //Assert
            Assert.True(result.Success);
        }

        /// <summary>
        /// Test with none existing instance name.
        /// </summary>
        [Test]
        public void GetByName_WithInvalidName_ShouldReturnDataNull()
        {
            //Arrange

            StockSymbol exchange = null;
            mockStockSymbolRepo.Setup(repo => repo.GetByName(It.IsAny<string>())).Returns(exchange);

            //Act
            ServiceResponse<StockSymbolModel> result = sut.GetByName("test");

            //Assert
            Assert.IsNull(result.Data);
        }

        /// <summary>
        /// Test with none existing instance name.
        /// </summary>
        [Test]
        public void GetByName_WithValidName_ShouldReturnException()
        {
            //Arrange
            mockStockSymbolRepo.Setup(repo => repo.GetByName(It.IsAny<string>())).Throws(new Exception());

            //Act
            ServiceResponse<StockSymbolModel> result = sut.GetByName("test");

            //Assert
            Assert.False(result.Success);
            Assert.IsNotEmpty(result.Message);
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
            IQueryable<StockSymbol> stockSymbolNull = null;

            mockStockSymbolRepo.Setup(repo => repo.GetAll()).Returns(stockSymbolNull);

            //Act
            ServiceResponse<IEnumerable<StockSymbolModel>> result = sut.GetAll();

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
            IQueryable<StockSymbol> stockSymbolEmpty = new List<StockSymbol>().AsQueryable();

            mockStockSymbolRepo.Setup(repo => repo.GetAll()).Returns(stockSymbolEmpty);

            //Act
            ServiceResponse<IEnumerable<StockSymbolModel>> result = sut.GetAll();

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
            IQueryable<StockSymbol> stockSymbolEntities = StockSymbolEntityExtensions.BuildList().AsQueryable();

            mockStockSymbolRepo.Setup(repo => repo.GetAll()).Returns(stockSymbolEntities);

            //Act
            ServiceResponse<IEnumerable<StockSymbolModel>> result = sut.GetAll();

            //Assert
            Assert.True(result.Success);
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
            StockSymbol stockSymbol = null;

            StockSymbolModel stockSymbol1 = new StockSymbolModel();

            mockStockSymbolRepo.Setup(repo => repo.Insert(It.IsAny<StockSymbol>())).Returns(stockSymbol);

            //Act
            ServiceResponse<StockSymbolModel> result = sut.Insert(stockSymbol1);

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
            StockSymbol stockSymbolEntity = StockSymbolEntityExtensions.Build();

            StockSymbolModel stockSymbolModel = StockSymbolEntityExtensions.BuildDomainModel();
            mockStockSymbolRepo.Setup(repo => repo.Insert(It.IsAny<StockSymbol>())).Returns(stockSymbolEntity);
            //Act
            ServiceResponse<StockSymbolModel> result = sut.Insert(stockSymbolModel);

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
            //StockSymbol stockSymbolEntity = StockSymbolEntityExtensions.Build();

            StockSymbolModel stockSymbolModel = null;

            //Act
            ServiceResponse<StockSymbolModel> result = sut.Insert(stockSymbolModel);

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
            StockSymbol stockSymbol = null;

            StockSymbolModel stockSymbolModel = new StockSymbolModel();

            mockStockSymbolRepo.Setup(repo => repo.Update(It.IsAny<StockSymbol>())).Returns(stockSymbol);

            //Act
            ServiceResponse<StockSymbolModel> result = sut.Update(stockSymbolModel);

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
            StockSymbol stockSymbolEntity = StockSymbolEntityExtensions.Build();

            StockSymbolModel stockSymbolModel = StockSymbolEntityExtensions.BuildDomainModel();
            mockStockSymbolRepo.Setup(repo => repo.Update(It.IsAny<StockSymbol>())).Returns(stockSymbolEntity);

            //Act
            ServiceResponse<StockSymbolModel> result = sut.Update(stockSymbolModel);

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
            //StockSymbol stockSymbolEntity = StockSymbolEntityExtensions.Build();

            StockSymbolModel stockSymbolModel = null;
            //Act
            ServiceResponse<StockSymbolModel> result = sut.Update(stockSymbolModel);

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
            StockSymbol stockSymbol = null;
            int id = 14;

            mockStockSymbolRepo.Setup(repo => repo.Delete(It.IsAny<StockSymbol>())).Returns(stockSymbol);

            //Act
            ServiceResponse<StockSymbolModel> result = sut.Delete(id);

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
            StockSymbol stockSymbolEntity = StockSymbolEntityExtensions.Build();
            int id = 31;
            mockStockSymbolRepo.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(stockSymbolEntity);
            mockStockSymbolRepo.Setup(repo => repo.Delete(It.IsAny<StockSymbol>())).Returns(stockSymbolEntity);

            //Act
            ServiceResponse<StockSymbolModel> result = sut.Delete(id);

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
            //StockSymbol stockSymbol = null;
            int id = 0;
            //mockStockSymbolRepo.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(stockSymbol);
            //mockStockSymbolRepo.Setup(repo => repo.Delete(It.IsAny<StockSymbol>())).Returns(stockSymbol);

            //Act
            ServiceResponse<StockSymbolModel> result = sut.Delete(id);

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
            StockSymbol stockSymbol = null;
            int id = 100000000;

            mockStockSymbolRepo.Setup(repo => repo.Delete(It.IsAny<StockSymbol>())).Returns(stockSymbol);

            //Act
            ServiceResponse<StockSymbolModel> result = sut.Delete(id);

            //Assert
            Assert.False(result.Success);
        }
        #endregion
    }
}
