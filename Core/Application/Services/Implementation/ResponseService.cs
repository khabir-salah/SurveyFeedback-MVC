using Survey_Feedback_App.Core.Application.DTOs.RequestDTO;
using Survey_Feedback_App.Core.Application.DTOs.ResponseDTO;
using Survey_Feedback_App.Core.Application.Interfaces.Repository;
using Survey_Feedback_App.Core.Application.Interfaces.Service;
using Survey_Feedback_App.Core.Domain.Entities;

namespace Survey_Feedback_App.Core.Application.Services.Implementation
{
    public class ResponseService : IResponseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IResponseRepository _responseRepo;
        private readonly ISurveyRepository _surveyRepo;
        private readonly IIdentityService _identity;
        private readonly IUsersUnregRepository _userUnreg;

        public ResponseService(IResponseRepository responseRepo, IUnitOfWork unitOfWork, ISurveyRepository surveyRepo, IIdentityService identity, IUsersUnregRepository userUnreg)
        {
            _responseRepo = responseRepo;
            _unitOfWork = unitOfWork;
            _surveyRepo = surveyRepo;
            _identity = identity;
            _userUnreg = userUnreg;
        }

        public BaseResponse<ResponseModel> AddResponse(ResponseModel response, string email)
        {
            var getUser = _userUnreg.Get(s => s.Email == email);
            if (getUser == null)
            {
                _identity.Add(email);
            }
            var feedback = new SurveyResponse
            {
                SurveyId = response.SurveyId,
                UsersUnregId = response.UsersUnregId,
                QuestionResponses = response.Questions.Select(q => new QuestionResponse
                {
                    QuestionId = q.QuestionId,
                    Response = q.Response,
                }).ToList()
            };
            _responseRepo.Add(feedback);
            _unitOfWork.Save();
            return new BaseResponse<ResponseModel>
            {
                IsSuccessfull = true,
                message = "Feedback submitted successfully"
            };
        }

        public bool IsFeedbackExist(string email,  string SurveyId)
        {
            var getUser = _userUnreg.Get(s => s.Email == email);
            if(getUser != null)
            {
                var checkEmail = _surveyRepo.GetAll().Where(s => s.Id == SurveyId && s.UsersUnregId == getUser.Id).Any(); 
            return true; 
            }
            return false;
        }

        public BaseResponse<SurveyResponseModel> TakeSurvey(string Id)
        {
           var getSurvey = _surveyRepo.GetById(Id);
            if (getSurvey != null)
            {
                    var surveyResponse = new SurveyResponseModel
                    {
                        SurveyId = getSurvey.Id,
                        Title = getSurvey.Title,
                        UsersUnregId = getSurvey.UsersRegId,
                        Questions = getSurvey.Questions.Select(q => new QuestionResponseModel
                        {
                            QuestionId = q.Id,
                            Text = q.Text,
                            Type = q.Type,
                            Options = q.Options.Select(o => new OptionResponseModel
                            {
                                OptionId = o.Id,
                                Text = o.Text
                            }).ToList()

                        }).ToList()
                    };
                    return new BaseResponse<SurveyResponseModel>
                    {
                        IsSuccessfull = true,
                        message = "View Page",
                        Data = surveyResponse
                    };
            }
            return new BaseResponse<SurveyResponseModel>
            {
                IsSuccessfull = false,
                message = "Failed",
                Data = null
            };
        }

       
    }
}
