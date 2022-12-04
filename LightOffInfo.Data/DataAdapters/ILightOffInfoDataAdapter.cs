using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightOffInfo.Data.DataAdapters
{
    public interface ILightOffInfoDataAdapter
    {
        Task<Schedule[]> GetSchedules(string dataUrl);
    }
}
