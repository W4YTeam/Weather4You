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
        public static OpenWeather.OpenWeather GetInf(string originUrl)
        {
            httpWebRequest = (HttpWebRequest)WebRequest.Create(originUrl);

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

            OpenWeather.OpenWeather inf = JsonConvert.DeserializeObject<OpenWeather.OpenWeather>(answer);

            return inf;
        }
    }
}
