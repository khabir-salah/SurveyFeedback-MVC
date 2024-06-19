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
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISurveyResposeRepository _responseRepo;
        private readonly ISurveyRepository _surveyRepo;
        private readonly IIdentityService _identity;



        public FeedbackService(ISurveyRepository surveyRepo, IUnitOfWork unitOfWork, ISurveyResposeRepository responseRepo, IIdentityService identity)
        {
            _unitOfWork = unitOfWork;
            _surveyRepo = surveyRepo;
            _responseRepo = responseRepo;
            _identity = identity;
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
    }
}
