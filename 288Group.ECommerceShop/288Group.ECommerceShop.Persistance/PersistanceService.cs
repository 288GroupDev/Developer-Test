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
        private readonly IDiscountCodeRepository _discountCodeRepository;

        public PersistanceService(IErrorLogRepository errorRepository, IProductRepository productRepository, IUserRepository userRepository, IUserBasketRepository userBasketRepository, IDiscountCodeRepository discountCodeRepository)
            => (_errorRepository, _productRepository, _userRepository, _userBasketRepository, _discountCodeRepository)
            = (errorRepository, productRepository, userRepository, userBasketRepository, discountCodeRepository);

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
            => new ProductsDTO(_productRepository.Get().Select(x => new ProductDTO(x.Id, x.Name, x.Price)).ToArray());

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

        public BasketDTO GetBasket(long userId, long? discountCodeId = null)
        {
            // TODO: optimize this into a single db query with specification pattern.
            // TODO: make this more testable by moving the user friendly string definitions up into Controllers.
            long[] productIds = _userBasketRepository.Get().Where(x => x.UserId == userId).Select(x => x.ProductId).ToArray();
            decimal totalCostOfBasket = _productRepository.Get().Where(x => productIds.Any(y => y == x.Id)).Sum(x => x.Price);
            string totalBeforeDiscount = $"£{totalCostOfBasket}";
            string discountValue = "nil";
            string totalAfterDiscount = $"£{totalCostOfBasket}";

            DiscountCode discount = null;
            if (discountCodeId != null)
            {
                discount = _discountCodeRepository.Get().Where(x => x.Id == discountCodeId).Single();
                decimal calcDiscountValue = (totalCostOfBasket / 100) * discount.DiscountPercentage;
                discountValue = $"£{calcDiscountValue}";
                totalAfterDiscount = $"£{totalCostOfBasket - calcDiscountValue}";
            }

            return new BasketDTO(
                totalBeforeDiscount,
                discount?.Code,
                $"{discount?.DiscountPercentage}%",
                discountValue,
                totalAfterDiscount,
                GetProducts(productIds)
            );
        }

        public ProductsDTO GetProducts(long[] productIds)
            => new ProductsDTO(_productRepository.Get().Where(x => productIds.Any(y => y == x.Id)).Select(x => new ProductDTO(x.Id, x.Name, x.Price)).ToArray());

        public long? AddProductToBasket(long userId, long productId)
            => userId == 0 ? null : _userBasketRepository.Add(new UserProductBasket(userId, productId));
                
    }
}
