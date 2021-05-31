using _288Group.ECommerceShop.Persistence.Model;
using System.Linq;

namespace _288Group.ECommerceShop.Persistence.Database
{
    public class ShoppingCartRepository : IUserBasketRepository
    {
        private readonly IECommerceShopContext _context;

        public ShoppingCartRepository(IECommerceShopContext context)
            => _context = context;

        public IQueryable<UserProductBasket> Get()
            => _context.GetShoppingCart();

        public long Add(UserProductBasket entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public void Update(UserProductBasket entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }     
    }
}
