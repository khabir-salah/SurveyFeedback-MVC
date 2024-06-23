using Survey_Feedback_App.Core.Application.DTOs.ResponseDTO;
using Survey_Feedback_App.Core.Application.Interfaces.Repository;
using Survey_Feedback_App.Core.Application.Interfaces.Service;
using Survey_Feedback_App.Core.Domain.Entities;

namespace Survey_Feedback_App.Core.Application.Services.Implementation
{
    public class SurveyService : ISurveyService
    {

        private readonly ISurveyRepository _surveyRepo;
        private readonly IUnitOfWork _unitOfWork;
        public SurveyService(ISurveyRepository surveyRepo, IUnitOfWork unitOfWork)
        {
            _surveyRepo = surveyRepo;
            _unitOfWork = unitOfWork;
        }

        public BaseResponse<ICollection<SurveyResponseModel>> GetUserSurvey(string id)
        {
            var userSurvey = _surveyRepo.GetByUser(id);


            return new BaseResponse<ICollection<SurveyResponseModel>>
            {
                IsSuccessfull = true,
                message = "List of survey",
                Data = userSurvey.Select(s => new SurveyResponseModel
                {
                    SurveyId = s.Id,
                    Title = s.Title,
                }).ToList()
            };
        }


        public int GetSurveyCount(string userId)
        {
            return _surveyRepo.GetByUser(userId).Count;
        }

        public Survey GetById(string Id)
        {
            return _surveyRepo.GetById(Id);
        }

        public bool IsDelete(string id)
        {
            var delete = _surveyRepo.IsDelete(id);
            if (delete)
            { _unitOfWork.Save(); return true; }
            else return false;
        }
    }
}
