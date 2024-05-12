using Survey_Feedback_App.Core.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Survey_Feedback_App.Core.Domain.Entities
{
    public class Question
    {
        public int QuestionId { get; set; } 
        [Required]
        public string Text { get; set; } = default!;
        public Types Type {  get; set; } 
        public ICollection<string> option { get; set; }
        public int SurveyId { get; set; }
    }
}
