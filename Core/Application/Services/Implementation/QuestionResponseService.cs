using Survey_Feedback_App.Core.Application.DTOs.RequestDTO;
using Survey_Feedback_App.Core.Application.DTOs.ResponseDTO;
using Survey_Feedback_App.Core.Application.Interfaces.Repository;
using Survey_Feedback_App.Core.Application.Interfaces.Service;
using Survey_Feedback_App.Core.Domain.Entities;

namespace Survey_Feedback_App.Core.Application.Services.Implementation
{
    public class QuestionResponseService : IQuestionResponseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IQuestionResponseRepository _responseRepo;
        private readonly ISurveyRepository _surveyRepo;

        public QuestionResponseService(IQuestionResponseRepository responseRepo, IUnitOfWork unitOfWork)
        {
            _responseRepo = responseRepo;
            _unitOfWork = unitOfWork;
        }

        public void AddResponse(SurveyResponseModel response)
        {
            var feedback = new SurveyResponse
            {
                SurveyId = response.SurveyId,
                UsersUnregId = response.UsersUnregId,
               
            
            };
            //_responseRepo.Add(feedback);
            _unitOfWork.Save();

            foreach (var question in response.Questions)
            {
                var questions = new QuestionResponse
                {
                    QuestionId = question.QuestionId,
                    Response = question.Response,
                };
            }
        }

        public BaseResponse<SurveyResponseModel> GetResponse(int Id)
        {
            throw new NotImplementedException();
        }

       
        
    }
}
