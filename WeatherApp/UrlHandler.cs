using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace WeatherApp
{
    class UrlHandler
    {
        static HttpWebRequest myHttpWebRequest;
        /// <summary>
        /// Проверяет возникают ли по ссылке ошибки
        /// </summary>
        /// <param name="url">URL для проверки</param>
        /// <returns></returns>
        public static bool UrlCheck(string url)
        {
            myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            try 
            { 
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                myHttpWebResponse.Close();
            }
            catch(WebException)
            {
                return false;
            }
            return true;
        }
    }
}
