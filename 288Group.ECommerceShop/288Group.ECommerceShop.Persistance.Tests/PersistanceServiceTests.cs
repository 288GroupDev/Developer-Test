using _288Group.ECommerceShop.Persistence.Database;
using _288Group.ECommerceShop.Persistence.Model;
using Moq;
using NUnit.Framework;
using System;

namespace _288Group.ECommerceShop.Persistance.Tests
{
    public class Tests
    {
        private Mock<IErrorLogRepository> _errorRepo;
        private Mock<IProductRepository> _productRepo;
        private Mock<IUserRepository> _userRepo;
        private Mock<IUserBasketRepository> _shoppingCartRepo;
        private IPersistanceService _subject;

        [SetUp]
        public void Setup()
        {
            _errorRepo = new Mock<IErrorLogRepository>();
            _productRepo = new Mock<IProductRepository>();
            _userRepo = new Mock<IUserRepository>();
            _shoppingCartRepo = new Mock<IUserBasketRepository>();
            _subject = new PersistanceService(_errorRepo.Object, _productRepo.Object, _userRepo.Object, _shoppingCartRepo.Object);
        }

        [Test]
        public void PersistanceService_LogError_ReturnsErrorMessageParam()
        {
            // Arrange
            string errorMessage = "TestString1234";
            _errorRepo.Setup(x => x.Add(It.IsAny<ErrorLog>())).Returns((long)12345);

            // Act
            var response = _subject.LogError(errorMessage);

            // Assert
            Assert.AreEqual(errorMessage, response);
        }

        [Test]
        public void PersistanceService_LogError_ExceptionErrorMessageContainsErrorLogId()
        {
            // Arrange
            long errorLogId = 12345;
            _errorRepo.Setup(x => x.Add(It.IsAny<ErrorLog>())).Returns(errorLogId);

            // Act
            var response = _subject.LogError("TestString1234", new Exception());
            bool result = response.Contains(errorLogId.ToString());

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void PersistanceService_GetAllProducts_CallsProductRepository()
        {
            // Arrange
            bool hasBeenCalled = false;
            _productRepo.Setup(x => x.Get()).Callback(() => hasBeenCalled = true);

            // Act
            var response = _subject.GetAllProducts();

            // Assert
            Assert.IsTrue(hasBeenCalled);
        }

        [Test]
        public void PersistanceService_GetProducts_CallsProductRepository()
        {
            // Arrange
            bool hasBeenCalled = false;
            _productRepo.Setup(x => x.Get()).Callback(() => hasBeenCalled = true);

            // Act
            var response = _subject.GetProducts(new long[] { 123, 1234, 12345 });

            // Assert
            Assert.IsTrue(hasBeenCalled);
        }

        [Test]
        public void PersistanceService_GetUserId_CallsUserRepository()
        {
            // Arrange
            bool hasBeenCalled = false;
            _userRepo.Setup(x => x.Get()).Callback(() => hasBeenCalled = true);

            // Act
            try
            {
                var response = _subject.GetUserId("Fred", "Password123");
            }
            catch (Exception ex)
            {
                // handling .Single()
            }

            // Assert
            Assert.IsTrue(hasBeenCalled);
        }

        [Test]
        public void PersistanceService_GetUsername_CallsUserRepository()
        {
            // Arrange
            bool hasBeenCalled = false;
            _userRepo.Setup(x => x.Get()).Callback(() => hasBeenCalled = true);

            // Act
            try
            {
                var response = _subject.GetUsername((long)12345);
            }
            catch (Exception ex)
            {
                // handling .Single()
            }

            // Assert
            Assert.IsTrue(hasBeenCalled);
        }

        [Test]
        public void PersistanceService_AddUser_CallsUserRepositoryGet()
        {
            // Arrange
            bool hasBeenCalled = false;
            _userRepo.Setup(x => x.Get()).Callback(() => hasBeenCalled = true);

            // Act
            var response = _subject.AddUser("Fred", "Password123");

            // Assert
            Assert.IsTrue(hasBeenCalled);
        }

        [Test]
        public void PersistanceService_AddUser_CallsUserRepositoryAdd()
        {
            // Arrange
            bool hasBeenCalled = false;
            _userRepo.Setup(x => x.Add(It.IsAny<User>())).Callback(() => hasBeenCalled = true);

            // Act
            var response = _subject.AddUser("Fred", "Password123");

            // Assert
            Assert.IsTrue(hasBeenCalled);
        }

        [Test]
        public void PersistanceService_GetShoppingCart_CallsShoppingCartRepositoryGet()
        {
            // Arrange
            bool hasBeenCalled = false;
            _shoppingCartRepo.Setup(x => x.Get()).Callback(() => hasBeenCalled = true);

            // Act
            var response = _subject.GetUserBasket((long)12345);

            // Assert
            Assert.IsTrue(hasBeenCalled);
        }

        [Test]
        public void PersistanceService_AddProductToShoppingCart_CallsShoppingCartRepositoryAdd()
        {
            // Arrange
            bool hasBeenCalled = false;
            _shoppingCartRepo.Setup(x => x.Add(It.IsAny<UserProductBasket>())).Callback(() => hasBeenCalled = true);

            // Act
            var response = _subject.AddProductToBasket((long)12345, (long)12345);

            // Assert
            Assert.IsTrue(hasBeenCalled);
        }
    }
}