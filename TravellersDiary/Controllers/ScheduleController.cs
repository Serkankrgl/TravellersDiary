using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravellersDiary.Handlers.Company;
using TravellersDiary.Handlers.Global;
using TravellersDiary.Handlers.Schedule;
using TravellersDiary.Models.Global;
using TravellersDiary.Models.Schedule;
using TravellersDiary.ViewModels;

namespace TravellersDiary.Controllers
{
    [Authorize]
    public class ScheduleController : Controller
    {
        // GET: Schedule
        public ActionResult Index(int id)
        {
            
            ScheduleHandler scheduleHandler = new ScheduleHandler();
            GlobalHandler globalHandler = new GlobalHandler();
            CompanyHandler companyHandler = new CompanyHandler();
            Traveller traveller = globalHandler.GetTraveller(HttpContext.User.Identity.Name);
            ScheduleViewModel VM = new ScheduleViewModel()
            {
                Schedules = scheduleHandler.GetSchedules(id),
                Traveller = traveller,
                VacationBadge = globalHandler.GetVacation(id),
                Companys = companyHandler.GetCompanyList(),
                Followings = scheduleHandler.GetFollowingList(traveller.PK_TRAVELLER_ID),
                Owners = scheduleHandler.GetVacOwner(id)

            };
            return View(VM);
        }

        public PartialViewResult TicketedActivity(int id)
        {
            ScheduleHandler scheduleHandler = new ScheduleHandler();

            return PartialView("_TicketedActivity", scheduleHandler.Get_Ticketed_Actions(id));
        }
        public PartialViewResult MealActivity(int id)
        {
            ScheduleHandler scheduleHandler = new ScheduleHandler();

            return PartialView("_MealActivity",scheduleHandler.Get_Meal_Actions(id));
        }
        public PartialViewResult Accommodation(int id)
        {
            ScheduleHandler scheduleHandler = new ScheduleHandler();
            return PartialView("_Accommodation", scheduleHandler.Get_Accommodation(id));
        }
        public PartialViewResult Rented(int id)
        {
            ScheduleHandler scheduleHandler = new ScheduleHandler();
            return PartialView("_Rented", scheduleHandler.Get_Rented(id));
        }
        public ActionResult CreateSchedule(CreateScheduleModel model)
        {
            ScheduleHandler scheduleHandler = new ScheduleHandler();
            scheduleHandler.CreateSchedule(model);
            return RedirectToAction("Index", "Schedule",new { id=model.VACATION_ID });
        }
        public ActionResult CreateTicketedAct(CreateTicketedAct model)
        {
            ScheduleHandler scheduleHandler = new ScheduleHandler();
            scheduleHandler.CreateTicketedAct(model);
            return RedirectToAction("Index", "Schedule", new { id = model.VACATION_ID });
        }
        public ActionResult CreateMealAct(CreateMealAct model)
        {
            ScheduleHandler scheduleHandler = new ScheduleHandler();
            scheduleHandler.CreateMealAct(model);
            return RedirectToAction("Index", "Schedule", new { id = model.VACATION_ID });
        }

        public ActionResult CreateAccommodation(CreateAccommodation model)
        {
            ScheduleHandler scheduleHandler = new ScheduleHandler();
            scheduleHandler.CreateAccommodation(model);
            return RedirectToAction("Index", "Schedule", new { id = model.VACATION_ID });
        }
        public ActionResult CreateRented(CreateRented model)
        {
            ScheduleHandler scheduleHandler = new ScheduleHandler();
            scheduleHandler.CreateRented(model);
            return RedirectToAction("Index", "Schedule", new { id = model.VACATION_ID });
        }
        public ActionResult AddFriendToVac(AddFriendToVac model)
        {
            ScheduleHandler scheduleHandler = new ScheduleHandler();
            scheduleHandler.AddFriendToVac(model);
            return RedirectToAction("Index", "Schedule", new { id = model.VACATION_ID });
        }
        public string GetCompany(int id)
        {

            CompanyHandler companyHandler = new CompanyHandler();
            return companyHandler.GetCompany(id).CH_COMP_NAME;
        }
    }
}