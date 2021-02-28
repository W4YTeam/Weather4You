using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Net;

namespace WeatherApp.OpenWeather
{
    class Weather
    {
        public int id;

        public string main;

        public string description;

        public string icon;

        public Image Icon
        {
            get
            {
                return GetImageFromPicPath(icon);
            }
        }
        public static Image GetImageFromPicPath(string strUrl)
        {
            string first_part = "http://openweathermap.org/img/wn/";
            string second_part = "@4x.png";
            string main_str = first_part + strUrl + second_part;

            using (WebResponse wrFileResponse = WebRequest.Create(main_str).GetResponse())
            using (Stream objWebStream = wrFileResponse.GetResponseStream())
            {
                MemoryStream ms = new MemoryStream();
                objWebStream.CopyTo(ms, 8192);
                return System.Drawing.Image.FromStream(ms);
            }
        }
    }
}
