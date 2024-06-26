using Microsoft.AspNetCore.Mvc;
using Survey_Feedback_App.Core.Application.DTOs.RequestDTO;
using Survey_Feedback_App.Core.Application.DTOs.ResponseDTO;
using Survey_Feedback_App.Core.Application.Interfaces.Service;

namespace Survey_Feedback_App.Controllers
{
    public class SurveyController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ICreateSurveyService _createService;
        private readonly ISurveyService _surveyService;
        private readonly IIdentityService _identity;
        private readonly IViewSurveyService _viewSurvey;
        public SurveyController(ICreateSurveyService createService, ISurveyService surveyService, IIdentityService identity, IViewSurveyService viewSurvey)
        {
            _createService = createService;
            _surveyService = surveyService;
            _identity = identity;
            _viewSurvey = viewSurvey;
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
                return Json(Url.Action("TakeSurvey", "Response", new { link = survey.Data }, Request.Scheme));
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
        
       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSurvey(string surveyId)
        {
            
            var delete = _surveyService.IsDelete(surveyId);
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
            var surveyResponse = _viewSurvey.ViewSurvey(linkId);
            var model = new SurveyFeedbackViewModel();
            if (surveyResponse.IsSuccessfull)
            {
                model.Survey = surveyResponse.Data;
            }
            return View(model);
        }


        public IActionResult UserSurvey()
        {
            var survey = _surveyService.GetUserSurvey(_identity.GetCurrentUser().Id);
            return View(survey.Data);
        }

        public IActionResult ViewAnalysis()
        {
            var survey = _surveyService.GetUserSurvey(_identity.GetCurrentUser().Id);
            return View(survey.Data);
        }


        public IActionResult SurveyAnalysis(string link)
        {
            link = Uri.UnescapeDataString(link);
            var linkId = link.Split('/').Last();
            var survey = _surveyService.GetById(linkId);

            var surveyAnalysis = new List<AnalysisViewModel>();

            foreach (var question in survey.Questions)
            {
                var questionAnalysis = new AnalysisViewModel
                {
                    QuestionText = question.QuestionText,
                    ResponseCounts = question.Options.Select(option => new ResponseCount
                    {
                        OptionText = option.OptionText,
                        Count = question.Options.Count(response => response.Id == option.Id)
                    }).ToList()
                };

                surveyAnalysis.Add(questionAnalysis);
            }

            return View(surveyAnalysis);
        }


        [HttpPost]
        public IActionResult SearchSurvey(SurveySearchViewModel request)
        {
            var search = _surveyService.SeachSurvey(request.Title);
            var model = new SurveySearchViewModel
            {
                Title = request.Title,
                SearchResults = search.IsSuccessfull ? search.Data : new List<SearchModel>()
            };
            return View(model);
        }

  
        public IActionResult SearchSurvey()
        {
            var model = new SurveySearchViewModel();
            return View(model);
        }
    }
}
