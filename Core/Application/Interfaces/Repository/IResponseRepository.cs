using Survey_Feedback_App.Core.Domain.Entities;

namespace Survey_Feedback_App.Core.Application.Interfaces.Repository
{
    public interface IResponseRepository
    {
        int Add(Response response);
        Response Get(int id);
    }
}
