using Survey_Feedback_App.Core.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Survey_Feedback_App.Core.Domain.Entities
{
    public class Survey
    {
        public int SurveyId { get; set; }
        public int UsersRegId { get; set; }

        [Required]
        public string Title { get; set; } = default!;
        public DateTime TmeCreated { get; set; }
        public Status status { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
        public List<Feedback> Feedbacks { get; set; } = new List<Feedback>();
        public UsersReg User {  get; set; }
    }
}
