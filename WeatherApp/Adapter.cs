using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    class Adaptee: IString
    {
        private static HttpWebRequest httpWebRequest;

        private static HttpWebResponse httpWebResponse;
        public string getDataString(string url)
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
    class Adapter
    {
       public string GetData(IString target,string str)
        {
            return target.getDataString(str);
        }
    }
    public interface IStoka
    {
        string getString(string s);
    }
}
