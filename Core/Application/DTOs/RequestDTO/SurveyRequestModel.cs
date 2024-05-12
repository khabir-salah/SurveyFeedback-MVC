using Survey_Feedback_App.Core.Domain.Entities;
using Survey_Feedback_App.Core.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Survey_Feedback_App.Core.Application.DTOs.RequestDTO
{
    public class SurveyRequestModel
    {
        public int UsersRegId { get; set; }

        [Required]
        public string Title { get; set; } = default!;
        public List<Question> Questions { get; set; } = new List<Question>();
    }
}
