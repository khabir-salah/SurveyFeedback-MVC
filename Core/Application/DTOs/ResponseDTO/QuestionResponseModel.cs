using Survey_Feedback_App.Core.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Survey_Feedback_App.Core.Application.DTOs.ResponseDTO
{
    public class QuestionResponseModel
    {
            public string QuestionId { get; set; }
            public string QuestionText { get; set; }
            public Types Type { get; set; }
            public string Response { get; set; }
            public ICollection<OptionResponseModel> Options { get; set; } = new List<OptionResponseModel>();
            public ICollection<string> SelectedOptions { get; set; } = new List<string>();
    }

    public class ResponseQuestionModel
    {
        public string QuestionId { get; set; }
        public string QuestionText { get; set; }
        public Types Type { get; set; }
        public string? Response { get; set; }
        public ICollection<string?> SelectedOptions { get; set; } = new List<string>();
    }
}
