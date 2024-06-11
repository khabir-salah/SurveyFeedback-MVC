using Survey_Feedback_App.Core.Domain.Entities;

namespace Survey_Feedback_App.Core.Application.Interfaces.Repository
{
    public interface ISurveyResposeRepository
    {
        SurveyResponse Add(SurveyResponse feedback);
        ICollection<SurveyResponse> GetAll();
        SurveyResponse Get(string Id);
    }
}
