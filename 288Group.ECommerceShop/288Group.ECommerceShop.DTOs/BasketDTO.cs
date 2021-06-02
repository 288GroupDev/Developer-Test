namespace _288Group.ECommerceShop.DTOs
{
    public record BasketDTO
    (
        string TotalPriceBeforeDiscount,
        string DiscountCode,
        string DiscountPercentage,
        string DiscountValue,
        string TotalPriceAfterDiscount,
        ProductsDTO Products
    );
}
