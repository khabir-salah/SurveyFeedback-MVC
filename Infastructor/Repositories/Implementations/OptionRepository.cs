using Survey_Feedback_App.Core.Application.Interfaces.Repository;
using Survey_Feedback_App.Core.Domain.Entities;
using Survey_Feedback_App.Infastructor.Context;

namespace Survey_Feedback_App.Infastructor.Repositories.Implementations
{
    public class OptionRepository : IOptionRepository
    {
        private readonly SurveyFeedbackContext _context;
        public OptionRepository(SurveyFeedbackContext context)
        {
            _context = context;
        }
        public Option Add(Option request)
        {
           _context.Options.Add(request);
            return request;
        }

        public Option GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
