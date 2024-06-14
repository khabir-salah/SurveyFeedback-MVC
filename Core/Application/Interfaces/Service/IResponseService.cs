using Survey_Feedback_App.Core.Application.DTOs.RequestDTO;
using Survey_Feedback_App.Core.Application.DTOs.ResponseDTO;

namespace Survey_Feedback_App.Core.Application.Interfaces.Service
{
    public interface IResponseService
    {
        BaseResponse<SurveyResponseModel> TakeSurvey(string Id);
        bool IsFeedbackExist(string UserId, string SurveyId);

        BaseResponse<ResponseModel> AddResponse(ResponseModel response, string email);
    }
}
