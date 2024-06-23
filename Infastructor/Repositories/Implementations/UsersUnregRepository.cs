using Survey_Feedback_App.Core.Application.Interfaces.Repository;
using Survey_Feedback_App.Core.Domain.Entities;
using Survey_Feedback_App.Infastructor.Context;
using System.Linq.Expressions;

namespace Survey_Feedback_App.Infastructor.Repositories.Implementations
{
    public class UsersUnregRepository : IUsersUnregRepository
    {
        private readonly SurveyFeedbackContext _context;
        public UsersUnregRepository(SurveyFeedbackContext context)
        {
            _context = context;
        }

        public UsersUnreg Add(UsersUnreg unRegistered)
        {
            _context.UsersUnregs.Add(unRegistered);
            return unRegistered;
        }

       public UsersUnreg Get(Expression<Func<UsersUnreg, bool>> predicate)
        {
            var user = _context.UsersUnregs.FirstOrDefault(predicate);
            return user;
        }

        //public ICollection<UsersUnreg> GetAll()
        //{
        //    var users = _context.UsersUnregs.ToList();
        //    return users;
        //}

       
    }
}
