using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravellersDiary.Models.Global;
using TravellersDiary.Models.Home;
using TravellersDiary.Models.Profile;

namespace TravellersDiary.ViewModels
{
    public class ProfileViewModel
    {
        public Traveller LogedInTraveller { get; set; }
        public Traveller Traveller { get; set; }
        public List<VacationBadge> Vacations { get; set; }
        public List<AchivmentModel> Achivments { get; set; }
        public bool FollowStatus { get; set; }
    }
}