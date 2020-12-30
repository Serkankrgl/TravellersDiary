using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravellersDiary.Models.Auth
{
    public class RegisterModel
    {
        public string CH_Tag_Name { get; set; }
        public string CH_Email { get; set; }
        public string CH_Password { get; set; }
        public string CH_FirstName { get; set; }
        public string CH_LastName { get; set; }
    } 
}