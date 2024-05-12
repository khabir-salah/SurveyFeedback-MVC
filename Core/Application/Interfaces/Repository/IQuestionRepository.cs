using Survey_Feedback_App.Core.Domain.Entities;

namespace Survey_Feedback_App.Core.Application.Interfaces.Repository
{
    public interface IQuestionRepository
    {
        int Add(Question question);
        Question GetById(int id);

    }
}
