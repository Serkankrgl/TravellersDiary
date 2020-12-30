using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravellersDiary.Models.Memory
{
    public class MemoryModel
    {
        public int PK_MEMORIES_ID { get; set; }
        public DateTime DT_DATE { get; set; }
        public int TRAVELLER_ID { get; set; }
        public string TXT_MEMORY { get; set; }
    }
}