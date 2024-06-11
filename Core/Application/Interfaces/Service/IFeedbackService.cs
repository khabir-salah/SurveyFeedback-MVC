using Survey_Feedback_App.Core.Application.DTOs.RequestDTO;
using Survey_Feedback_App.Core.Application.DTOs.ResponseDTO;

namespace Survey_Feedback_App.Core.Application.Interfaces.Service
{
    public interface IFeedbackService
    {
        BaseResponse<string> GiveFeedback(SurveyRequestModel request);


        BaseResponse<List<SurveyRequestModel>> GetFeedbacks(int Id);
    }
}
