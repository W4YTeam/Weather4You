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
        private static HttpWebRequest httpWebRequest;

        private static HttpWebResponse httpWebResponse;
        public static void SetInf(string originUrl, out OpenWeather.OpenWeather weather)
        {

            weather = JsonConvert.DeserializeObject<OpenWeather.OpenWeather>(getDataString(originUrl));

        }
        public static void SetInf(string originUrl, out OpenWeatherForecast.OpenWeatherForecast weather)
        {

            weather = JsonConvert.DeserializeObject<OpenWeatherForecast.OpenWeatherForecast>(getDataString(originUrl));

        }
        /// <summary>
        /// Принимает строку и возвращает ответ с сервера в виде строки
        /// </summary>
        /// <param name="url">Запрос</param>
        /// <returns>Ответ сервера в виде строки</returns>
        private static string getDataString(string url)
        {
            httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string answer = string.Empty;

            using (Stream s = httpWebResponse.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(s))
                {
                    answer = reader.ReadToEnd();
                }
            }

            httpWebResponse.Close();

            return answer;
        }
    }
}
