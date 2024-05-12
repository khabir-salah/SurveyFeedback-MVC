using Survey_Feedback_App.Core.Application.Interfaces.Repository;
using Survey_Feedback_App.Core.Domain.Entities;
using Survey_Feedback_App.Core.Domain.Enum;
using Survey_Feedback_App.Infastructor.Context;

namespace Survey_Feedback_App.Infastructor.Repositories.Implementations
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly SurveyFeedbackContext _context;
        public SurveyRepository(SurveyFeedbackContext context ) 
        { 
            _context = context;
        }
        public int Add(Survey survey)
        {
            _context.Surveys.Add(survey);
            return _context.SaveChanges();
        }

        public Survey? Get(int Id)
        {
            var survey = _context.Surveys.FirstOrDefault( s => s.SurveyId == Id);
            return survey;
        }

        public ICollection<Survey> GetAll()
        {
            var surveys = _context.Surveys.Select(s => new Survey
            {
                SurveyId = s.SurveyId,
                Feedbacks = s.Feedbacks,
                Questions = s.Questions,
                status  = s.status,
                Title = s.Title,
                TmeCreated = s.TmeCreated,
                User = s.User,
                UsersRegId = s.UsersRegId,
            }).ToList();
            return surveys;
        }

       

        public ICollection<Survey> GetByUser(int Id)
        {
            var surveys = _context.Surveys.Where(s => s.UsersRegId == Id).ToList();
            return surveys;
        }

       

       

       

        public bool IsDelete(int Id)
        {
            var survey = _context.Surveys.FirstOrDefault(s => s.SurveyId == Id);
            _context.Surveys.Remove(survey);
            if(_context.SaveChanges() > 0)
            {
                return true;
            }
            return false ;
        }

        

        
    }
}
