using Survey_Feedback_App.Core.Domain.Entities;
using Survey_Feedback_App.Core.Domain.Enum;

namespace Survey_Feedback_App.Core.Application.Interfaces.Repository
{
    public interface ISurveyRepository
    {
        int Add(Survey survey);
        ICollection<Survey> GetAll();
        ICollection<Survey> GetByUser(int Id);
        bool IsDelete(int Id);
        Survey Get(int Id);
    }
}
