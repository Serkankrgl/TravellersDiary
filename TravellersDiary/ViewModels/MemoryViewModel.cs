using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravellersDiary.Models.Global;
using TravellersDiary.Models.Memory;

namespace TravellersDiary.ViewModels
{
    public class MemoryViewModel
    {
        public List<MemoryModel> memories { get; set; }
        public Traveller traveller { get; set; }
    }
}
