using _288Group.ECommerceShop.Persistence.Model;
using System.Linq;

namespace _288Group.ECommerceShop.Persistence.Database
{
    public class UserRepository : IUserRepository
    {
        private readonly IECommerceShopContext _context;

        public UserRepository(IECommerceShopContext context)
            => _context = context;

        public IQueryable<User> Get()
            => _context.GetUser();

        public long Add(User entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public void Update(User entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }     
    }
}
