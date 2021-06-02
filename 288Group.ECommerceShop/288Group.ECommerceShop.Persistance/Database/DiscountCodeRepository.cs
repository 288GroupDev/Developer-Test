using _288Group.ECommerceShop.Persistence.Model;
using System.Linq;

namespace _288Group.ECommerceShop.Persistence.Database
{
    public class DiscountCodeRepository : IDiscountCodeRepository
    {
        private readonly IECommerceShopContext _context;

        public DiscountCodeRepository(IECommerceShopContext context)
            => _context = context;

        public IQueryable<DiscountCode> Get()
            => _context.GetDiscountCode();

        public long Add(DiscountCode entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public void Update(DiscountCode entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }     
    }
}
