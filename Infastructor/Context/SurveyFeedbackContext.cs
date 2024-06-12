using Microsoft.EntityFrameworkCore;
using Survey_Feedback_App.Core.Domain.Entities;

namespace Survey_Feedback_App.Infastructor.Context
{
    public class SurveyFeedbackContext : DbContext
    {
        public SurveyFeedbackContext(DbContextOptions<SurveyFeedbackContext> options) : base(options) 
        { 
        }

        public DbSet<SurveyResponse> Feedbacks => Set<SurveyResponse>();
        public DbSet<Survey> Surveys => Set<Survey>();
        public DbSet<UsersReg> UsersRegs => Set<UsersReg>();
        public DbSet<UsersUnreg> UsersUnregs => Set<UsersUnreg>();
        public DbSet<Question> Questions => Set<Question>();
        public DbSet<QuestionResponse> Responses => Set<QuestionResponse>();
        public DbSet<Option> Options => Set<Option>();



    }
}
