using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightOffInfo.Data
{
    public class Schedule
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Desciption { get; set; }
        public OfflineTime[] OfflineTimes { get; internal set; }

        public Schedule()
        {
            OfflineTimes = Array.Empty<OfflineTime>();
        }
    }
}
