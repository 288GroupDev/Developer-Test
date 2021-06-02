namespace _288Group.ECommerceShop.DTOs
{
    public record AjaxResponseDTO
    (
        bool ErrorOccured,
        string ErrorMessage,
        object Payload
    );
}
