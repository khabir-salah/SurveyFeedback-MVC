using Survey_Feedback_App.Core.Application.DTOs.RequestDTO;
using Survey_Feedback_App.Core.Domain.Entities;
using Survey_Feedback_App.Core.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Survey_Feedback_App.Core.Application.DTOs.ResponseDTO
{
    public class SurveyResponseModel
    {
        public string UsersUnregId { get; set; }
        public string SurveyId { get; set; }
        public string Title { get; set; }
        public List<QuestionResponseModel> Questions { get; set; } = new List<QuestionResponseModel>();
    }
}
