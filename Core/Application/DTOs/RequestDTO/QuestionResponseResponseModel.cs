using Survey_Feedback_App.Core.Application.DTOs.ResponseDTO;
using Survey_Feedback_App.Core.Domain.Enum;

namespace Survey_Feedback_App.Core.Application.DTOs.RequestDTO
{
    public class QuestionResponseResponseModel
    {
        public ICollection<OptionResponseModel> Options { get; set; } = new List<OptionResponseModel>();
        public string QuestionText { get; set; } = default!;
        public Types Type { get; set; }
        public string? QuestionOptionText { get; set; }


    }
}
