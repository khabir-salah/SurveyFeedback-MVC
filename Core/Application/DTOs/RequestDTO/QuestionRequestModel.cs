using Survey_Feedback_App.Core.Domain.Entities;
using Survey_Feedback_App.Core.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Survey_Feedback_App.Core.Application.DTOs.RequestDTO
{
    public class QuestionRequestModel
    {
        public string QuestionText { get; set; }
        public Types Type { get; set; }
        public List<OptionRequestModel> Options { get; set; }
    }
    public class OptionRequestModel
    {
        public string QuestionId { get; set; }
        public Question Question { get; set; }
        public string OptionText { get; set; }
    }
}
