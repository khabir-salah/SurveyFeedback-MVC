using Microsoft.EntityFrameworkCore;
using Survey_Feedback_App.Core.Application.Interfaces.Repository;
using Survey_Feedback_App.Core.Domain.Entities;
using Survey_Feedback_App.Infastructor.Context;
using System.Linq.Expressions;

namespace Survey_Feedback_App.Infastructor.Repositories.Implementations
{
    public class UsersRegRepository : IUsersRegRepository
    {
        private readonly SurveyFeedbackContext _context;
        public UsersRegRepository(SurveyFeedbackContext context)
        {
            _context = context;
        }

        public UsersReg Add(UsersReg user)
        {
            _context.UsersRegs.Add(user);
            return  user;
        }



        public UsersReg Get(Expression<Func<UsersReg, bool>> predicate)
        {
            var user = _context.UsersRegs.FirstOrDefault(predicate);
            return user;
        }

        public ICollection<UsersReg> GetAll()
        {
            var users = _context.UsersRegs.ToList();
            return users;
        }

    }
}
