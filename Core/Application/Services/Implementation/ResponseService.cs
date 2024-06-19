using Microsoft.AspNetCore.Hosting;
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
        private readonly ISurveyResposeRepository _surveyResponse;

        public ResponseService(IResponseRepository responseRepo, IUnitOfWork unitOfWork, ISurveyRepository surveyRepo, IIdentityService identity, IUsersUnregRepository userUnreg, ISurveyResposeRepository surveyResponse)
        {
            _responseRepo = responseRepo;
            _unitOfWork = unitOfWork;
            _surveyRepo = surveyRepo;
            _identity = identity;
            _userUnreg = userUnreg;
            _surveyResponse = surveyResponse;
        }

        public BaseResponse<SurveyResponseModel> AddResponse(SurveyRequestModels response, string email)
        {
            BaseResponse<UsersUnregResponseModel> identity = default ;
            var getUser = _userUnreg.Get(s => s.Email == email);
            if (getUser == null)
            {
                identity =  _identity.Add(email);
            }
            var feedback = new SurveyResponse
            {
                SurveyId = response.SurveyId,
                UsersUnregId = identity.Data.UsersUnregId,
                QuestionResponses = response.Questions.Select(q => new QuestionResponse
                {
                    QuestionId = q.QuestionId,
                    OptionId = q.Type == Domain.Enum.Types.Text ? q.Text : q.Type == Domain.Enum.Types.Checkbox ?  String.Join("/n",q.SelectedOptions) : q.Response,
                }).ToList()
            };
            _surveyResponse.Add(feedback);
            _unitOfWork.Save();
            return new BaseResponse<SurveyResponseModel>
            {
                IsSuccessfull = true,
                message = "Feedback submitted successfully"
            };
        }

        public bool IsFeedbackExist(string email,  string SurveyId)
        {
            var getUser = _userUnreg.Get(s => s.Email == email);
            var checkEmail = _surveyResponse.GetAll().Where(s => s.Id == SurveyId && s.UsersUnregId == getUser.Id).Any(); 
            if (checkEmail)
            {
                return true;
            }
            return false;
        }

        public bool IsDelete(string id)
        {
            var delete = _surveyRepo.IsDelete(id);
            if (delete)
            { _unitOfWork.Save(); return true; }
            else return false;
        }

        public BaseResponse<SurveyResponseModel> TakeSurvey(string Id, string email)
        {
            var getUser = _userUnreg.Get(s => s.Email == email);
            if (getUser == null)
            {
                _identity.Add(email);
            }
            var getSurvey = _surveyRepo.GetById(Id);
            if (getSurvey != null)
            {
                if(!IsFeedbackExist(email, Id))
                {
                    var surveyResponse = new SurveyResponseModel
                    {
                        SurveyId = getSurvey.Id,
                        Title = getSurvey.Title,
                        UsersUnregId = getUser.Id,
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
               
            }
            return new BaseResponse<SurveyResponseModel>
            {
                IsSuccessfull = false,
                message = "Failed",
                Data = null
            };
        }

        public BaseResponse<SurveyResponseModel> ViewSurvey(string Id)
        {
         
            var getSurvey = _surveyRepo.GetById(Id);
           
            if (getSurvey != null)
            {
                    var surveyResponse = new SurveyResponseModel
                    {
                        SurveyId = getSurvey.Id,
                        Title = getSurvey.Title,
                        Uplaod = getSurvey.Upload,
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
