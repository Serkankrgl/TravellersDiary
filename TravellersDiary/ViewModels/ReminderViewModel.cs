using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravellersDiary.Models.Global;
using TravellersDiary.Models.Reminder;

namespace TravellersDiary.ViewModels
{
    public class ReminderViewModel
    {
        public List<ReminderModel> reminders { get; set; }
        public Traveller traveller { get; set; }
    }
}