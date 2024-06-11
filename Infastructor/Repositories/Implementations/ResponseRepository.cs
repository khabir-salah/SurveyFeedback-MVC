using Survey_Feedback_App.Core.Application.Interfaces.Repository;
using Survey_Feedback_App.Core.Domain.Entities;
using Survey_Feedback_App.Infastructor.Context;

namespace Survey_Feedback_App.Infastructor.Repositories.Implementations
{
    public class ResponseRepository : IResponseRepository
    {
        private readonly SurveyFeedbackContext _context;
        public ResponseRepository(SurveyFeedbackContext context)
        {
            _context = context;
        }
        public SurveyResponse Add(SurveyResponse response)
        {
            _context.Responses.Add(response);
            return response;
        }

        public SurveyResponse? Get(string id)
        {
           return  _context.Responses.Find(id);
        }
    }
}
