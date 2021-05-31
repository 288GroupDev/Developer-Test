using _288Group.ECommerceShop.Persistence.Model;
using System.Linq;

namespace _288Group.ECommerceShop.Persistence.Database
{
    public class ErrorLogRepository : IErrorLogRepository
    {
        private readonly IECommerceShopContext _context;

        public ErrorLogRepository(IECommerceShopContext context)
            => _context = context;

        public IQueryable<ErrorLog> Get()
            => _context.GetErrorLog();

        public long Add(ErrorLog entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public void Update(ErrorLog entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
