using Survey_Feedback_App.Core.Domain.Entities;

namespace Survey_Feedback_App.Core.Application.Interfaces.Repository
{
    public interface IUsersRegRepository
    {
        ICollection<UsersReg> GetAll();
        int Add(UsersReg user);
        UsersReg Get(int Id);
    }
}
