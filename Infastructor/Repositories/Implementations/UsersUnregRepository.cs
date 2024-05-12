using Survey_Feedback_App.Core.Application.Interfaces.Repository;
using Survey_Feedback_App.Core.Domain.Entities;
using Survey_Feedback_App.Infastructor.Context;

namespace Survey_Feedback_App.Infastructor.Repositories.Implementations
{
    public class UsersUnregRepository : IUsersUnregRepository
    {
        private readonly SurveyFeedbackContext _context;
        public UsersUnregRepository(SurveyFeedbackContext context)
        {
            _context = context;
        }

        public int Add(UsersUnreg unRegistered)
        {
            _context.UsersUnregs.Add(unRegistered);
            return _context.SaveChanges();
        }

        public UsersUnreg? Get(int Id)
        {
           var user = _context.UsersUnregs.FirstOrDefault(u => u.UsersUnregId == Id);
            return user;
        }

        public ICollection<UsersUnreg> GetAll()
        {
            var users = _context.UsersUnregs.Select(u => new UsersUnreg
            {
                UsersUnregId = u.UsersUnregId,
                Email = u.Email,
            }).ToList();
            return users;
        }

       
    }
}
