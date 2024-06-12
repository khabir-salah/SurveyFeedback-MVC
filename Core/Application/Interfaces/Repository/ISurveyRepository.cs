using Survey_Feedback_App.Core.Domain.Entities;
using Survey_Feedback_App.Core.Domain.Enum;

namespace Survey_Feedback_App.Core.Application.Interfaces.Repository
{
    public interface ISurveyRepository
    {
        Survey Add(Survey survey);
        ICollection<Survey> GetAll();
        ICollection<Survey> GetByUser(string Id);
        void IsDelete(string Id);
        Survey GetById(string Id);
        public void Update(Survey survey);
    }
}
