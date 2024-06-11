
namespace Survey_Feedback_App.Core.Domain.Entities
{
    public class UsersReg : Auditables
    {
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string ConfirmPassword { get; set; } = default!;
        public string salt { get; set; } = default!;
        public string Role { get; set; } = default!;
    }
}
