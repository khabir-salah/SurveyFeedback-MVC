using Survey_Feedback_App.Core.Domain.Entities;

namespace Survey_Feedback_App.Core.Application.Interfaces.Repository
{
    public interface IQuestionRepository
    {
        Question Add(Question question);
        //Question GetById(string id);

    }
}
