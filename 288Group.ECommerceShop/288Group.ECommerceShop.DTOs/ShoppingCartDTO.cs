namespace _288Group.ECommerceShop.DTOs
{
    public record ShoppingCartDTO
    (
        long UserId,
        ProductDTO[] Products
    );
}
