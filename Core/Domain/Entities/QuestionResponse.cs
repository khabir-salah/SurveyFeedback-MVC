namespace Survey_Feedback_App.Core.Domain.Entities
{
    public class QuestionResponse : Auditables
    {
        public string QuestionId { get; set; }
        public string Response { get; set; }
    }
}
