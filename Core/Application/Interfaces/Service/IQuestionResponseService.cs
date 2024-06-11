using Survey_Feedback_App.Core.Application.DTOs.RequestDTO;
using Survey_Feedback_App.Core.Application.DTOs.ResponseDTO;

namespace Survey_Feedback_App.Core.Application.Interfaces.Service
{
    public interface IQuestionResponseService
    {
        BaseResponse<SurveyResponseModel> TakeSurvey(string Id);
        BaseResponse<SurveyResponseModel> GetResponse(int Id);
        void AddResponse(SurveyResponseModel response);
    }
}
