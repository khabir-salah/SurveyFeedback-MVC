using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Survey_Feedback_App.Core.Application.DTOs.RequestDTO;
using Survey_Feedback_App.Core.Application.DTOs.ResponseDTO;
using Survey_Feedback_App.Core.Application.Interfaces.Service;
using System.Security.Claims;

namespace Survey_Feedback_App.Controllers
{
    public class IdentityController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IIdentityService _IdentityService;
        private readonly ISurveyService _SurveyService;
        private readonly IResponseService _responseService;
        public IdentityController(IIdentityService identityService, ISurveyService surveyService, IResponseService responseService)
        {
            _IdentityService = identityService;
            _SurveyService = surveyService;
            _responseService = responseService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UsersRegRequestModel request)
        {
            var register = _IdentityService.Register(request);
            if(!register.IsSuccessfull)
            {
                TempData["Error"] = register.message;
                return View(request);
            }
            TempData["Message"] = register.message;
            return View("Login");
        }
        [HttpPost]
        public IActionResult Login(UserLoginRequestModel request)
        {
            var user = _IdentityService.Login(request);
            if(user.IsSuccessfull)
            {
                CookieOptions cookie = new CookieOptions();
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Append("UserEmail", user.Data.Email, cookie);
                Response.Cookies.Append("UserId", user.Data.UsersRegId, cookie);
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Data.UsersRegId.ToString()),
                    new Claim(ClaimTypes.Email, user.Data.Email),
                    new Claim(ClaimTypes.Role, user.Data.Role)
                };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(claimsIdentity);
                var property = new AuthenticationProperties();
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, property);
                TempData["Message"] = user.message;
                TempData["UserId"] = user.Data.UsersRegId;

                return RedirectToAction( "UserDashboard"  );
            }
            TempData["Message"] = user.message;
            return View(request);
        }

        public IActionResult Login()
        {
            return View();
        } 
        public IActionResult Register()
        {
            return View();
        }

        
        public IActionResult UserDashBoard()
        {
            string userId = TempData.ContainsKey("UserId")? (string)TempData["UserId"] : null;
            // Fetch the number of surveys created by the user
            var numberOfSurveysCreated = _SurveyService.GetSurveyCount(userId);

            // Fetch the number of feedbacks for surveys created by the user
            var numberOfFeedbacks = _responseService.GetResponseCount(userId);

            TempData["UserId"] = userId;
            var model = new DashboardViewModel
            {
                SurveyCount = numberOfSurveysCreated,
                ResponseCount = numberOfFeedbacks,
            };

            return View(model);
        }

        //public IActionResult UserDashBoard()
        //{
        //    return View();
        //}

        public IActionResult LogOut()
        {
             HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction( "Index", "Home");
        }

    }
}
