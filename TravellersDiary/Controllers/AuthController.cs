using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravellersDiary.Handlers.Auth;
using TravellersDiary.Models.Auth;
using System.Web.Security;

namespace TravellersDiary.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        [HttpGet]
        public ActionResult Login()
        {
            FormsAuthentication.SignOut();
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            AuthHandler authHandler = new AuthHandler();
            bool logState = authHandler.Login(model);
            if (logState)
            {
                FormsAuthentication.SetAuthCookie(model.CH_TAG_NAME, true);
                return RedirectToAction("Index", "Home");
            }
            else
            {

                return View();
            }
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            AuthHandler authHandler = new AuthHandler();
            bool regState = authHandler.Register(model);
            if (regState)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Register", "Auth");
            }
        }
    }
}