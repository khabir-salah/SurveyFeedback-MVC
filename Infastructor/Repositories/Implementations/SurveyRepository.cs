﻿using Microsoft.EntityFrameworkCore;
using Survey_Feedback_App.Core.Application.Interfaces.Repository;
using Survey_Feedback_App.Core.Domain.Entities;
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
        public Survey Add(Survey survey)
        {
            _context.Surveys.Add(survey);
            return survey;
        }

    

        public Survey GetById(string Id)
        {
            var survey = _context.Surveys.Include(s => s.Questions).ThenInclude(u => u.Options).FirstOrDefault(s => s.Id == Id);
            return survey;
        }

        public ICollection<Survey> GetAll()
        {
            var surveys = _context.Surveys.Include(s => s.Questions).ToList();
            return surveys;
        }

       

        public ICollection<Survey> GetByUser(string Id)
        {
            var surveys = _context.Surveys.Include(s => s.Questions).ThenInclude(u => u.Options).Where(s => s.UsersRegId == Id).ToList();
            return surveys;
        }

        public bool IsDelete(string Id)
        {
            var survey = _context.Surveys.Include(s => s.Questions).ThenInclude(o => o.Options).FirstOrDefault(s => s.Id == Id);
            if (survey == null) return false;
            else _context.Surveys.Remove(survey); return true;
        }

        public void Update(Survey survey)
        {
            _context.Update(survey);
        }
    }
}
