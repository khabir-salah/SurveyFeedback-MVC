using System.ComponentModel.DataAnnotations;

namespace Survey_Feedback_App.Core.Application.DTOs.ResponseDTO
{
    public class UsersRegResponseModel
    {
        public int UsersRegId { get; set; }
        [DataType(DataType.EmailAddress), Required]
        [RegularExpression(@"@[a-zA-Z0-9.-]+(com|COM)$", ErrorMessage = "Email not valid")]
        [Key]

        public string Email { get; set; } = default!;
        [Required, MinLength(4), MaxLength(15)]
        public string UserName { get; set; } = default!;
        public string Role {  get; set; } = default!;
    }
}
