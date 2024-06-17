using Survey_Feedback_App.Core.Application.DTOs.RequestDTO;
using Survey_Feedback_App.Core.Application.DTOs.ResponseDTO;

namespace Survey_Feedback_App.Core.Application.Interfaces.Service
{
    public interface IResponseService
    {
        BaseResponse<SurveyResponseModel> ViewSurvey(string Id);
        BaseResponse<SurveyResponseModel> TakeSurvey(string Id, string email);

        bool IsDelete(string id);
        bool IsFeedbackExist(string UserId, string SurveyId);


        BaseResponse<SurveyResponseModel> AddResponse(SurveyRequestModels response, string email);
    }
}
