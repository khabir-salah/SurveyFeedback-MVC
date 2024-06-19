namespace Survey_Feedback_App.Core.Domain.Entities
{
    public class QuestionResponse : Auditables
    {
        public string QuestionId { get; set; }
        public string OptionId { get; set; }
        public Question Question { get; set; }
        public Option Option { get; set; }

    }
}
