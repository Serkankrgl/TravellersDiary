using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravellersDiary.Models.Global;
using TravellersDiary.Models.Home;

namespace TravellersDiary.ViewModels
{
    public class VacationViewModels
    {
        public List<VacationBadge> Badges { get; set; }
        public Traveller Traveller { get; set; }
    }
}