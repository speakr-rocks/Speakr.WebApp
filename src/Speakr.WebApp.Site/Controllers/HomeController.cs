﻿using Microsoft.AspNetCore.Mvc;
using Speakr.WebApp.Site.ViewModels.Home;

namespace Speakr.WebApp.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [Route("")]
        public IActionResult CheckTalkIdCode(CheckTalkIdViewModel model)
        {
            if(ModelState.IsValid)
            {
                return Content("Talk id is:" + model.TalkId);
            }
            return View("Index");
        }
    }
}