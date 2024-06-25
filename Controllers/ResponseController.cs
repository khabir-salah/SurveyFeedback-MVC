using Microsoft.AspNetCore.Mvc;
using Survey_Feedback_App.Core.Application.DTOs.ResponseDTO;
using Survey_Feedback_App.Core.Application.Interfaces.Service;

namespace Survey_Feedback_App.Controllers
{
    public class ResponseController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IViewSurveyService _viewSurvey;
        private readonly IFeedbackService _feedbackService;

        public ResponseController(IViewSurveyService viewSurvey, IFeedbackService feedbackService) 
        {
            _viewSurvey = viewSurvey;
            _feedbackService = feedbackService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TakeSurvey(string link)
        {
            link = Uri.UnescapeDataString(link);
            // Extract survey ID from the link
            var linkId = link.Split('/').Last();
            var surveyResponse = _viewSurvey.ViewSurvey(linkId);

            var model = new SurveyFeedbackViewModel();
            if (surveyResponse.IsSuccessfull)
            {
                model.Survey = surveyResponse.Data;
                model.SurveyId = linkId;
                model.ShowSurveyForm = false; // Initially show email input form
            }
            else
            {
                TempData["Message"] = surveyResponse.message;
                model.ErrorMessage = surveyResponse.message;
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult TakeSurvey(SurveyFeedbackViewModel model)
        {
            if (string.IsNullOrEmpty(model.Email))
            {
                model.ErrorMessage = "Invalid email address.";
                model.ShowSurveyForm = false;
                return View(model);
            }

            var surveyResponse = _viewSurvey.ViewSurvey(model.SurveyId);
            if (surveyResponse == null || surveyResponse.Data == null)
            {
                model.ErrorMessage = "An error occurred while retrieving the survey.";
                model.ShowSurveyForm = false;
            }

            else if (DateTime.Now > surveyResponse.Data.EndTime )
            {
                model.ErrorMessage = "Survey Response Ended.";
                model.ShowSurveyForm = false;
                
            }

            else if (_feedbackService.IsFeedbackExist(model.Email, model.SurveyId))
            {
                model.ErrorMessage = "You have already given feedback for this survey.";
                model.ShowSurveyForm = false;
            }
            else
            {
                model.Survey = surveyResponse.Data;
                model.ShowSurveyForm = true;
            }
            return View(model);
        }
    }
}
