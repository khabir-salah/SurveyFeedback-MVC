using Survey_Feedback_App.Core.Domain.Entities;
using System.Linq.Expressions;

namespace Survey_Feedback_App.Core.Application.Interfaces.Repository
{
    public interface IUsersRegRepository
    {
        //ICollection<UsersReg> GetAll();
        UsersReg Add(UsersReg user);
        UsersReg Get(Expression<Func<UsersReg, bool>> predicate);

    }
}
