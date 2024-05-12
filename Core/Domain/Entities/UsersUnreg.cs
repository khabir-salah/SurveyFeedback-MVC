using System.ComponentModel.DataAnnotations;

namespace Survey_Feedback_App.Core.Domain.Entities
{
    public class UsersUnreg
    {
        public int UsersUnregId { get; set; }
        [EmailAddress, Required]
        [RegularExpression(@"@[a-zA-Z0-9.-]+(com|COM)$", ErrorMessage = "Email not valid")]
        public string Email { get; set; } = default!;
    }
}
