using Survey_Feedback_App.Core.Domain.Entities;
using Survey_Feedback_App.Core.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Survey_Feedback_App.Core.Application.DTOs.ResponseDTO
{
    public class SurveyResponseModel
    {
        public int SurveyId { get; set; }
        public int UsersRegId { get; set; }

        [Required]
        public string Title { get; set; } = default!;
        public DateTime TmeCreated { get; set; }
        public Status status { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
        public List<Feedback> Feedbacks { get; set; } = new List<Feedback>();
        public UsersReg User { get; set; }
    }
}
