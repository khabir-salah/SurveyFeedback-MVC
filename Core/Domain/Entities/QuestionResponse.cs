namespace Survey_Feedback_App.Core.Domain.Entities
{
    public class QuestionResponse : Auditables
    {
        public string QuestionId { get; set; }
        public Question Question { get; set; }
        public ICollection<QuestionResponseOption> QuestionResponseOption { get; set; } = new HashSet<QuestionResponseOption>();
        public string? QuestionOptionText { get; set; }

    }
}
