using Survey_Feedback_App.Core.Application.DTOs.RequestDTO;
using Survey_Feedback_App.Core.Application.DTOs.ResponseDTO;
using Survey_Feedback_App.Core.Application.Interfaces.Repository;
using Survey_Feedback_App.Core.Application.Interfaces.Service;
using Survey_Feedback_App.Core.Domain.Entities;

namespace Survey_Feedback_App.Core.Application.Services.Implementation
{
    public class ViewSurveyService : IViewSurveyService
    {
        private readonly ISurveyRepository _surveyRepo;

       public ViewSurveyService(ISurveyRepository surveyRepo)
        {
            _surveyRepo = surveyRepo;
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
                        QuestionText = q.QuestionText,
                        Type = q.Type,
                        Options = q.Options.Select(o => new OptionResponseModel
                        {
                            OptionId = o.Id,
                            OptionText = o.OptionText
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
