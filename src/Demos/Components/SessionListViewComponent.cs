using Demos.Services;
using Microsoft.AspNet.Mvc;

namespace Demos.Components
{
    [ViewComponent(Name = "SessionList")]
    public class SessionListViewComponent : ViewComponent
    {
        private readonly IConferenceSessionService _confService;

        public SessionListViewComponent(IConferenceSessionService confService)
        {
            _confService = confService;
        }

        public IViewComponentResult Invoke()
        {
            var sessions = _confService.GetSessions();
            return View(sessions);
        }
    }
}