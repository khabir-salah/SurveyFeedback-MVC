using Survey_Feedback_App.Core.Application.DTOs.RequestDTO;
using Survey_Feedback_App.Core.Application.DTOs.ResponseDTO;

namespace Survey_Feedback_App.Core.Application.Interfaces.Service
{
    public interface ICreateSurveyService
    {
        BaseResponse<string> Create(SurveyRequestModel request);
        BaseResponse<ICollection<SurveyResponseModel>> GetUserSurvey(string id);


    }
}
