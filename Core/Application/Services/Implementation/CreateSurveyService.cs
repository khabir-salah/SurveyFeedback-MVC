using Microsoft.AspNetCore.Hosting;
using Survey_Feedback_App.Core.Application.DTOs.RequestDTO;
using Survey_Feedback_App.Core.Application.DTOs.ResponseDTO;
using Survey_Feedback_App.Core.Application.Interfaces.Repository;
using Survey_Feedback_App.Core.Application.Interfaces.Service;
using Survey_Feedback_App.Core.Domain.Entities;
using Survey_Feedback_App.Core.Domain.Enum;
using System;
using System.Security.Claims;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Survey_Feedback_App.Core.Application.Services.Implementation
{
    public class CreateSurveyService : ICreateSurveyService
    {
        private readonly ISurveyRepository _surveyRepo;
        private readonly IOptionRepository _optionRepo;
        private readonly IQuestionRepository _questionRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIdentityService _identity;
        IWebHostEnvironment _webHostEnvironment;
        
        public CreateSurveyService(ISurveyRepository surveyRepo, IQuestionRepository questionRepo, IUnitOfWork unitOfWork, IOptionRepository optionRepo, IIdentityService identity, IWebHostEnvironment webHostEnvironment)
        {
            _surveyRepo = surveyRepo;
            _questionRepo = questionRepo;
            _unitOfWork = unitOfWork;
            _optionRepo = optionRepo;
            _identity = identity;
            _webHostEnvironment = webHostEnvironment;
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
            var imageUrl = SaveImage(model.Upload);
            var survey = new Survey
            {
                Title = model.Title,
                Upload = imageUrl,
                TmeCreated = DateTime.Now,
                EndTime = model.EndTime,
                UsersRegId = _identity.GetCurrentUser().Id,
            };


            foreach (var questionVm in model.Questions)
            {
                var question = new Question
                {
                    QuestionText = questionVm.QuestionText,
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
                            OptionText = optionText.OptionText,
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
                Data = $"http://localhost7224/survey/{survey.Id}"
            };

        }


        private string SaveImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return string.Empty;

            var uploadDir = "uploads";
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, uploadDir);

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            var uniqueFileName = Guid.NewGuid().ToString().Substring(0,5) + "_" + file.FileName;
            var fullPath = Path.Combine(filePath, uniqueFileName);

            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return $"/{uploadDir}/{uniqueFileName}";
        }


       

    }
}
