using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demos.Config;
using Demos.Services;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.OptionsModel;

namespace Demos.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConferenceSessionService _confService;
        private readonly IOptions<CustomConfigOptions> _appSettings;

        public HomeController(IConferenceSessionService confService, IOptions<CustomConfigOptions> appSettings)
        {
            _confService = confService;
            _appSettings = appSettings;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DependencyInjection()
        {
            return View();
        }

        public IActionResult Config()
        {
            return View();
        }

        public IActionResult Middleware()
        {
            return View();
        }

        //TODO: do something else with this
        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
