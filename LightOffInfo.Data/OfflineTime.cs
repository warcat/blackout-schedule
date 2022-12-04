using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightOffInfo.Data
{
    public class OfflineTime
    {
        public DayOfWeek[]? DayOfWeek { get; set; }
        public int[]? DayOfMonth { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
    }
}
