using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.IO;
namespace WeatherApp
{
    class GetInfoFromUrl
    {
        static Adapter adapter = new Adapter(); 

        public static void SetInf(string originUrl, out OpenWeather.OpenWeather weather)
        {

            Adaptee adaptee = new Adaptee();
            weather = JsonConvert.DeserializeObject<OpenWeather.OpenWeather>(adapter.GetData(adaptee,originUrl));
            
        }
        public static void SetInf(string originUrl, out OpenWeatherForecast.OpenWeatherForecast weather)
        {

            Adaptee adaptee = new Adaptee();
            weather = JsonConvert.DeserializeObject<OpenWeatherForecast.OpenWeatherForecast>(adapter.GetData(adaptee, originUrl));

        }
       
    }
}
