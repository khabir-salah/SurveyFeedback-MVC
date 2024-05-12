using Survey_Feedback_App.Core.Domain.Entities;

namespace Survey_Feedback_App.Core.Application.Interfaces.Repository
{
    public interface IFeedbackRepository
    {
        int Add(Feedback feedback);
        ICollection<Feedback> GetAll();
        Feedback Get(int Id);
    }
}
