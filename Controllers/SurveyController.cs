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
            var survey = _responseService.TakeSurvey(linkId);
            return View(survey.Data);
        }
        [HttpPost]
        public IActionResult TakeSurvey(ResponseModel model)
        {
            if (ModelState.IsValid)
            {
               

                _responseService.AddResponse(model);

                return RedirectToAction("SurveySubmitted");
            }
            return View(model);
        }

        public IActionResult SurveySubmitted()
        {
            return View();
        }

        public IActionResult UserSurvey()
        {
            var survey = _createService.GetUserSurvey(_identity.GetCurrentUser().Id);
            return View(survey.Data);
        }




    }
}
