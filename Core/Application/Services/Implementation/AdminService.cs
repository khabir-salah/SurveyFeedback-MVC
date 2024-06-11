using Survey_Feedback_App.Core.Application.DTOs.ResponseDTO;
using Survey_Feedback_App.Core.Application.Interfaces.Repository;
using Survey_Feedback_App.Core.Application.Interfaces.Service;

namespace Survey_Feedback_App.Core.Application.Services.Implementation
{
   /* public class AdminService : IAdminService
    {
        private readonly IUsersRegRepository _usersRegRepo;
        private readonly IUsersUnregRepository _usersUnregRepo;
        private readonly ISurveyRepository _surveyRepo;
        private readonly IUnitOfWork _unitOfWork;


        public AdminService(IUsersRegRepository usersRegRepo, IUsersUnregRepository usersUnregRepo, ISurveyRepository surveyRepo , IUnitOfWork unitOfWork)
        {
            _usersRegRepo = usersRegRepo;
            _usersUnregRepo = usersUnregRepo;
            _surveyRepo = surveyRepo;
            _unitOfWork = unitOfWork;
        }

        public void ApproveSurvey(int Id)
        {
            var approve = _surveyRepo.GetById(Id);
            if(approve != null)
            {
                approve.status = Domain.Enum.Status.Approved;
                _surveyRepo.Update(approve);
            }
        }

        public void DenySurvey(int Id)
        {
            var deny = _surveyRepo.GetById(Id);
            if (deny != null)
            {
                deny.status = Domain.Enum.Status.Denied;
                _surveyRepo.Update(deny);
            }
        }

        public ICollection<UsersRegResponseModel> GetRegisteredUsers()
        {
            var user = _usersRegRepo.GetAll().Select(x => new UsersRegResponseModel
            {
                Email = x.Email,
                Role = x.Role,
                UserName = x.UserName,
                UsersRegId = x.UsersRegId,
            }).ToList();
            return user;
        }

        public ICollection<UsersUnregResponseModel> GetUnRegisteredUsers()
        {
            var user = _usersUnregRepo.GetAll().Select(u => new UsersUnregResponseModel
            {
                Email = u.Email,
                UsersUnregId = u.UsersUnregId
            }).ToList();
            return user;
        }
    }*/
}
