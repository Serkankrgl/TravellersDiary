using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravellersDiary.Models.Profile
{
    public class Follow
    {
        public int TRAVELLER_ID { get; set; }
        public int FOLLOWER_ID { get; set; }
    }
}