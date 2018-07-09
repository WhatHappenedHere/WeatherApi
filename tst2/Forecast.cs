using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi
{
    public class Forecast
    {
        public class MainDetailF
        {
            public double temp { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
            public double pressure { get; set; }
            public double sea_level { get; set; }
            public double grnd_level { get; set; }
            public int humidity { get; set; }
            public double temp_kf { get; set; }
        }

        public class WeatherF
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }

        public class CloudsF
        {
            public int all { get; set; }
        }

        public class WindF
        {
            public double speed { get; set; }
            public double deg { get; set; }
        }

        public class RainF
        {
            public double rain { get; set; }
        }

        public class SysF
        {
            public string pod { get; set; }
        }

        public class ForecastLst
        {
            public List<ForecastF> flist { get; set; }
        }

        public class ForecastF
        {
            
            public DateTime dt { get; set; }
            public MainDetailF main { get; set; }
            public List<WeatherF> weather { get; set; }
            public CloudsF clouds { get; set; }
            public WindF wind { get; set; }
            public RainF rain { get; set; }
            public SysF sys { get; set; }
            public string dt_txt { get; set; }
        }

        public class CoordF
        {
            public double lat { get; set; }
            public double lon { get; set; }
        }

        public class CityF
        {
            public int id { get; set; }
            public string name { get; set; }
            public CoordF coord { get; set; }
            public string country { get; set; }
        }

        public class RootObjectF
        {
            public string cod { get; set; }
            public double message { get; set; }
            public int cnt { get; set; }
            public List<ForecastF> list { get; set; }
            public CityF city { get; set; }
        }
    }
}
