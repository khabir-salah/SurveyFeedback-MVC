using Microsoft.EntityFrameworkCore;
using Survey_Feedback_App.Core.Application.DTOs.RequestDTO;
using Survey_Feedback_App.Core.Application.DTOs.ResponseDTO;
using Survey_Feedback_App.Core.Application.Interfaces.Repository;
using Survey_Feedback_App.Core.Application.Interfaces.Service;
using Survey_Feedback_App.Core.Domain.Entities;

namespace Survey_Feedback_App.Core.Application.Services.Implementation
{
    public class FeedbackService : IFeedbackService
    {
        private readonly ISurveyResposeRepository _responseRepo;
        private readonly IUsersUnregRepository _userUnreg;



        public FeedbackService( ISurveyResposeRepository responseRepo,  IUsersUnregRepository userUnreg)
        {
            _responseRepo = responseRepo;
            _userUnreg = userUnreg;
        }

        public BaseResponse<ICollection<SurveyResponseViewModel>> GetFeedbackById(string Id)
        {
            var feedback = _responseRepo.GetAll().Where(s => s.SurveyId == Id ).ToList();
            return feedback != null ? new BaseResponse<ICollection<SurveyResponseViewModel>>
            {
                IsSuccessfull = true,
                message = "Successfull",
                Data =  feedback.Select(a => new SurveyResponseViewModel
                {
                    Survey = new SurveyResponseModel
                    {
                        SurveyId = a.Survey.Id,
                        Title = a.Survey.Title,
                       
                    },
                    UsersUnreg = new UsersUnregResponseModel { Email = a.UserUnreg.Email},
                    QuestionResponses = a.QuestionResponses
                    
                }).ToList()
                
            } : null;
        }

        public bool IsFeedbackExist(string email, string SurveyId)
        {
            var getUser = _userUnreg.Get(s => s.Email == email);
            var checkEmail = _responseRepo.GetAll().Where(s => s.Id == SurveyId && s.UsersUnregId == getUser.Id).Any();
            if (checkEmail)
            {
                return true;
            }
            return false;
        }
    }
}
