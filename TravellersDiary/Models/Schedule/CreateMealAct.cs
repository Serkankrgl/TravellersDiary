using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravellersDiary.Models.Schedule
{
    public class CreateMealAct
    {
        public int BASE_SCHEDULE_ID { get; set; }
        public string CH_TITLE { get; set; }
        public string TXT_ACT_DETAILS { get; set; }
        public string TM_FNISH_TIME { get; set; }
        public string TM_START_TIME { get; set; }
        public int TRAVELLER_ID { get; set; }
        public int COMPANY_ID { get; set; }
        public int MNY_COST_OF { get; set; }
        public int INT_RATING { get; set; }
        public string TXT_MEAL_NAME { get; set; }
        public int VACATION_ID { get; set; }
    }
}