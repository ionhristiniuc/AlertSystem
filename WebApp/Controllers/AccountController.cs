using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using WebApp.Repositories;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        private IUsersRepository _usersRepository;
            
        public AccountController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        IAuthenticationManager Authentication
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Password = null;
                return View(model);
            }

            var user = _usersRepository
                .GetSingle(u => u.username == model.Username && u.password == model.Password);
            if (user != null)
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, model.Username),
                },
                    DefaultAuthenticationTypes.ApplicationCookie,
                    ClaimTypes.Name, ClaimTypes.Role);

                // if you want roles, just add as many as you want here (for loop maybe?)
                identity.AddClaim(new Claim(ClaimTypes.Role, "guest"));
                // tell OWIN the identity provider, optional
                // identity.AddClaim(new Claim(IdentityProvider, "Simplest Auth"));

                Authentication.SignIn(new AuthenticationProperties
                {
                    IsPersistent = model.RememberMe
                }, identity);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("credentials", "Invalid credentials");
                model.Password = null;
                return View(model);
            }            
        }

        public ActionResult LogOff()
        {
            Authentication.SignOut(new AuthenticationProperties());
            return RedirectToAction("Index", "Home");
        }
    }
}