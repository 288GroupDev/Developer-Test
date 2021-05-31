using System.Linq;

namespace _288Group.ECommerceShop.Persistence.Database
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        long Add(T entity);
        void Update(T entity);
    }
}
