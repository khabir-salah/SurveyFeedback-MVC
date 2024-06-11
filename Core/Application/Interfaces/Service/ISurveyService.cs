using Survey_Feedback_App.Core.Application.DTOs.RequestDTO;
using Survey_Feedback_App.Core.Application.DTOs.ResponseDTO;

namespace Survey_Feedback_App.Core.Application.Interfaces.Service
{
    public interface ISurveyService
    {


        BaseResponse<SurveyResponseModel> Get(string Id);



        bool IsDelete(int Id);


        // public Survey GetSurvey(string title);


        BaseResponse<ICollection<SurveyResponseModel>> GetByUser();


        BaseResponse<ICollection<SurveyResponseModel>> GetAllDenied();

        BaseResponse<ICollection<SurveyResponseModel>> GetDeniedSurveyByClient(int Id);


        BaseResponse<ICollection<SurveyResponseModel>> GetApprovedSurveyByClient(int Id);

        BaseResponse<ICollection<SurveyResponseModel>> GetPendingSurveyByClient(int Id);


        BaseResponse<ICollection<SurveyResponseModel>> GetAllApproved();

        BaseResponse<ICollection<SurveyResponseModel>> GetAllPending();
    }
}
