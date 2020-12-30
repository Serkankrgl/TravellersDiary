using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravellersDiary.Models.Reminder
{

    public class ReminderModel
    {
        public int PK_REMINDER_ID { get; set; }
        public int TRAVELLER_ID { get; set; }
        public DateTime DT_DATE { get; set; }
        public string TXT_MESSAGE { get; set; }
    }

}