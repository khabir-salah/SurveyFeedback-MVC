using Survey_Feedback_App.Core.Application.Interfaces.Repository;
using Survey_Feedback_App.Infastructor.Context;

namespace Survey_Feedback_App.Infastructor.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SurveyFeedbackContext _context;
        public UnitOfWork(SurveyFeedbackContext context)
        {
            _context = context;
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
