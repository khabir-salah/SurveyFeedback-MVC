using Survey_Feedback_App.Core.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Survey_Feedback_App.Core.Domain.Entities
{
    public class Survey : Auditables
    {
        public string UsersRegId { get; set; } = default!;
        [Required]
        public string Title { get; set; } = default!;
        public DateTime TmeCreated { get; set; }
        public DateTime EndTime { get; set; }
        public string? Upload { get; set; }
        public int SurveyCount { get; set; }
        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
