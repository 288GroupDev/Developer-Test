namespace _288Group.ECommerceShop.Persistence.Model
{
    public record User
    (
        string Username,
        string Password
    )
        : DatedLongIdEntity;
}
