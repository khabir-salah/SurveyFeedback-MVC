﻿using Microsoft.AspNetCore.Hosting;
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
        private readonly ISurveyRepository _surveyRepo;
        private readonly IIdentityService _identity;
        private readonly IUsersUnregRepository _userUnreg;
        private readonly ISurveyResposeRepository _surveyResponse;
        private readonly IOptionRepository _optionRepo ;


        public ResponseService( IUnitOfWork unitOfWork, ISurveyRepository surveyRepo, IIdentityService identity, IUsersUnregRepository userUnreg, ISurveyResposeRepository surveyResponse, IOptionRepository optionRepo)
        {
            _unitOfWork = unitOfWork;
            _surveyRepo = surveyRepo;
            _identity = identity;
            _userUnreg = userUnreg;
            _surveyResponse = surveyResponse;
            _optionRepo = optionRepo;
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
                    OptionId = q.Type == Domain.Enum.Types.Text ? q.QuestionText : q.Type == Domain.Enum.Types.Checkbox ?  String.Join("/n",q.SelectedOptions) : q.Response,
                }).ToList()
            };
            _surveyResponse.Add(feedback);

            var user = _surveyRepo.GetById(response.SurveyId).UsersRegId;
            var noOfResponse = _surveyResponse.GetByUser(user).Count;
            feedback.ResponseCount = noOfResponse + 1;
            _surveyResponse.Update(feedback);


            foreach (var question in response.Questions)
            {
                if (question.Type == Domain.Enum.Types.Checkbox)
                {
                    foreach (var optionId in question.SelectedOptions)
                    {
                        var option = _optionRepo.GetById(optionId);
                        if (option != null)
                        {
                            option.Count++;
                            _optionRepo.Update(option);
                        }
                    }
                }
                else if (question.Type == Domain.Enum.Types.Radio)
                {
                    var option = _optionRepo.GetById(question.Response);
                    if (option != null)
                    {
                        option.Count++;
                        _optionRepo.Update(option);
                    }
                }
            }

            _unitOfWork.Save();
            return new BaseResponse<SurveyResponseModel>
            {
                IsSuccessfull = true,
                message = "Feedback submitted successfully"
            };
        }

       

        public int GetResponseCount(string userId)
        {
            return _surveyResponse.GetByUser(userId).Count;

        }

        

    }
}
