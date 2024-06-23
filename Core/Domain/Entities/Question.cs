using Survey_Feedback_App.Core.Domain.Enum;
namespace Survey_Feedback_App.Core.Domain.Entities
{
    public class Question : Auditables
    {
        public string QuestionText { get; set; } = default!;
        public Types Type {  get; set; }
        public ICollection<Option> Options { get; set; } = new List<Option>();
        public string SurveyId { get; set; }
        public Survey Surveys { get; set; }
    }
}
