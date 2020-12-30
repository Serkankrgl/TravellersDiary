using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravellersDiary.Models.Company;
using TravellersDiary.Models.Global;
using TravellersDiary.Models.Home;
using TravellersDiary.Models.Profile;
using TravellersDiary.Models.Schedule;

namespace TravellersDiary.ViewModels
{
    public class ScheduleViewModel
    {
        public Traveller Traveller { get; set; }
        public VacationBadge VacationBadge { get; set; }
        public List<ScheduleModel> Schedules { get; set; }
        public List<CompanyModel> Companys { get; set; }
        public List<Following> Followings { get; set; }
        public List<Following> Owners { get; set; }
    };
}