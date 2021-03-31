using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WeatherApp
{
    class DataHendler
    {
        public static int[] GetArrayTemp(OpenWeatherForecast.OpenWeatherForecast weath,int size)
        {

            int[] masive = new int[size];

            for(int i = 0; i < size; i++)
            {
                masive[i] =  (int)weath.list[i].main.temp;
            }

            return masive;
        }
        public static string[] GetArrayData(OpenWeatherForecast.OpenWeatherForecast weath,int size)
        {
            string[] masive = new string[size];

            for (int i = 0; i < size; i++)
            {
                //numebers = Convert.ToInt32(new String(SplitDataTime(weather.list[i].dt_txt).Where(Char.IsDigit).ToArray()));

                masive[i] = weath.list[i].dt_txt;
            }


            return masive;
        }
        public static Image[] GetArrayImg(OpenWeatherForecast.OpenWeatherForecast weath, int size)
        {
            Image[] masive = new Image[size];

            for (int i = 0; i < size; i++)
            {
                //numebers = Convert.ToInt32(new String(SplitDataTime(weather.list[i].dt_txt).Where(Char.IsDigit).ToArray()));

                masive[i] = weath.list[i].weather[0].Icon;
            }


            return masive;
        }
        /* public static string SplitDataTime(string input)
         {
             string[] splited_input = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
             string secondTime = splited_input[1];
             string[] splited = secondTime.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
             string time = splited[0];
             return time;
         }*/
        public static string SplitDataData(string input)
        {
            string[] splited_input = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string secondData = splited_input[0];
            
            return secondData;
        }
    }
}
