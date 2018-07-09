using System.Collections.Generic;

namespace WeatherApi
{
    public class ForecastModel
    {
        public class ForecastInfo
        {
            public List<CurObjct> curInfo { get; set; }
        }

        public class City
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Wind
        {
            public double speed { get; set; }
            public double deg { get; set; }
        }

        public class Clouds
        {
            public double all { get; set; }
        }

        public class Main
        {            
            public double temp_min { get; set; }
            public double temp_max { get; set; }
        }

        public class Weather
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }

        public class CurObjct
        {
            public Main main { get; set; }
            public Wind wind { get; set; }
            public Clouds clouds { get; set; }
            public int dt { get; set; }
            public List<Weather> weather { get; set; }

        }

        public class RootObjectF
        {
            public City city { get; set; }
            public string country { get; set; }
            public int cnt { get; set; }
            public List<CurObjct> list { get; set; }
        }
    }
}
