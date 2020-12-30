using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravellersDiary.Models.Home
{
    public class LikeModel
    {
        public int PK_VAC_RATE_ID { get; set; }
        public int TRAVELLER_ID { get; set; }
        public int VACATION_ID { get; set; }
        public bool SW_TYPE { get; set; }
    }
}