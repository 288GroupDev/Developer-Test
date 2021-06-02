using _288Group.ECommerceShop.Persistence.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace _288Group.ECommerceShop.Persistence.Database
{
    public class ECommerceShopContext : DbContext, IECommerceShopContext
    {
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProductBasket> ShoppingCarts { get; set; }
        public DbSet<DiscountCode> DiscountCodes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=C:\288GroupECommerceShop.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product("Wooden Spoon", (decimal)2.99) { Id = 1 });
            modelBuilder.Entity<Product>().HasData(new Product("Dax Cobra", (decimal)28500.00) { Id = 2 });
            modelBuilder.Entity<Product>().HasData(new Product("Sunglasses", (decimal)6.99) { Id = 3 });
            modelBuilder.Entity<Product>().HasData(new Product("Kite", (decimal)15.99) { Id = 4 });
            modelBuilder.Entity<Product>().HasData(new Product("LEGO 75257 Star Wars Millennium Falcon", (decimal)112.50) { Id = 5 });

            modelBuilder.Entity<User>().HasData(new User("Fred", "ABC") { Id = 1 });
            modelBuilder.Entity<User>().HasData(new User("James", "ABC") { Id = 2 });

            modelBuilder.Entity<DiscountCode>().HasData(new DiscountCode("EverythingIsAwesome", 20) { Id = 1 }); 
        }

        public IQueryable<ErrorLog> GetErrorLog()
            => ErrorLogs;

        public IQueryable<Product> GetProduct()
            => Products;

        public IQueryable<User> GetUser()
            => Users;

        public IQueryable<UserProductBasket> GetShoppingCart()
            => ShoppingCarts;

        public IQueryable<DiscountCode> GetDiscountCode()
            => DiscountCodes;        
    }
}
