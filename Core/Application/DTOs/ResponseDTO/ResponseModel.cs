using Survey_Feedback_App.Core.Domain.Entities;

namespace Survey_Feedback_App.Core.Application.DTOs.ResponseDTO
{
    public class ResponseModel
    {
        public string Text { get; set; }
        public int FeedbackId { get; set; }
        public Question Questions { get; set; }
        public SurveyResponse Feedbacks { get; set; }
    }
}
