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

        public ResponseService(IResponseRepository responseRepo, IUnitOfWork unitOfWork, ISurveyRepository surveyRepo)
        {
            _responseRepo = responseRepo;
            _unitOfWork = unitOfWork;
            _surveyRepo = surveyRepo;
        }

        public void AddResponse(ResponseModel response)
        {
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
        }

        public BaseResponse<SurveyResponseModel> GetResponse(int Id)
        {
            throw new NotImplementedException();
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
