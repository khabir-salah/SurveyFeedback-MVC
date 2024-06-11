using Microsoft.AspNetCore.Mvc;
using Survey_Feedback_App.Core.Application.DTOs.RequestDTO;
using Survey_Feedback_App.Core.Application.DTOs.ResponseDTO;
using Survey_Feedback_App.Core.Application.Interfaces.Service;
using Survey_Feedback_App.Core.Domain.Entities;

namespace Survey_Feedback_App.Controllers
{
    public class SurveyController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ICreateSurveyService _createService;
        private readonly IResponseService _responseService;
        public SurveyController(ICreateSurveyService createService, IResponseService responseService)
        {
            _createService = createService;
            _responseService = responseService;
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
                return Json(Url.Action("TakeSurvey", "Survey", new { id = survey.Data }, Request.Scheme));
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

        public IActionResult TakeSurvey(string id)
        {
           var survey = _responseService.TakeSurvey(id);
            return View(survey);
        }
        [HttpPost]
        public IActionResult TakeSurvey(SurveyResponseModel model)
        {
            if (ModelState.IsValid)
            {
                var response = new SurveyResponse
                {
                    SurveyId = model.SurveyId,
                    QuestionResponses = model.Questions.Select(q => new QuestionResponse
                    {
                        QuestionId = q.QuestionId,
                        Response = q.Type == Core.Domain.Enum.Types.Text ? q.Response : string.Join(",", q.SelectedOptions)
                    }).ToList()
                };

                _responseService.AddResponse(model);

                return RedirectToAction("SurveySubmitted");
            }
            return View(model);
        }

        public IActionResult SurveySubmitted()
        {
            return View();
        }



    }
}
