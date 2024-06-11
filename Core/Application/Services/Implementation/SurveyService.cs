using Survey_Feedback_App.Core.Application.DTOs.RequestDTO;
using Survey_Feedback_App.Core.Application.DTOs.ResponseDTO;
using Survey_Feedback_App.Core.Application.Interfaces.Repository;
using Survey_Feedback_App.Core.Application.Interfaces.Service;
using Survey_Feedback_App.Core.Domain.Entities;

namespace Survey_Feedback_App.Core.Application.Services.Implementation
{
  /*  public class SurveyService : ISurveyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISurveyRepository _surveyRepo;
        public SurveyService(ISurveyRepository surveyRepo, IUnitOfWork unitOfWork)
        {
            _surveyRepo = surveyRepo;
            _unitOfWork = unitOfWork;
        }

        public SurveyResponseModel Get(int Id)
        {
            var survey = _surveyRepo.GetById(Id);
            return new SurveyResponseModel
            {
                UsersRegId = survey.UsersRegId,
                Questions = survey.Questions,
                SurveyId = survey.SurveyId,
                TmeCreated = survey.TmeCreated,
                status = survey.status,
            };
        }

        public ICollection<SurveyResponseModel> GetAllApproved()
        {
            var survey = _surveyRepo.GetAll().Where(s => s.status == Domain.Enum.Status.Approved).Select(s => new SurveyResponseModel
            {
                SurveyId = s.SurveyId,
                status = s.status,
                Questions = s.Questions,
                TmeCreated = s.TmeCreated,
                UsersRegId = s.UsersRegId,
            }).ToList();
            return survey;
        }

        public ICollection<SurveyResponseModel> GetAllDenied()
        {
            var survey = _surveyRepo.GetAll().Where(s => s.status == Domain.Enum.Status.Denied).Select(s => new SurveyResponseModel
            {
                SurveyId = s.SurveyId,
                status = s.status,
                Questions = s.Questions,
                TmeCreated = s.TmeCreated,
                UsersRegId = s.UsersRegId,
            }).ToList();
            return survey;
        }

        public ICollection<SurveyResponseModel> GetAllPending()
        {
            var survey = _surveyRepo.GetAll().Where(s => s.status == Domain.Enum.Status.Pending).Select(s => new SurveyResponseModel
            {
                SurveyId = s.SurveyId,
                status = s.status,
                Questions = s.Questions,
                TmeCreated = s.TmeCreated,
                UsersRegId = s.UsersRegId,
            }).ToList();
            return survey;
        }

        public ICollection<SurveyResponseModel> GetApprovedSurveyByClient(int Id)
        {
            var survey = _surveyRepo.GetByUser(Id).Where(s => s.status == Domain.Enum.Status.Approved).Select(s => new SurveyResponseModel
            {
                SurveyId = s.SurveyId,
                status = s.status,
                Questions = s.Questions,
                TmeCreated = s.TmeCreated,
                UsersRegId = s.UsersRegId,
            }).ToList();
            return survey;
        }

        public ICollection<SurveyResponseModel> GetByUser()
        {
            throw new NotImplementedException();
        }

        public ICollection<SurveyResponseModel> GetDeniedSurveyByClient(int Id)
        {
            var survey = _surveyRepo.GetByUser(Id).Where(s => s.status == Domain.Enum.Status.Denied).Select(s => new SurveyResponseModel
            {
                SurveyId = s.SurveyId,
                status = s.status,
                Questions = s.Questions,
                TmeCreated = s.TmeCreated,
                UsersRegId = s.UsersRegId,
            }).ToList();
            return survey;
        }

        public ICollection<SurveyResponseModel> GetPendingSurveyByClient(int Id)
        {
            var survey = _surveyRepo.GetByUser(Id).Where(s => s.status == Domain.Enum.Status.Pending).Select(s => new SurveyResponseModel
            {
                SurveyId = s.SurveyId,
                status = s.status,
                Questions = s.Questions,
                TmeCreated = s.TmeCreated,
                UsersRegId = s.UsersRegId,
            }).ToList();
            return survey;
        }

        public bool IsDelete(int Id)
        {
            throw new NotImplementedException();
        }

        BaseResponse<SurveyResponseModel> ISurveyService.Get(int Id)
        {
            throw new NotImplementedException();
        }

        BaseResponse<ICollection<SurveyResponseModel>> ISurveyService.GetAllApproved()
        {
            throw new NotImplementedException();
        }

        BaseResponse<ICollection<SurveyResponseModel>> ISurveyService.GetAllDenied()
        {
            throw new NotImplementedException();
        }

        BaseResponse<ICollection<SurveyResponseModel>> ISurveyService.GetAllPending()
        {
            throw new NotImplementedException();
        }

        BaseResponse<ICollection<SurveyResponseModel>> ISurveyService.GetApprovedSurveyByClient(int Id)
        {
            throw new NotImplementedException();
        }

        BaseResponse<ICollection<SurveyResponseModel>> ISurveyService.GetByUser()
        {
            throw new NotImplementedException();
        }

        BaseResponse<ICollection<SurveyResponseModel>> ISurveyService.GetDeniedSurveyByClient(int Id)
        {
            throw new NotImplementedException();
        }

        BaseResponse<ICollection<SurveyResponseModel>> ISurveyService.GetPendingSurveyByClient(int Id)
        {
            throw new NotImplementedException();
        }
    }*/
}
