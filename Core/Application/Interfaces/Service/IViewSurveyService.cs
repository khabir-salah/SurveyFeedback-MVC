using Survey_Feedback_App.Core.Application.DTOs.RequestDTO;
using Survey_Feedback_App.Core.Application.DTOs.ResponseDTO;

namespace Survey_Feedback_App.Core.Application.Interfaces.Service
{
    public interface IViewSurveyService
    {
        BaseResponse<SurveyResponseModel> ViewSurvey(string Id);
    }
}
