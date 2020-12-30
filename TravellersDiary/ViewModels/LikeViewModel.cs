using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravellersDiary.Models.Global;

namespace TravellersDiary.ViewModels
{
    public class LikeViewModel
    {
        public int LikeStatus { get; set; }
        public int VacationId { get; set; }
        public Traveller traveller { get; set; }
    }
}