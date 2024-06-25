using Survey_Feedback_App.Core.Application.DTOs.RequestDTO;
using Survey_Feedback_App.Core.Application.DTOs.ResponseDTO;
using Survey_Feedback_App.Core.Domain.Entities;

namespace Survey_Feedback_App.Core.Application.Interfaces.Service
{
    public interface ISurveyService
    {
        BaseResponse<ICollection<SurveyResponseModel>> GetUserSurvey(string id);
        int GetSurveyCount(string userId);
        Survey GetById(string Id);
        bool IsDelete(string id);
        BaseResponse<ICollection<SearchModel>> SeachSurvey(string title);
    }
}
