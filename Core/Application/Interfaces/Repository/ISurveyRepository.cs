using Survey_Feedback_App.Core.Domain.Entities;
using Survey_Feedback_App.Core.Domain.Enum;

namespace Survey_Feedback_App.Core.Application.Interfaces.Repository
{
    public interface ISurveyRepository
    {
        Survey Add(Survey survey);
        //ICollection<Survey> GetAll();
        ICollection<Survey> GetByUser(string Id);
        bool IsDelete(string Id);
        Survey GetById(string Id);
        ICollection<Survey> UserSurveyByTitle(string title, string userId);
    }
}
