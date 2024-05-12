using Microsoft.EntityFrameworkCore;
using Survey_Feedback_App.Core.Domain.Entities;

namespace Survey_Feedback_App.Infastructor.Context
{
    public class SurveyFeedbackContext : DbContext
    {
        public SurveyFeedbackContext(DbContextOptions<SurveyFeedbackContext> options) : base(options) 
        { 
        }

        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<UsersReg> UsersRegs { get; set; }
        public DbSet<UsersUnreg> UsersUnregs { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Response> Responses { get; set; }

    }
}
