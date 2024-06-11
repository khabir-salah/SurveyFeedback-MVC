using Survey_Feedback_App.Core.Domain.Entities;

namespace Survey_Feedback_App.Core.Application.Interfaces.Repository
{
    public interface IQuestionResponseRepository
    {
        QuestionResponse Add(QuestionResponse response);
        QuestionResponse Get(string id);
    }
}
