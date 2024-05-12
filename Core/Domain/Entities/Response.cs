namespace Survey_Feedback_App.Core.Domain.Entities
{
    public class Response
    {
        public int ResponseId { get; set; }
        public string Text { get; set; }
        public int QuestionId { get; set; }
        public int FeedbackId { get; set; }
        public Question Questions { get; set; }
    }
}
