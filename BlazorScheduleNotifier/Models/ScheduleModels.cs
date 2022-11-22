using System.Text.Json.Serialization;

namespace BlazorScheduleNotifier.Models
{
    public class City
    {
        public string name { get; set; }
        public List<Queue> queues { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class OfflineTime
    {
        public string from { get; set; }
        [JsonIgnore]
        public TimeSpan From => TimeSpan.Parse(from);

        public string to { get; set; }
        [JsonIgnore]
        public TimeSpan To => TimeSpan.Parse(to);
    }

    public class Range
    {
        public List<int> days { get; set; }
        public List<OfflineTime> offline_time { get; set; }
    }

    public class Queue
    {
        [JsonIgnore]
        public bool IsChecked { get; set; } = true;
        public string name { get; set; }
        public List<Range> ranges { get; set; }
    }

    public class QueueTime
    {
        public QueueTime(Queue queue, OfflineTime time)
        {
            Queue = queue;
            Time = time;
        }

        public Queue Queue { get; }
        public OfflineTime Time { get; }
    }
}
