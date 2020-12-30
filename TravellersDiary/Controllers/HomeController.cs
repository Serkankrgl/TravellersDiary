using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravellersDiary.Handlers.Home;
using TravellersDiary.Handlers.Global;
using TravellersDiary.Models;
using TravellersDiary.Models.Auth;
using TravellersDiary.Models.Home;
using TravellersDiary.Models.Global;
using TravellersDiary.ViewModels;

namespace TravellersDiary.Controllers
{
    public class HomeController : Controller
    {


        [Authorize]
        public ActionResult Index() 
        {
            HomeHandler homeHandler = new HomeHandler();
            GlobalHandler globalHandler = new GlobalHandler();
            VacationViewModels model = new VacationViewModels() {
                Traveller = globalHandler.GetTraveller(HttpContext.User.Identity.Name),
                Badges = homeHandler.ListVacation()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateVacation(CreateVacationBadge model)
        {
            HomeHandler homeHandler = new HomeHandler();
            GlobalHandler globalHandler = new GlobalHandler();
            homeHandler.CreateVacation(model);
            VacationViewModels VacModel = new VacationViewModels()
            {
                Traveller = globalHandler.GetTraveller(HttpContext.User.Identity.Name),
                Badges = homeHandler.ListVacation()
            };
            return RedirectToAction("Index", VacModel);
        }

        public PartialViewResult LikeStatus(int id)
        {
            HomeHandler homeHandler = new HomeHandler();
            GlobalHandler globalHandler = new GlobalHandler();
            Traveller traveller = globalHandler.GetTraveller(HttpContext.User.Identity.Name);
            LikeModel likeModel = new LikeModel()
            {
                TRAVELLER_ID =traveller.PK_TRAVELLER_ID,
                VACATION_ID=id
            };
            int status =homeHandler.LikeStatus(likeModel);
            LikeViewModel VM = new LikeViewModel()
            {
                LikeStatus = homeHandler.LikeStatus(likeModel),
                VacationId = id,
                traveller = traveller
            };
            return PartialView("_LikeStatus",VM);
        }

        public ActionResult Rate(int id,bool type)
        {
            HomeHandler homeHandler = new HomeHandler();
            GlobalHandler globalHandler = new GlobalHandler();
            Traveller traveller = globalHandler.GetTraveller(HttpContext.User.Identity.Name);
            LikeModel likeModel = new LikeModel()
            {
                TRAVELLER_ID = traveller.PK_TRAVELLER_ID,
                VACATION_ID = id,
                SW_TYPE = type
            };
            homeHandler.RateVac(likeModel);
            return RedirectToAction("Index","Home");
        }

        public ActionResult ClearRate(int id)
        {
            HomeHandler homeHandler = new HomeHandler();
            GlobalHandler globalHandler = new GlobalHandler();
            Traveller traveller = globalHandler.GetTraveller(HttpContext.User.Identity.Name);
            LikeModel likeModel = new LikeModel()
            {
                TRAVELLER_ID = traveller.PK_TRAVELLER_ID,
                VACATION_ID = id,
            };
            homeHandler.ClearRate(likeModel);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Search(string WORD) {

            HomeHandler homeHandler = new HomeHandler();
            GlobalHandler globalHandler = new GlobalHandler();
            VacationViewModels VM = new VacationViewModels()
            {
                Traveller = globalHandler.GetTraveller(HttpContext.User.Identity.Name),
                Badges = homeHandler.SearchResults(WORD)
            };
            return View("Index", VM);
        }
    }
}