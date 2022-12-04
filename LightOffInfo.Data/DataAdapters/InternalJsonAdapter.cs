using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace LightOffInfo.Data.DataAdapters
{
    public class InternalJsonAdapter : ILightOffInfoDataAdapter
    {
        private readonly HttpClient _http;

        public InternalJsonAdapter(HttpClient http)
        {
            _http = http;
        }

        public async Task<Schedule[]> GetSchedules(string dataUrl)
        {
            var data = await _http.GetFromJsonAsync<_Schedule[]>(dataUrl);
            return data?.Select(x => x.ToSchedule()).ToArray() ?? Array.Empty<Schedule>();
        }
    }

    internal class _Schedule
    {
        public string? name { get; set; }
        public string? type { get; set; }
        public string? description { get; set; }
        public _OfflineTime[] offlineTimes { get; set; }

        public _Schedule()
        {
            offlineTimes = Array.Empty<_OfflineTime>();
        }

        internal Schedule ToSchedule() => new()
        {
            Name = name,
            Type = type,
            Desciption = description,
            OfflineTimes = offlineTimes.Select(x => x.ToOfflineTime()).ToArray(),
        };
    }

    internal class _OfflineTime
    {
        public int[]? dayOfWeek { get; set; }
        public int[]? dayOfMonth { get; set; }
        public string? start { get; set; }
        public string? end { get; set; }

        internal OfflineTime ToOfflineTime() => new()
        {
            DayOfWeek = dayOfWeek?.Select(x => (DayOfWeek)x).ToArray(),
            DayOfMonth = dayOfMonth?.ToArray(),
            Start = TimeSpan.Parse(start ?? "00:00"),
            End = TimeSpan.Parse(end ?? "00:00"),
        };
    }
}
