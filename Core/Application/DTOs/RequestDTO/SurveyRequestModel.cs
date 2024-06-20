using Survey_Feedback_App.Core.Domain.Entities;
using Survey_Feedback_App.Core.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Survey_Feedback_App.Core.Application.DTOs.RequestDTO
{
   
    public class SurveyRequestModel
    {
        public string Title { get; set; }
        public IFormFile Upload { get; set; }
        public DateTime EndTime { get; set; }
        public List<QuestionRequestModel> Questions { get; set; }
    }

}
