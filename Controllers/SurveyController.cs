﻿using Microsoft.AspNetCore.Mvc;

namespace Survey_Feedback_App.Controllers
{
    public class SurveyController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
