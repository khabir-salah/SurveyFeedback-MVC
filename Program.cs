using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Survey_Feedback_App.Core.Application.Interfaces.Repository;
using Survey_Feedback_App.Core.Application.Interfaces.Service;
using Survey_Feedback_App.Core.Application.Services.Implementation;
using Survey_Feedback_App.Infastructor.Context;
using Survey_Feedback_App.Infastructor.Repositories.Implementations;


namespace Survey_Feedback_App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("SurveyFeedbackConnection");

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<SurveyFeedbackContext>(
                option => option.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            builder.Services.AddScoped<ICreateSurveyService, CreateSurveyService>();
            builder.Services.AddScoped<ISurveyRepository , SurveyRepository>();
            builder.Services.AddScoped<IIdentityService, IdentityService>();
            builder.Services.AddScoped<IUnitOfWork , UnitOfWork>();
            builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
            builder.Services.AddScoped<IResponseService, ResponseService>();
            builder.Services.AddScoped<IResponseRepository, ResponseRepository>();
            builder.Services.AddScoped<IUsersRegRepository, UsersRegRepository>();
            builder.Services.AddScoped<IOptionRepository, OptionRepository>();
            builder.Services.AddScoped<IFeedbackService, FeedbackService>();
            builder.Services.AddScoped<ISurveyResposeRepository, SurveyResponseRepository>();
            builder.Services.AddScoped<IUsersUnregRepository, UsersUnregRepository>();
            builder.Services.AddScoped<ISurveyService, SurveyService>();
            builder.Services.AddScoped<IViewSurveyService, ViewSurveyService>();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.Name = "SalahSurvey";
                
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "takeSurvey",
                pattern: "Survey/TakeSurvey/{link}",
                defaults: new { controller = "Survey", action = "TakeSurvey" });




            app.Run();
        }
    }
}
