using Survey_Feedback_App.Core.Domain.Entities;

namespace Survey_Feedback_App.Core.Application.DTOs.ResponseDTO
{
    public class ResponseModel
    {
        public string SurveyId { get; set; }
        public string UsersUnregId { get; set; }
        public List<QuestionResponseModel> Questions { get; set; } = new List<QuestionResponseModel>();

    }
}

