using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravellersDiary.Models.Reminder
{
    public class CreateReminder
    {
        public int TRAVELLER_ID { get; set; }
        public string TXT_MESSAGE { get; set; }
        public DateTime DT_DATE { get; set; }
    }
}