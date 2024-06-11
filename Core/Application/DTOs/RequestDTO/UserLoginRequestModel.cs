using System.ComponentModel.DataAnnotations;

namespace Survey_Feedback_App.Core.Application.DTOs.RequestDTO
{
    public class UserLoginRequestModel
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
