using Survey_Feedback_App.Core.Application.Interfaces.Repository;
using Survey_Feedback_App.Core.Domain.Entities;
using Survey_Feedback_App.Infastructor.Context;

namespace Survey_Feedback_App.Infastructor.Repositories.Implementations
{
    public class UsersRegRepository : IUsersRegRepository
    {
        private readonly SurveyFeedbackContext _context;
        public UsersRegRepository(SurveyFeedbackContext context)
        {
            _context = context;
        }

        public int Add(UsersReg user)
        {
            _context.UsersRegs.Add(user);
            return  _context.SaveChanges();
        }

      

        public UsersReg? Get(int Id)
        {
            var user = _context.UsersRegs.FirstOrDefault(u => u.UsersRegId == Id);
            return user;
        }

        public ICollection<UsersReg> GetAll()
        {
            var users = _context.UsersRegs.Select(u => new UsersReg
            {
                UsersRegId = u.UsersRegId,
                Email = u.Email,
                Password = u.Password,
                UserName = u.UserName,
            }).ToList();
            return users;
        }

    }
}
