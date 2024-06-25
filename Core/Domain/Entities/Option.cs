namespace Survey_Feedback_App.Core.Domain.Entities
{
    public class Option : Auditables
    {
        public string QuestionId { get; set; }
        public Question Question { get; set; }
        public string OptionText { get; set; }
        public int Count { get; set; }
        public ICollection<QuestionResponseOption> QuestionResponseOption { get; set; } = new HashSet<QuestionResponseOption>();

    }
}
