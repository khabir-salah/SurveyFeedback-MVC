using Survey_Feedback_App.Core.Application.Interfaces.Repository;
using Survey_Feedback_App.Core.Domain.Entities;
using Survey_Feedback_App.Infastructor.Context;

namespace Survey_Feedback_App.Infastructor.Repositories.Implementations
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly SurveyFeedbackContext _context;
        public FeedbackRepository(SurveyFeedbackContext context)
        {
            _context = context;
        }

        public int Add(Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            return _context.SaveChanges();
        }

        public Feedback? Get(int Id)
        {
            var feedback = _context.Feedbacks.FirstOrDefault(x => x.FeedbackId == Id);
            return feedback;
        }

        public ICollection<Feedback> GetAll()
        {
           var feedbacks = _context.Feedbacks.Select(x => new Feedback
            {
               FeedbackId = x.FeedbackId,
               Questions = x.Questions,
               Responses = x.Responses,
               Time = x.Time,
               SurveyId = x.SurveyId,
               Surveys = x.Surveys,
               UsersUnregId  = x.UsersUnregId,
               
            }).ToList();
            return feedbacks;
        }

    }
}
