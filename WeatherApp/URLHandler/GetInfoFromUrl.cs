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
        static Adaptee adaptee = new Adaptee();

        public static void SetInf(string originUrl, out OpenWeather.OpenWeather weather)
        {
            
            ITarget target = new Adapter(adaptee);
            weather = JsonConvert.DeserializeObject<OpenWeather.OpenWeather>(target.getDataString(originUrl));
            
        }
        public static void SetInf(string originUrl, out OpenWeatherForecast.OpenWeatherForecast weather)
        {
            
            ITarget target = new Adapter(adaptee);
            weather = JsonConvert.DeserializeObject<OpenWeatherForecast.OpenWeatherForecast>(target.getDataString(originUrl));

        }
       
    }
}
