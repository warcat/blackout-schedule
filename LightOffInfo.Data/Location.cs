using System.Text.Json.Serialization;

namespace LightOffInfo.Data
{
    public class Location
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }
        
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        
        [JsonPropertyName("dataUrl")]
        public string? DataUrl { get; set; }

        [JsonPropertyName("dataAdapter")]
        public string? DataAdapter { get; set; }

        public Schedule[] Schedules { get; internal set; }

        public Location()
        {
            Schedules = Array.Empty<Schedule>();
        }
    }
}