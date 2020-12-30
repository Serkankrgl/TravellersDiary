using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravellersDiary.Models.Schedule
{
    public class MealActivityModel
    {
        public int PK_MEAL_ID { get; set; }
        public string MEAL_NAME { get; set; }
        public int RATING { get; set; }
        public int COST_OF { get; set; }
        public string ACT_TITLE { get; set; }
        public string ACT_DETAILS { get; set; }
        public string ACT_START_TIME { get; set; }
        public string ACT_FNISH_TIME { get; set; }
        public int COMPANY_ID { get; set; }
        public int ACTIVITY_ID { get; set; }
    }
}