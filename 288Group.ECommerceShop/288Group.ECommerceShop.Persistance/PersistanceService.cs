using _288Group.ECommerceShop.DTOs;
using _288Group.ECommerceShop.Persistence.Database;
using _288Group.ECommerceShop.Persistence.Model;
using System;
using System.Linq;

namespace _288Group.ECommerceShop.Persistance
{
    public class PersistanceService : IPersistanceService
    {
        private readonly IErrorLogRepository _errorRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserBasketRepository _userBasketRepository;

        public PersistanceService(IErrorLogRepository errorRepository, IProductRepository productRepository, IUserRepository userRepository, IUserBasketRepository userBasketRepository)
            => (_errorRepository, _productRepository, _userRepository, _userBasketRepository)
            = (errorRepository, productRepository, userRepository, userBasketRepository);

        /// <returns>The provided errorMessage parameter for output to UI</returns>
        public string LogError(string errorMessage, Exception ex = null)
        {
            long errorLogId = _errorRepository.Add(new ErrorLog(errorMessage, ex?.Message, ex?.InnerException?.Message));

            if (ex != null)
            {
                errorMessage += $" An internal Exception occured, please contact your system administrator with errorLogId {errorLogId}";
            }

            return errorMessage;
        }

        public ProductsDTO GetAllProducts()
            => new ProductsDTO(_productRepository.Get().Select(x => new ProductDTO(x.Id, x.Name, x.Price)).ToArray()); // TODO: Add paging and get Top X (100?) per page.

        public ProductsDTO GetProducts(long[] productIds)
            => new ProductsDTO(_productRepository.Get().Select(x => new ProductDTO(x.Id, x.Name, x.Price)).Where(x => productIds.Any(y => y == x.Id)).ToArray());

        public long? GetUserId(string username, string password)
            => _userRepository.Get().Where(x => x.Username == username && x.Password == password).Single().Id;

        public string GetUsername(long userId)
            => _userRepository.Get().Where(x => x.Id == userId).Single().Username;

        public CreateNewUserResponseDTO AddUser(string username, string password)
        {
            if (_userRepository.Get().Any(x => x.Username == username))
            {
                return new CreateNewUserResponseDTO(false, $"Username {username} already exsists in the database");
            }

            _userRepository.Add(new User(username, password));
            return new CreateNewUserResponseDTO(true, $"New User {username} has been created successfully");
        }

        public ProductsDTO GetUserBasket(long userId)
            => GetProducts(_userBasketRepository.Get().Where(x => x.UserId == userId).Select(x => x.ProductId).ToArray());               

        public long? AddProductToBasket(long userId, long productId)
            => _userBasketRepository.Add(new UserProductBasket(userId, productId));

        public string TotalCostOfBasket(long userId)
        {
            long[] productIds = _userBasketRepository.Get().Where(x => x.UserId == userId).Select(x => x.ProductId).ToArray();
            return "£" + _productRepository.Get().Where(x => productIds.Any(y => y == x.Id)).Sum(x => x.Price).ToString();
        }
    }
}
