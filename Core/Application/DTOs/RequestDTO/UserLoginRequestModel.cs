using System.ComponentModel.DataAnnotations;

namespace Survey_Feedback_App.Core.Application.DTOs.RequestDTO
{
    public class UserLoginRequestModel
    {
        [DataType(DataType.EmailAddress), Required]
        [RegularExpression(@"@[a-zA-Z0-9.-]+(com|COM)$", ErrorMessage = "Email not valid")]
        [Key]

        public string Email { get; set; } = default!;
        [Required, DataType(DataType.Password), MinLength(5)]
        public string Password { get; set; } = default!;
    }
}
