namespace _288Group.ECommerceShop.Persistence.Model
{
    public record DiscountCode
    (
        string Code,
        int DiscountPercentage        
    ) 
        : DatedLongIdEntity;
}
