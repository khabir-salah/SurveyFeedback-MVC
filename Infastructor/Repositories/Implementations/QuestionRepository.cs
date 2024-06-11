using Survey_Feedback_App.Core.Application.Interfaces.Repository;
using Survey_Feedback_App.Core.Domain.Entities;
using Survey_Feedback_App.Infastructor.Context;

namespace Survey_Feedback_App.Infastructor.Repositories.Implementations
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly SurveyFeedbackContext _context;
        public QuestionRepository(SurveyFeedbackContext context)
        {
            _context = context;
        }
        public Question Add(Question question)
        {
            _context.Questions.Add(question);
            return question;
        }

        public Question GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
