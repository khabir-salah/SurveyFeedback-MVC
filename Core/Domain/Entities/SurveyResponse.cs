namespace Survey_Feedback_App.Core.Domain.Entities
{
    public class SurveyResponse : Auditables
    {
        public string SurveyId { get; set; }
        public List<QuestionResponse> QuestionResponses { get; set; } = new List<QuestionResponse>();
        public string UsersUnregId { get; set; }
    }
}
