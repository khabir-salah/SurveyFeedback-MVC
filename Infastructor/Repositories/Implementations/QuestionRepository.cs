using Survey_Feedback_App.Core.Application.Interfaces.Repository;
using Survey_Feedback_App.Core.Domain.Entities;
using Survey_Feedback_App.Infastructor.Context;

namespace Survey_Feedback_App.Infastructor.Repositories.Implementations
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly SurveyFeedbackContext _context;
        public QuestionRepository(IQuestionRepository context)
        {
            _context = context;
        }
        public int Add(Question question)
        {
            _context.Questions.Add(question);
            return _context.SaveChanges();
        }

        public Question GetById(int id)
        {
            var question = _context.Questions.FirstOrDefault(q => q.QuestionId == id);
            return question;
        }
    }
}
