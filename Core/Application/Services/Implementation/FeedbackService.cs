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
                    QuestionResponses = a.QuestionResponses.Select(s => new QuestionResponseResponseModel
                    {
                        Type = s.Question.Type,
                        QuestionText = s.Question.QuestionText,
                        QuestionOptionText = s.QuestionOptionText,
                        Options = s.QuestionResponseOption.Select(o => new OptionResponseModel
                        {
                            OptionId = o.OptionId,
                            OptionText = o.Option.OptionText
                        }).ToList(),
                    }).ToList(),
                    
                }).ToList()
                
            } : null;
        }

        public bool IsFeedbackExist(string email, string SurveyId)
        {
            var getUser = _userUnreg.Get(s => s.Email == email);
            if (getUser == null)
                return false;
            var checkEmail = _responseRepo.GetAll().Where(s => s.SurveyId == SurveyId && s.UsersUnregId == getUser.Id).Any();
            if (checkEmail)
            {
                return true;
            }
            return false;
        }
    }
}
