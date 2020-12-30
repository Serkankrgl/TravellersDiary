using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravellersDiary.Models.Home
{
    public class VacationBadge
    {
        public int PK_VACATION_ID { get; set; }
        public string CH_TITLE { get; set; }
        public string TXT_INFO { get; set; }
        public int MNY_BUDGET { get; set; }
        public int MNY_COSTOFVAC { get; set; }
        public string CH_TAG_NAME { get; set; }
        public DateTime DT_CREATION { get; set; }
        public int PK_TRAVELLER_ID { get; set; }
    }
}