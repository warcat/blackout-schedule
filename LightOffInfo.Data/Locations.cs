using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using LightOffInfo.Data.DataAdapters;

namespace LightOffInfo.Data
{
    public class LocationsLoader
    {
        private readonly HttpClient _http;

        public LocationsLoader(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<Location>> LoadAsync(string url) =>
            await _http.GetFromJsonAsync<Location[]>(url);

        public async Task LoadScheduleAsync(Location location)
        {
            var adapterType = Type.GetType("LightOffInfo.Data.DataAdapters." + location.DataAdapter + ", LightOffInfo.Data");
            var instance = Activator.CreateInstance(adapterType, _http) as ILightOffInfoDataAdapter;
            location.Schedules = await instance.GetSchedules(location.DataUrl);
        }
    }
}
