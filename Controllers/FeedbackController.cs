using Microsoft.AspNetCore.Mvc;
using Survey_Feedback_App.Core.Application.DTOs.ResponseDTO;
using Survey_Feedback_App.Core.Application.Interfaces.Service;
using System.Security.Principal;

namespace Survey_Feedback_App.Controllers
{
    public class FeedbackController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IResponseService _responseService;
        private readonly ISurveyService _surveyService;

        public FeedbackController(IResponseService responseService, ISurveyService surveyService) 
        { 
            _responseService = responseService;
            _surveyService = surveyService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitFeedback(SubmitResponseViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _responseService.AddResponse(model.Survey, model.Email);

                if (result.IsSuccessfull)
                {
                    TempData["Message"] = "Thank you for your feedback!";
                    return RedirectToAction("SurveySubmitted");
                }

                return View("TakeSurvey", model);
            }

            return View("TakeSurvey", model);
        }

        public IActionResult SurveySubmitted()
        {
            return View();
        }

        public IActionResult SurveyFeedback()
        {
            var survey = _surveyService.GetUserSurvey(_identity.GetCurrentUser().Id);
            return View(survey.Data);
        }

        public IActionResult ViewSurveyFeedback(string link)
        {
            link = Uri.UnescapeDataString(link);
            // Extract survey ID from the link
            var linkId = link.Split('/').Last();
            var surveyResponse = _feedback.GetFeedbackById(linkId);
            return View(surveyResponse.Data);
        }
    }
}
