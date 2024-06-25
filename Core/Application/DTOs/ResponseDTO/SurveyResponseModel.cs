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
        public string Uplaod { get; set; }
        public List<QuestionResponseModel> Questions { get; set; } 
        public DateTime EndTime { get; set; }
        public DateTime TimeCreated { get; set; }
    }
    public class SurveyResponseViewModel
    {
        public UsersUnregResponseModel UsersUnreg { get; set; }
        public SurveyResponseModel Survey { get; set; }

       
        public List<QuestionResponseResponseModel> QuestionResponses { get; set; } = new List<QuestionResponseResponseModel>();
    }

    public class SurveyRequestModels
    {
        public string SurveyId { get; set; }
        public int FeedbackCount { get; set; }
        public List<ResponseQuestionModel> Questions { get; set; }
    }
}
