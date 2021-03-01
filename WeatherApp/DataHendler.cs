using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    class DataHendler
    {
        public static int[] GetArray(OpenWeatherForecast.OpenWeatherForecast weather,int size)
        {

            int[] masive = new int[size];

            for(int i = 0; i < size; i++)
            {
                masive[i] =  (int)weather.list[i].main.temp;
            }

            return masive;

        }
    }
}
