using Survey_Feedback_App.Core.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Survey_Feedback_App.Core.Application.DTOs.RequestDTO
{
    public class QuestionRequestModel
    {
        [Required]
        public string Text { get; set; } = default!;
        public Types Type { get; set; }
        public ICollection<string> option { get; set; }
    }
}
