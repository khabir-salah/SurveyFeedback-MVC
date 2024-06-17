using Microsoft.EntityFrameworkCore;
using Survey_Feedback_App.Core.Application.DTOs.RequestDTO;
using Survey_Feedback_App.Core.Application.DTOs.ResponseDTO;
using Survey_Feedback_App.Core.Application.Interfaces.Repository;
using Survey_Feedback_App.Core.Application.Interfaces.Service;
using Survey_Feedback_App.Core.Domain.Entities;

namespace Survey_Feedback_App.Core.Application.Services.Implementation
{
    //public class FeedbackService : IFeedbackService
    //{
    //    private readonly IFeedbackRepository _feedbackRepo;
    //    private readonly IUnitOfWork _unitOfWork;
    //    private readonly ISurveyService _surveyService;
    //    public FeedbackService(IFeedbackRepository feedbackRepo, IUnitOfWork unitOfWork, ISurveyService surveyService)
    //    {
    //        _feedbackRepo = feedbackRepo;
    //        _unitOfWork = unitOfWork;
    //        _surveyService = surveyService;
    //    }

    //    public BaseResponse<FeedbackResponseModel>? GetFeedbackById(string Id)
    //    {
    //        var feedback = _feedbackRepo.Get(Id);
    //        return feedback != null ? new BaseResponse<FeedbackResponseModel>
    //        {
    //           IsSuccessfull = true,
    //           message = "Successfull",
    //           Data = new FeedbackResponseModel
    //           {
    //               FeedbackId = feedback.Id,
    //               Questions = feedback.Questions,
    //               Responses = feedback.Responses,
    //               SurveyId = feedback.SurveyId,
    //               Time = feedback.Time,
    //               UsersUnregId = feedback.UsersUnregId,
    //           }
    //        } : null;
    //    }


    //    public BaseResponse<ICollection<FeedbackResponseModel>> GetFeedbacks(string Id)
    //    {
    //        var feedback = _feedbackRepo.GetAll().;
    //        return feedback != null ? new BaseResponse<FeedbackResponseModel>
    //        {
    //            IsSuccessfull = true,
    //            message = "Successfull",
    //            Data = new FeedbackResponseModel
    //            {
    //                FeedbackId = feedback.Id,
    //                Questions = feedback.Questions,
    //                Responses = feedback.Responses,
    //                SurveyId = feedback.SurveyId,
    //                Time = feedback.Time,
    //                UsersUnregId = feedback.UsersUnregId,
    //            }
    //        } : null;
    //    }

    //    public BaseResponse<FeedbackResponseModel> GiveFeedback(FeedbackResponseRequestModel request)
    //    {
    //        var check = IsFeedbackExist(request.FeedbackRequest.SurveyId, request.FeedbackRequest.UsersUnregId);
    //        if(check)
    //        {
    //            return new BaseResponse<FeedbackResponseModel>
    //            {
    //                IsSuccessfull = false,
    //                message = "You Already Gave Feedback To This Survey",
    //                Data = null,
    //            };
    //        }

    //        var response = new Response
    //        {
    //            QuestionId = request.ResponseRequest.QuestionId,
    //            Text = request.ResponseRequest.Text,
    //        }

    //        var feedback = new Feedback
    //        {
    //            Id = new Guid().ToString().Substring(1, 5),
    //            SurveyId = request.FeedbackRequest.SurveyId,
    //            Responses = 
                

    //        }
            
    //        foreach (var item in )
    //    }

    //    public bool IsFeedbackExist( string Id, string userId)
    //    {
    //        var check = _feedbackRepo.GetAll().Where(s => s.SurveyId == Id && s.UsersRegId == userId).Any();
    //        return check;
    //    }

    //    public BaseResponse<ResponseModel> GiveResponse(ResponseRequestModel request)
    //    {

    //    }
    //}
}
