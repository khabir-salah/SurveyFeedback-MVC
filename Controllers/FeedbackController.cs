using Microsoft.AspNetCore.Mvc;

namespace Survey_Feedback_App.Controllers
{
    public class FeedbackController : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
