using Survey_Feedback_App.Core.Application.DTOs.RequestDTO;
using Survey_Feedback_App.Core.Application.DTOs.ResponseDTO;
using Survey_Feedback_App.Core.Application.Interfaces.Repository;
using Survey_Feedback_App.Core.Application.Interfaces.Service;
using Survey_Feedback_App.Core.Domain.Entities;
using Survey_Feedback_App.Core.Domain.Enum;
using System;
using System.Security.Claims;

namespace Survey_Feedback_App.Core.Application.Services.Implementation
{
    public class CreateSurveyService : ICreateSurveyService
    {
        private readonly ISurveyRepository _surveyRepo;
        private readonly IOptionRepository _optionRepo;
        private readonly IQuestionRepository _questionRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIdentityService _identity;

        
        public CreateSurveyService(ISurveyRepository surveyRepo, IQuestionRepository questionRepo, IUnitOfWork unitOfWork, IOptionRepository optionRepo, IIdentityService identity)
        {
            _surveyRepo = surveyRepo;
            _questionRepo = questionRepo;
            _unitOfWork = unitOfWork;
            _optionRepo = optionRepo;
            _identity = identity;
        }

        

       /* private bool isTitleExist(string title, string id)
        {
            var check = _surveyRepo.GetByUser(id).Where(s => s.Title == title).Any();
            if(check)
            {
                return true;
            }
            return false;
        } */

        public BaseResponse<string> Create(SurveyRequestModel model)
        {

            var survey = new Survey
            {
                Title = model.Title,
                Upload = model.Upload,
                TmeCreated = DateTime.Now,
                EndTime = model.EndTime,
                UsersRegId = _identity.GetCurrentUser().Id,
                UniqueLink = Guid.NewGuid().ToString(),
                Status = Domain.Enum.Status.Pending
            };


            foreach (var questionVm in model.Questions)
            {
                var question = new Question
                {
                    Text = questionVm.Text,
                    Type = (Types)questionVm.Type,
                    SurveyId = survey.Id
                };

            _questionRepo.Add(question);

                if (questionVm.Options != null)
                {
                    foreach (var optionText in questionVm.Options)
                    {
                        var option = new Option
                        {
                            Text = optionText.Text,
                            QuestionId = question.Id
                        };

                        _optionRepo.Add(option);
                    }
                }
            }
            _surveyRepo.Add(survey);
            _unitOfWork.Save();

            return new BaseResponse<string>
            {
                IsSuccessfull = true,
                message = "Created Successfully",
                Data = $"http://localhost7224/survey/{survey.UniqueLink}"
            };

            
        }



        /* var check = isTitleExist(request.SurveyRequest.Title, request.SurveyRequest.UsersRegId);
           if(check)
           {
               return new BaseResponse<SurveyResponseModel>
               {
                   IsSuccessfull = false,
                   Data = null,
                   message = "Survey Title Already Exist"
               };
           }*/
    }
}
