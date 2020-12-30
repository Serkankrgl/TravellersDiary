using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravellersDiary.Models.Profile
{
    public class EditProfile
    {
        public int PK_TRAVELLER_ID { get; set; }
        public string TXT_ABOUT { get; set; }
        public string CH_TAG_NAME { get; set; }
    }
}