using _288Group.ECommerceShop.Persistence.Model;
using System.Linq;

namespace _288Group.ECommerceShop.Persistence.Database
{
    public interface IECommerceShopContext : IDbContext
    {
        IQueryable<ErrorLog> GetErrorLog();
        IQueryable<Product> GetProduct();
        IQueryable<UserProductBasket> GetShoppingCart();
        IQueryable<User> GetUser();
    }
}
