using Survey_Feedback_App.Core.Domain.Entities;

namespace Survey_Feedback_App.Core.Application.DTOs.ResponseDTO
{
    public class FeedbackResponseModel
    {
        public int FeedbackId { get; set; }
        public int UsersUnregId { get; set; }
        public int SurveyId { get; set; }
        public Survey Surveys { get; set; }
        public List<Response?> Responses { get; set; }
        public List<Question> Questions { get; set; }
        public DateTime Time { get; set; }
    }
}
