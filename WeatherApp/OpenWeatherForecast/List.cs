using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.OpenWeatherForecast
{
    class List
    {
        public int dt;

        public OpenWeather.Main main;

        public OpenWeather.Weather[] weather;

        public OpenWeather.Clouds clouds;

        public OpenWeather.Wind wind;

        public int visibility;

        public double pop;

        public OpenWeather.Sys sys;

        public string dt_txt;
    }
}
