using Microsoft.AspNetCore.Mvc;
using Survey_Feedback_App.Core.Application.DTOs.RequestDTO;
using Survey_Feedback_App.Core.Application.Interfaces.Service;

namespace Survey_Feedback_App.Controllers
{
   /* public class UsersUnregController : Controller
    {
        private readonly IUsersUnregService _userService;
        public UsersUnregController(IUsersUnregService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(UsersUnregRequestModel user)
        {
            var userUnreg = _userService.Add(user);
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
    }*/
}
