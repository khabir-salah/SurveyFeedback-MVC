using Survey_Feedback_App.Core.Domain.Entities;

namespace Survey_Feedback_App.Core.Application.Interfaces.Repository
{
    public interface IOptionRepository
    {
        Option Add(Option request);
        Option GetById(string id);
        void Update(Option request);
        QuestionResponseOption AddResponseOption(QuestionResponseOption request);
    }
}
