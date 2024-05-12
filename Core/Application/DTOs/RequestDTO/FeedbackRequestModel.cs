using Survey_Feedback_App.Core.Domain.Entities;

namespace Survey_Feedback_App.Core.Application.DTOs.RequestDTO
{
    public class FeedbackRequestModel
    {
        public Survey Surveys { get; set; }
        public List<Response?> Responses { get; set; }
        public List<Question> Questions { get; set; }
    }
}
