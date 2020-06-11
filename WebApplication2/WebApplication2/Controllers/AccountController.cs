using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        private readonly UserManager<IdentityUser> userManager;

        public AccountController()
        : this(Startup.UserManagerFactory.Invoke())
        {
        }

        public AccountController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult LogIn(string returnUrl)
        {
            var model = new Models.ViewModels.Login
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }
        //[HttpPost]
        //public ActionResult LogIn(Models.ViewModels.Login model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }

        //    // Don't do this in production!
        //    if (model.Username == "admin" && model.Password == "admin")
        //    {
        //        var identity = new ClaimsIdentity(new[] {
        //            new Claim(ClaimTypes.Name, "Ben"),
        //            new Claim(ClaimTypes.Email, "a@b.com"),
        //            new Claim(ClaimTypes.Country, "England") },
        //        "ApplicationCookie");
        //        var ctx = Request.GetOwinContext();
        //        var authManager = ctx.Authentication;
        //        authManager.SignIn(identity);
        //        return Redirect(GetRedirectUrl(model.ReturnUrl));
        //    }
        //    // user authN failed
        //    ModelState.AddModelError("", "Invalid email or password");
        //    return View();
        //}

        [HttpPost]
        public async Task<ActionResult> LogIn(Models.ViewModels.Login model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await userManager.FindAsync(model.Username, model.Password);

            if (user != null)
            {
                await SignIn(user);
                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }

            // user authN failed
            ModelState.AddModelError("", "Invalid email or password");
            return View();
        }

        private IAuthenticationManager GetAuthenticationManager()
        {
            var ctx = Request.GetOwinContext();
            return ctx.Authentication;
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(Models.ViewModels.Register model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = new ApplicationUser
            {
                UserName = model.Username,
                Country = model.Country
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await SignIn(user);
                return RedirectToAction("index", "home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

            return View();
        }
        private async Task SignIn(ApplicationUser user)
        {
            var identity = await userManager.CreateIdentityAsync(
                user, DefaultAuthenticationTypes.ApplicationCookie);
            GetAuthenticationManager().SignIn(identity);
        }
        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }

            return returnUrl;
        }
        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Home");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && userManager != null)
            {
                userManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}