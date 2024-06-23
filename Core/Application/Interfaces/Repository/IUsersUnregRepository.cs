using Survey_Feedback_App.Core.Domain.Entities;
using System.Linq.Expressions;

namespace Survey_Feedback_App.Core.Application.Interfaces.Repository
{
    public interface IUsersUnregRepository
    {
        //ICollection<UsersUnreg> GetAll();

        UsersUnreg Add(UsersUnreg unRegistered);
        UsersUnreg Get(Expression<Func<UsersUnreg, bool>> predicate);

    }
}
