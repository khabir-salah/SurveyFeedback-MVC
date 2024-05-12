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
        public int Add(Response response)
        {
            _context.Responses.Add(response);
            return _context.SaveChanges();
        }

        public Response Get(int id)
        {
            var response = _context.Responses.FirstOrDefault(r => r.ResponseId == id);
            return response;
        }
    }
}
