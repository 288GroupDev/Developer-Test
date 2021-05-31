namespace _288Group.ECommerceShop.Persistence.Model
{
    public record UserProductBasket
    (
        long UserId,
        long ProductId
    )
        : DatedLongIdEntity;
}
