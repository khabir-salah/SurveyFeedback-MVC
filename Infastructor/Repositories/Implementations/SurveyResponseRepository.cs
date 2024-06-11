﻿using Microsoft.EntityFrameworkCore;
using Survey_Feedback_App.Core.Application.Interfaces.Repository;
using Survey_Feedback_App.Core.Domain.Entities;
using Survey_Feedback_App.Infastructor.Context;

namespace Survey_Feedback_App.Infastructor.Repositories.Implementations
{
    public class SurveyResponseRepository : ISurveyResposeRepository
    {
        private readonly SurveyFeedbackContext _context;
        public SurveyResponseRepository(SurveyFeedbackContext context)
        {
            _context = context;
        }

        public SurveyResponse Add(SurveyResponse feedback)
        {
            _context.Feedbacks.Add(feedback);
            return feedback;
        }

        public SurveyResponse? Get(string Id)
        {
            var feedback = _context.Feedbacks.Include(f => f.QuestionResponses).ThenInclude(f => f.Response).FirstOrDefault(x => x.Id == Id);
            return feedback;
        }

        public ICollection<SurveyResponse> GetAll()
        {
           var feedbacks = _context.Feedbacks.ToList();
            return feedbacks;
        }

    }
}