﻿using Demos.Config;
using Demos.Services;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.OptionsModel;

namespace Demos.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConferenceSessionService _confService;
        private readonly IOptions<CustomConfigOptions> _customSettings;

        public HomeController(IConferenceSessionService confService, IOptions<CustomConfigOptions> customSettings)
        {
            _confService = confService;
            _customSettings = customSettings;
        }

        public IActionResult Index()
        {            
            return View();
        }

        public IActionResult DependencyInjection()
        {
            return View(_confService.GetSessions());
        }

        public IActionResult Config()
        {
            return View(_customSettings.Value);
        }

        public IActionResult Middleware()
        {
            return View();
        }

        public IActionResult HttpContext()
        {
            return View();
        }

        public IActionResult TagHelpers()
        {
            return View();
        }

        public IActionResult ViewComponents()
        {
            return View();
        }

        public IActionResult WebApiSpa()
        {
            return View();
        }
        
        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
