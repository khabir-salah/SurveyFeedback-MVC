using System.ComponentModel.DataAnnotations;

namespace Survey_Feedback_App.Core.Application.DTOs.ResponseDTO
{
    public class UsersRegResponseModel
    {
        public string UsersRegId { get; set; }

        public string Email { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Role {  get; set; } = default!;
    }
}
