using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravellersDiary.Handlers.Global;
using TravellersDiary.Handlers.Memory;
using TravellersDiary.Models.Global;
using TravellersDiary.Models.Memory;
using TravellersDiary.ViewModels;

namespace TravellersDiary.Controllers
{
    public class MemoryController : Controller
    {
        // GET: Memory
        public ActionResult Index()
        {
            GlobalHandler globalHandler = new GlobalHandler();
            MemoryHandler memoryHandler = new MemoryHandler();
            Traveller traveller = globalHandler.GetTraveller(HttpContext.User.Identity.Name);
            MemoryViewModel VM = new MemoryViewModel()
            {
                traveller = traveller,
                memories = memoryHandler.GetMemories(traveller.PK_TRAVELLER_ID)
            };
            return View(VM);
        }
        public ActionResult CreateMemory(CreateMemory model)
        {
            MemoryHandler memoryHandler = new MemoryHandler();
            memoryHandler.CreateMemory(model);
            return RedirectToAction("Index", "Memory");
        }

        public ActionResult DeleteMemory(int id)
        {
            MemoryHandler memoryHandler = new MemoryHandler();
            memoryHandler.DeleteMemory(id);
            return RedirectToAction("Index", "Memory");
        }
    }
}