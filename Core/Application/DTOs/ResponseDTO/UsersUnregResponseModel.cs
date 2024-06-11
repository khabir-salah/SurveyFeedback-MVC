using System.ComponentModel.DataAnnotations;

namespace Survey_Feedback_App.Core.Application.DTOs.ResponseDTO
{
    public class UsersUnregResponseModel
    {
        public string UsersUnregId { get; set; }
        public string Email { get; set; } = default!;
    }
}
