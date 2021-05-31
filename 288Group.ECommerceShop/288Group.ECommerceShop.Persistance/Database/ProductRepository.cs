using _288Group.ECommerceShop.Persistence.Model;
using System.Linq;

namespace _288Group.ECommerceShop.Persistence.Database
{
    public class ProductRepository : IProductRepository
    {
        private readonly IECommerceShopContext _context;

        public ProductRepository(IECommerceShopContext context)
            => _context = context;

        public IQueryable<Product> Get()
            => _context.GetProduct();

        public long Add(Product entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public void Update(Product entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }     
    }
}
