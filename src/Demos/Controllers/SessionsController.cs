using System.Net;
using Demos.Services;
using Microsoft.AspNet.Mvc;

namespace Demos.Controllers
{
    [Route("api/[controller]")]
    public class SessionsController : Controller
    {
        private readonly IConferenceSessionService _service;

        public SessionsController(IConferenceSessionService service)
        {
            _service = service;
        }

        [HttpGet("list")]
        public IActionResult RetrieveSessions()
        {
            return new ObjectResult(_service.GetSessions())
            {
                StatusCode = (int) HttpStatusCode.OK
            };
        }
    }
}
