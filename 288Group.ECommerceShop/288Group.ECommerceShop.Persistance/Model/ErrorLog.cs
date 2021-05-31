namespace _288Group.ECommerceShop.Persistence.Model
{
    public record ErrorLog
    (
        string ErrorMessage,
        string ExceptionMessage,
        string InnerExceptionMessage
    ) 
        : DatedLongIdEntity;
}
