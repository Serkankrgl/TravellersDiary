using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravellersDiary.Handlers.Global;
using TravellersDiary.Handlers.Profile;
using TravellersDiary.Models.Global;
using TravellersDiary.Models.Profile;
using TravellersDiary.ViewModels;

namespace TravellersDiary.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index(string name)
        {
            if (name == null)
            {
                name = HttpContext.User.Identity.Name;
            }
            GlobalHandler globalHandler = new GlobalHandler();
            ProfileHandler profileHandler = new ProfileHandler();
            Traveller traveller = globalHandler.GetTraveller(name);
            Traveller logeeIntraveller = globalHandler.GetTraveller(HttpContext.User.Identity.Name);
            Follow follow = new Follow()
            {
                TRAVELLER_ID = traveller.PK_TRAVELLER_ID,
                FOLLOWER_ID = logeeIntraveller.PK_TRAVELLER_ID
            };
            ProfileViewModel VM = new ProfileViewModel()
            {
                LogedInTraveller = logeeIntraveller,
                Traveller = traveller,
                Vacations = profileHandler.GetVacationById(traveller.PK_TRAVELLER_ID),
                FollowStatus= profileHandler.IsFollowing(follow),
                Achivments =profileHandler.GetAchivments(traveller.PK_TRAVELLER_ID)
            };
            return View(VM);
        }
        public ActionResult Follow(int travellerid,int followerid,string name)
        {
            ProfileHandler profileHandler = new ProfileHandler();
            Follow model = new Follow()
            {
                TRAVELLER_ID = travellerid,
                FOLLOWER_ID = followerid
            };
            profileHandler.Follow(model);

            return RedirectToAction("Index","Profile",new { name =name});
        }

        public ActionResult UnFollow(int travellerid, int followerid, string name)
        {
            ProfileHandler profileHandler = new ProfileHandler();
            Follow model = new Follow()
            {
                TRAVELLER_ID = travellerid,
                FOLLOWER_ID = followerid
            };
            profileHandler.UnFollow(model);

            return RedirectToAction("Index", "Profile", new { name = name });
        }

        public ActionResult CreateAchivment(CreateAchivment model)
        {
            ProfileHandler profileHandler = new ProfileHandler();

            profileHandler.CreateAchivment(model);

            return RedirectToAction("Index", "Profile", new { name = model.CH_TAG_NAME });
        }
        public ActionResult EditProfile(EditProfile model)
        {
            ProfileHandler profileHandler = new ProfileHandler();

            profileHandler.EditProfile(model);
            return RedirectToAction("Index", "Profile", new { name = model.CH_TAG_NAME });
        }
    }
}