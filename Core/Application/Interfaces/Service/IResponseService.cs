using Survey_Feedback_App.Core.Application.DTOs.RequestDTO;
using Survey_Feedback_App.Core.Application.DTOs.ResponseDTO;

namespace Survey_Feedback_App.Core.Application.Interfaces.Service
{
    public interface IResponseService
    {
        BaseResponse<SurveyResponseModel> ViewSurvey(string Id);
        BaseResponse<SurveyResponseModel> TakeSurvey(string Id, string email);

        bool IsFeedbackExist(string UserId, string SurveyId);
        bool IsDelete(string id);

        BaseResponse<SurveyResponseModel> AddResponse(SurveyResponseModel response, string email);
    }
}
