using Survey_Feedback_App.Core.Application.DTOs.ResponseDTO;

namespace Survey_Feedback_App.Core.Application.Interfaces.Service
{
    public interface IAdminService
    {
        BaseResponse<string> ApproveSurvey(int Id);
        BaseResponse<string> DenySurvey(int Id);
        BaseResponse<ICollection<UsersRegResponseModel>> GetRegisteredUsers();
        BaseResponse<ICollection<UsersUnregResponseModel>> GetUnRegisteredUsers();
    }
}
