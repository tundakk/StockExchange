namespace StockExchange.BLL.Tests
{
    using AutoMapper;
    using global::StockExchange.Base.Tests.FakeModelExtensions;
    using global::StockExchange.BLL.Infrastructure.Services;
    using global::StockExchange.DAL.DataModel;
    using global::StockExchange.DAL.Repos.Interface;
    using global::StockExchange.Domain.Model;
    using global::StockExchange.Domain.Model.Mapping;
    using global::StockExchange.Domain.Model.Responses;
    using Microsoft.Extensions.Logging;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Tests for ExchangeService.
    /// </summary>
    public class ExchangeServiceTests
    {
        private Mock<IExchangeRepo> mockExchangeRepo;
        private Mock<ILogger<ExchangeService>> mockLogger; // i dont think this is correctly formatted

        private ExchangeService sut;
        private IMapper mockMapper;

        /// <summary>
        /// Setup.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            mockExchangeRepo = new Mock<IExchangeRepo>();
            mockLogger = new Mock<ILogger<ExchangeService>>();

            var mockMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfiles());
            });

            mockMapper = mockMapperConfig.CreateMapper();

            sut = new ExchangeService(
                mockExchangeRepo.Object,
                mockMapper,
                mockLogger.Object);
        }

        #region GetById

        /// <summary>
        /// Test with valid instance id.
        /// </summary>
        [Test]
        public void GetById_WithValidExchangeID_ShouldReturnSuccessTrue()
        {
            //Arrange
            int id = 12;
            Exchange exchangeEntities = ExchangeEntityExtensions.Build();

            mockExchangeRepo.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(exchangeEntities);

            //Act
            ServiceResponse<ExchangeModel> result = sut.GetById(id);

            //Assert
            Assert.True(result.Success);
        }

        /// <summary>
        /// Test with no existing instance id.
        /// </summary>
        [Test]
        public void GetById_WithInvalidExchangeID_ShouldReturnDataNull()
        {
            //Arrange

            Exchange exchange = null;
            mockExchangeRepo.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(exchange);

            //Act
            ServiceResponse<ExchangeModel> result = sut.GetById(1234);

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
            mockExchangeRepo.Setup(repo => repo.GetById(It.IsAny<int>())).Throws(new Exception());

            //Act
            ServiceResponse<ExchangeModel> result = sut.GetById(1234);

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
            ServiceResponse<ExchangeModel> result = sut.GetById(id);

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
            IQueryable<Exchange> eodpriceNull = null;

            mockExchangeRepo.Setup(repo => repo.GetAll()).Returns(eodpriceNull);

            //Act
            ServiceResponse<IEnumerable<ExchangeModel>> result = sut.GetAll();

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
            IQueryable<Exchange> eodpriceEmpty = new List<Exchange>().AsQueryable();

            mockExchangeRepo.Setup(repo => repo.GetAll()).Returns(eodpriceEmpty);

            //Act
            ServiceResponse<IEnumerable<ExchangeModel>> result = sut.GetAll();

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
            IQueryable<Exchange> exchangeEntities = ExchangeEntityExtensions.BuildList().AsQueryable();

            mockExchangeRepo.Setup(repo => repo.GetAll()).Returns(exchangeEntities);

            //Act
            ServiceResponse<IEnumerable<ExchangeModel>> result = sut.GetAll();

            //Assert
            Assert.True(result.Success);
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
            Exchange exchangeEntities = ExchangeEntityExtensions.Build();

            mockExchangeRepo.Setup(repo => repo.GetByName(It.IsAny<string>())).Returns(exchangeEntities);

            //Act
            ServiceResponse<ExchangeModel> result = sut.GetByName("test");

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

            Exchange exchange = null;
            mockExchangeRepo.Setup(repo => repo.GetByName(It.IsAny<string>())).Returns(exchange);

            //Act
            ServiceResponse<ExchangeModel> result = sut.GetByName("test");

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
            mockExchangeRepo.Setup(repo => repo.GetByName(It.IsAny<string>())).Throws(new Exception());

            //Act
            ServiceResponse<ExchangeModel> result = sut.GetByName("test");

            //Assert
            Assert.False(result.Success);
            Assert.IsNotEmpty(result.Message);
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
            Exchange exchange = null;

            ExchangeModel exchange1 = new ExchangeModel();

            mockExchangeRepo.Setup(repo => repo.Insert(It.IsAny<Exchange>())).Returns(exchange);

            //Act
            ServiceResponse<ExchangeModel> result = sut.Insert(exchange1);

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
            Exchange exchangeEntity = ExchangeEntityExtensions.Build();

            ExchangeModel exchangeModel = ExchangeEntityExtensions.BuildDomainModel();
            mockExchangeRepo.Setup(repo => repo.Insert(It.IsAny<Exchange>())).Returns(exchangeEntity);

            //Act
            ServiceResponse<ExchangeModel> result = sut.Insert(exchangeModel);

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
            //Exchange exchangeEntity = ExchangeEntityExtensions.Build();

            ExchangeModel exchangeModel = null;

            //Act
            ServiceResponse<ExchangeModel> result = sut.Insert(exchangeModel);

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
            Exchange exchange = null;

            ExchangeModel exchangeModel = new ExchangeModel();

            mockExchangeRepo.Setup(repo => repo.Update(It.IsAny<Exchange>())).Returns(exchange);

            //Act
            ServiceResponse<ExchangeModel> result = sut.Update(exchangeModel);

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
            Exchange exchangeEntity = ExchangeEntityExtensions.Build();

            ExchangeModel exchangeModel = ExchangeEntityExtensions.BuildDomainModel();
            mockExchangeRepo.Setup(repo => repo.Update(It.IsAny<Exchange>())).Returns(exchangeEntity);

            //Act
            ServiceResponse<ExchangeModel> result = sut.Update(exchangeModel);

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
            //Exchange exchangeEntity = ExchangeEntityExtensions.Build();

            ExchangeModel exchangeModel = null;

            //Act
            ServiceResponse<ExchangeModel> result = sut.Update(exchangeModel);

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
            Exchange exchange = null;
            int id = 14;

            mockExchangeRepo.Setup(repo => repo.Delete(It.IsAny<Exchange>())).Returns(exchange);

            //Act
            ServiceResponse<ExchangeModel> result = sut.Delete(id);

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
            Exchange exchangeEntity = ExchangeEntityExtensions.Build();
            int id = 31;
            mockExchangeRepo.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(exchangeEntity);
            mockExchangeRepo.Setup(repo => repo.Delete(It.IsAny<Exchange>())).Returns(exchangeEntity);

            //Act
            ServiceResponse<ExchangeModel> result = sut.Delete(id);

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
            //Exchange exchange = null;
            int id = 0;
            //mockExchangeRepo.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(exchange);
            //mockExchangeRepo.Setup(repo => repo.Delete(It.IsAny<Exchange>())).Returns(exchange);

            //Act
            ServiceResponse<ExchangeModel> result = sut.Delete(id);

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
            Exchange exchange = null;
            int id = 100000000;

            mockExchangeRepo.Setup(repo => repo.Delete(It.IsAny<Exchange>())).Returns(exchange);

            //Act
            ServiceResponse<ExchangeModel> result = sut.Delete(id);

            //Assert
            Assert.False(result.Success);
        }
        #endregion
    }
}
