using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravellersDiary.Models.Schedule
{
    public class CreateRented
    {
        public string TXT_OBJECT { get; set; }
        public int COMPANY_ID { get; set; }
        public int VACATION_ID { get; set; }
        public int MNY_COSTOFRENT { get; set; }
    }
}