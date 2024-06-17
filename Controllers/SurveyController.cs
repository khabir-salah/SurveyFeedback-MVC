using Microsoft.AspNetCore.Mvc;
using Survey_Feedback_App.Core.Application.DTOs.RequestDTO;
using Survey_Feedback_App.Core.Application.DTOs.ResponseDTO;
using Survey_Feedback_App.Core.Application.Interfaces.Service;
using Survey_Feedback_App.Core.Application.Services.Implementation;
using Survey_Feedback_App.Core.Domain.Entities;

namespace Survey_Feedback_App.Controllers
{
    public class SurveyController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ICreateSurveyService _createService;
        private readonly IResponseService _responseService;
        private readonly IIdentityService _identity;
        public SurveyController(ICreateSurveyService createService, IResponseService responseService, IIdentityService identity)
        {
            _createService = createService;
            _responseService = responseService;
            _identity = identity;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSurvey(SurveyRequestModel request)
        {
            var survey = _createService.Create(request);
            if(survey.IsSuccessfull)
            {
                TempData["Message"] = survey.message;
                return Json(Url.Action("TakeSurvey", "Survey", new { link = survey.Data }, Request.Scheme));
            }
            TempData["Message"] = survey.message;
            return View(request);
        }

        //var surveyLink = Url.Action("TakeSurvey", "Survey", new { id = survey.UniqueLink }, Request.Scheme);

        public IActionResult CreateSurvey()
        {
            var model = new SurveyRequestModel
            {
                Questions = new List<QuestionRequestModel>()
            };
            return View(model);
        }
        
        public IActionResult TakeSurvey(string link)
        {
            link = Uri.UnescapeDataString(link);
            // Extract survey ID from the link
             var linkId = link.Split('/').Last();
            var surveyResponse = _responseService.ViewSurvey(linkId);

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
           
            var surveyResponse = _responseService.ViewSurvey(model.SurveyId);
            if (surveyResponse == null || surveyResponse.Data == null)
            {
                model.ErrorMessage = "An error occurred while retrieving the survey.";
                model.ShowSurveyForm = false;
            }

            else if (!_responseService.IsFeedbackExist(model.Email, model.SurveyId))
            {
                model.Survey = surveyResponse.Data;
                model.ShowSurveyForm = true;
            }
            else
            {
                model.ErrorMessage = "You have already given feedback for this survey.";
                model.ShowSurveyForm = false;
            }
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSurvey(string surveyId)
        {
            
            var delete = _responseService.IsDelete(surveyId);
            if (delete)
                TempData["Message"] = "Survey deleted successfully!";
            else TempData["Message"] = "failed to DELETE survey";
            return RedirectToAction("UserSurvey");
        }


        public IActionResult ViewSurvey(string link)
        {
            link = Uri.UnescapeDataString(link);
            // Extract survey ID from the link
            var linkId = link.Split('/').Last();
            var surveyResponse = _responseService.ViewSurvey(linkId);
            var model = new SurveyFeedbackViewModel();
            if (surveyResponse.IsSuccessfull)
            {
                model.Survey = surveyResponse.Data;
            }
            return View(model);
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

        public IActionResult UserSurvey()
        {
            var survey = _createService.GetUserSurvey(_identity.GetCurrentUser().Id);
            return View(survey.Data);
        }

        public IActionResult SurveySubmitted()
        {
            return View();
        }




    }
}
