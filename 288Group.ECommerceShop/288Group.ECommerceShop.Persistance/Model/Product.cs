namespace _288Group.ECommerceShop.Persistence.Model
{
    public record Product
    (
        string Name,
        decimal Price
    )
        : DatedLongIdEntity;
}
