using Survey_Feedback_App.Core.Application.DTOs.RequestDTO;
using Survey_Feedback_App.Core.Application.DTOs.ResponseDTO;

namespace Survey_Feedback_App.Core.Application.Interfaces.Service
{
    public interface IUsersRegService
    {
        UsersRegResponseModel RegisterUser(UsersRegRequestModel request);


        UsersRegResponseModel UserLogin(UserLoginRequestModel request);


        UsersRegResponseModel GetUser(string email);
    }
}
