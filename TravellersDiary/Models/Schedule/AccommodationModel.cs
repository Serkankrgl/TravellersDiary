using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravellersDiary.Models.Schedule
{
    public class Accommodation
    {
        public int PK_ACCOMMODATION_ID { get; set; }
        public int COMPANY_ID { get; set; }
        public int VACATION_ID { get; set; }
        public string TXT_ADDRESS { get; set; }
        public string CH_ACC_TYPE { get; set; }
        public int MNY_COSTOFACC { get; set; }
    }
}