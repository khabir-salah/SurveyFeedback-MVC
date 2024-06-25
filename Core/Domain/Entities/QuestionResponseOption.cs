namespace Survey_Feedback_App.Core.Domain.Entities
{
    public class QuestionResponseOption : Auditables
    {
        public string QuestionResponseId { get; set; }
        public string OptionId { get; set; }
        public Option Option { get; set; }
        public QuestionResponse QuestionResponse { get; set; }

    }
}
