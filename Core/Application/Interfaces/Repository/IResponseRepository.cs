using Survey_Feedback_App.Core.Domain.Entities;

namespace Survey_Feedback_App.Core.Application.Interfaces.Repository
{
    public interface IResponseRepository
    {
        SurveyResponse Add(SurveyResponse response);
        SurveyResponse Get(string id);
    }
}
