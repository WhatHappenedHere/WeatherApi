using System;
using System.Collections.Generic;

namespace tst2
{
    public class OpenWeatherMapApi
    {
        public class WeatherInfo
        {
            public double Temperature { get; set; }
            public double speed { get; set; }
            public double deg { get; set; }
            public double cloud { get; set; }
            public string Name { get; set; }
            public DateTime Datetime { get; internal set; }
            public string Country { get; internal set; }
            public List<Weather> Weather { get; set; }
        }

       
        public class Weather
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }

        public class Main
        {
            public double temp { get; set; }
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

        public class Sys
        {
            public int type { get; set; }
            public int id { get; set; }
            public double message { get; set; }
            public string country { get; set; }
            public int sunrise { get; set; }
            public int sunset { get; set; }
        }
             
       

            public class RootObject
        {
            public List<Weather> weather { get; set; }
            public string @base { get; set; }
            public Main main { get; set; }
            public Wind wind { get; set; }
            public Clouds clouds { get; set; }
            public int dt { get; set; }
            public Sys sys { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public int cod { get; set; }
        }
    }
}
