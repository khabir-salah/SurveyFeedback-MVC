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
        public IdentityController(IIdentityService identityService)
        {
            _IdentityService = identityService;
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
                return RedirectToAction("UserDashboard", user.Data );
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

        public IActionResult UserDashBoard(UsersRegResponseModel request)
        {
            return View(request);
        }

        public IActionResult LogOut()
        {
             HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction( "Index", "Home");
        }

    }
}
