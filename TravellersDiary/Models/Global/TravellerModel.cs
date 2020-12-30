using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravellersDiary.Models.Global
{
    public class Traveller
    {
        public int PK_TRAVELLER_ID { get; set; }
        public string CH_TAG_NAME { get; set; }
        public string CH_EMAIL { get; set; }
        public string CH_FIRSTNAME { get; set; }
        public string CH_LASTNAME { get; set; }
        public string TXT_ABOUT { get; set; }
        public DateTime DT_CREATION { get; set; }
    }
}