using System;

namespace _288Group.ECommerceShop.DTOs
{
    public record CreateNewUserResponseDTO
    (
        bool Success,
        string UserFriendlyMessage,
        Exception ex = null
    );
}
