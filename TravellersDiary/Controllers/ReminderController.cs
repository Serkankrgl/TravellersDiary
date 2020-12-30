using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravellersDiary.Handlers.Global;
using TravellersDiary.Handlers.Reminder;
using TravellersDiary.Models.Global;
using TravellersDiary.Models.Reminder;
using TravellersDiary.ViewModels;

namespace TravellersDiary.Controllers
{
    public class ReminderController : Controller
    {
        // GET: Reminder
        public ActionResult Index()
        {
            GlobalHandler globalHandler = new GlobalHandler();
            ReminderHandler reminderHandler = new ReminderHandler();
            Traveller traveller = globalHandler.GetTraveller(HttpContext.User.Identity.Name);
            ReminderViewModel VM = new ReminderViewModel()
            {
                traveller = traveller,
                reminders = reminderHandler.GetReminders(traveller.PK_TRAVELLER_ID)

            };
            return View(VM);
        }
        
        public ActionResult CreateReminder(CreateReminder model)
        {
            ReminderHandler reminderHandler = new ReminderHandler();
            reminderHandler.CreateReminder(model);
            return RedirectToAction("Index","Reminder");
        }

        public ActionResult DeleteReminder(int id)
        {
            ReminderHandler reminderHandler = new ReminderHandler();
            reminderHandler.DeleteReminder(id);
            return RedirectToAction("Index", "Reminder");
        }
    }
    
}