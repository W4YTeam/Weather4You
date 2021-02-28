using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.OpenWeatherForecast
{
    class City
    {
        public int id;

        public string name;

        public OpenWeather.Coord coord;

        public string country;

        public int timezone;

        public int sunrise;

        public int sunset;
    }
}
