using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravellersDiary.Models.Company
{
    public class CreateCompany
    {
        public string CH_COMP_NAME { get; set; }
        public int INT_QUALITY { get; set; }
        public string TM_CLOSING_TIME { get; set; }
        public string TM_OPENING_TIME { get; set; }
        public string TXT_COMP_DESCRIPTION { get; set; }
        public string TXT_COMP_SITE { get; set; }
    }
}