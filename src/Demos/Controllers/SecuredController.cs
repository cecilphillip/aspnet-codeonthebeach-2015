using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using System.Security.Claims;

namespace Demos.Controllers
{
    public class SecuredController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {            
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (!string.IsNullOrWhiteSpace(userName) &&
                userName == password)
            {
                var claims = new List<Claim>
                    {
                        new Claim("name", "Cecil L. Phillip"),
                        new Claim("role", "admin"),
                        new Claim("twitter", "@cecilphillip")
                    };

                var id = new ClaimsIdentity(claims, "local", "name", "role");
                await HttpContext.Authentication.SignInAsync("Cookies", new ClaimsPrincipal(id));

                return RedirectToLocal(returnUrl);
            }

            return View();
        }

        public async Task<IActionResult> Logoff()
        {
            await HttpContext.Authentication.SignOutAsync("Cookies");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
    }
}
