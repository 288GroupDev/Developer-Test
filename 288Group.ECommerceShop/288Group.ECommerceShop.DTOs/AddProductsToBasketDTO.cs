namespace _288Group.ECommerceShop.DTOs
{
    public record AddProductsToBasketDTO
        (
           long UserId,
           long[] ProductIds
        );
}
