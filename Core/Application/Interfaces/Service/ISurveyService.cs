using Survey_Feedback_App.Core.Application.DTOs.RequestDTO;
using Survey_Feedback_App.Core.Application.DTOs.ResponseDTO;

namespace Survey_Feedback_App.Core.Application.Interfaces.Service
{
    public interface ISurveyService
    {
        SurveyResponseModel Create(SurveyRequestModel request);


        SurveyResponseModel Get(int Id);



        bool IsDelete(int Id);


        // public Survey GetSurvey(string title);


        ICollection<SurveyResponseModel> GetByUser();


        ICollection<SurveyResponseModel> GetAllDenied();

        ICollection<SurveyResponseModel> GetDeniedSurveyByClient(int Id);


        ICollection<SurveyResponseModel> GetApprovedSurveyByClient(int Id);

        ICollection<SurveyResponseModel> GetPendingSurveyByClient(int Id);


        ICollection<SurveyResponseModel> ViewAllApprovedSurvey();

        ICollection<SurveyResponseModel> GetAllPendingSurvey();
    }
}
