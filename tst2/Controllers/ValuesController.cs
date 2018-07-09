using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;

using static tst2.CrrntWeatherModel;
using static WeatherApi.ForecastModel;
using System.Net;

namespace tst2.Controllers
{

    public class ValuesController : Controller
    {


        public async Task<RootObject> CurrentWeatherString(HttpClient cons, string name)
        {
            using (cons)
            {
                HttpResponseMessage res = await cons.GetAsync("/data/2.5/weather?q=" +
                    name + "&APPID=7c104bec3fd35e45bceca9de995726b4&units=metric");
                res.EnsureSuccessStatusCode();
                if (res.IsSuccessStatusCode)
                {
                    string reader = await res.Content.ReadAsStringAsync();
                    RootObject result = JsonConvert.DeserializeObject<RootObject>(reader);
                    return result;
                }

                return null;
            }
        }
        public async Task<RootObjectF> WeatherForecastString(HttpClient cons, string name)
        {
            using (cons)
            {
                HttpResponseMessage res = await cons.GetAsync("/data/2.5/forecast?q=" +
                    name + "&APPID=7c104bec3fd35e45bceca9de995726b4&units=metric");
                res.EnsureSuccessStatusCode();
                if (res.IsSuccessStatusCode)
                {
                    string reader = await res.Content.ReadAsStringAsync();
                    RootObjectF result = JsonConvert.DeserializeObject<RootObjectF>(reader);
                    return result;
                }
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns>A newly created string with foreast</returns>
        public async Task<string> GetFrcstRes(string cityName)
        {
            HttpClient httpclnt = new HttpClient();
            httpclnt.BaseAddress = new Uri("http://api.openweathermap.org");
            httpclnt.DefaultRequestHeaders.Accept.Clear();
            httpclnt.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            RootObjectF rootObject = await WeatherForecastString(httpclnt, cityName);

            string rsltF = "";
            for (int i = 0; i < 38; i++)
            {
               rsltF += "DateTime: " + DateTimeOffset.FromUnixTimeSeconds(rootObject.list[i].dt).LocalDateTime +
                "\nTEMPERATURE\tMax temperature: " + rootObject.list[i].main.temp_max + "°C" +
                "\tMin temperature: " + rootObject.list[i].main.temp_min + "°C\n" +
                "\nWIND\tSpeed: " + rootObject.list[i].wind.speed + " meter/sec\tDirection: " +
                rootObject.list[i].wind.deg + " degrees(meteorological)\n" +
                "Cloudiness: " + rootObject.list[i].clouds.all + "%\n\n";
            }
          return rsltF;
        }

        /// <summary>
        /// Request that fill created weather model
        /// </summary>
        /// <param cityName = "Dnipropetrovsk"></param>
        /// /// <returns>A newly created RootObject</returns>
        public async Task<WeatherInfo> GetCurRes(string cityName)
                {
                    HttpClient cons = new HttpClient();
                    cons.BaseAddress = new Uri("http://api.openweathermap.org");
                    cons.DefaultRequestHeaders.Accept.Clear();
                    cons.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    RootObject rootObject = await CurrentWeatherString(cons, cityName);

                    WeatherInfo result = new WeatherInfo();
                    result.Temperature = rootObject.main.temp;
                    result.deg = rootObject.wind.deg;
                    result.speed = rootObject.wind.speed;
                    result.Name = rootObject.name;
                    result.Country = rootObject.sys.country;
                    result.Weather = rootObject.weather;
                    result.Datetime = DateTimeOffset.FromUnixTimeSeconds(rootObject.dt).LocalDateTime;
                    result.cloud = rootObject.clouds.all;
                    return result;
                }

        //GET api/GetCurrentWeather
        /// <summary>
        /// Request that returns the current weather in city
        /// Can be modified for changing parametr "city"
        /// </summary>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     GET /GetCurrentWeather
        ///     {
        ///        "weather.Result.Name": "Dnipropetrovsk",
        ///        "weather.Result.Country": "UA",
        ///        "weather.Result.Datetime": time of last weather data,
        ///        "weather.Result.Temperature": temperature value,
        ///        "weather.Result.speed": wind speed value,
        ///        "weather.Result.cloud": cloudiness
        ///     }
        ///
        /// </remarks>
        /// /// <returns>Text string</returns>
        /// <response code="200">Returns the newly weather report</response>
        /// <response code="404">If used returned object is null</response> 
        [HttpGet("api/GetCurrentWeather")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public string Get()
                {
                    var weather = GetCurRes("Dnipropetrovsk");
                    return "Current weather in "+ weather.Result.Name+", "+ weather.Result.Country+
                        " :\nDateTime: " + weather.Result.Datetime+
                        "\nTemperature: "+ weather.Result.Temperature+"°C\n"+
                        "WIND\tSpeed: "+ weather.Result.speed+ 
                        "meter/sec\tDirection: " + weather.Result.deg+ " degrees(meteorological)\n"+
                        "Cloudiness: "+ weather.Result.cloud+"%";
                }

        //GET api/GetForecast
        /// <summary>
        /// A request that returns  5 day forecast
        /// It includes weather data every 3 hours
        /// Can be modified for changing parametr "city"
        /// </summary>
        /// /// /// <remarks>
        /// Request result will contain:
        ///
        ///   GET /GetForecast
        ///     {
        ///        "rs": Result string   
        ///     }  
        ///
        /// </remarks>
        /// /// <returns>Text string</returns>
        /// <response code="200">Returns the newly weather report</response>
        /// <response code="404">If the string is null</response> 
        [HttpGet("api/GetForecast")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public string GetForecast()
        {
            string rs = GetFrcstRes("Dnipropetrovsk").Result;
            return "FORECAST\n" + rs;
        }
    }
}
