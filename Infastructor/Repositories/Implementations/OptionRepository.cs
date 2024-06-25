using Microsoft.EntityFrameworkCore;
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

        public QuestionResponseOption AddResponseOption(QuestionResponseOption request)
        {
            _context.QuestionResponseOption.Add(request);
            return request;
        }

        public Option? GetById (string id)
        {
           return  _context.Options.FirstOrDefault(o => o.Id == id);
        }

        public void Update(Option request)
        {
            _context.Options.Update(request);
        }
    }
}
