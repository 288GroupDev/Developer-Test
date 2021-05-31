using System.ComponentModel.DataAnnotations;

namespace _288Group.ECommerceShop.Web.Models
{
    public class CreateNewUserViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(255, ErrorMessage = "Max length 255 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
