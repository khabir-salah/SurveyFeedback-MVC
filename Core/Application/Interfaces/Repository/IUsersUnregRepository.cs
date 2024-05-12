using Survey_Feedback_App.Core.Domain.Entities;

namespace Survey_Feedback_App.Core.Application.Interfaces.Repository
{
    public interface IUsersUnregRepository
    {
        ICollection<UsersUnreg> GetAll();

        int Add(UsersUnreg unRegistered);
        UsersUnreg Get(int Id);
    }
}
