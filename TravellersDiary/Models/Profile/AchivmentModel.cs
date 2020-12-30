using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravellersDiary.Models.Profile
{
    public class AchivmentModel
    {
        public int PK_ACHIVMENT_ID { get; set; }
        public int TRAVELLER_ID { get; set; }
        public string CH_ACH_NAME { get; set; }
        public DateTime DT_DATE { get; set; }
    }
}