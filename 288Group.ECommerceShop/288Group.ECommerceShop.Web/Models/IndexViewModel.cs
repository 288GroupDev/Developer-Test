using _288Group.ECommerceShop.DTOs;

namespace _288Group.ECommerceShop.Web.Models
{
    public record IndexViewModel
    (
        bool UserLoggedIn,
        long UserId,
        string Username,
        ProductsDTO Products
    );
}
