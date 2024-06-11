using System.ComponentModel.DataAnnotations;

namespace Survey_Feedback_App.Core.Application.DTOs.RequestDTO
{
    public class UsersRegRequestModel
    {
        [Required]
        public string FullName { get; set; } = default!;

        [DataType(DataType.EmailAddress), Required]
        [RegularExpression(@"@[a-zA-Z0-9.-]+(com|COM)$", ErrorMessage = "Email not valid")]

        public string Email { get; set; } = default!;
        [Required, DataType(DataType.Password), MinLength(5)]
        public string Password { get; set; } = default!;
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = default!;
        [Required, MinLength(4), MaxLength(15)]
        public string UserName { get; set; } = default!;
    }
}
