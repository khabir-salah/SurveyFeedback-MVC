using Survey_Feedback_App.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Survey_Feedback_App.Core.Application.DTOs.RequestDTO
{
    public class ResponseRequestModel
    {
        [Required]
        public string Text { get; set; }
        public string SurveyId { get; set; }
        public string QuestionId { get; set; }
        public string UsersUnregId { get; set; }
    }
}
