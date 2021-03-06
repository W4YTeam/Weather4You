﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace WeatherApp
{
    public partial class Main_UI : Form
    {
        private static int[] weather = new int[9];//test
        private static string[] data = new string[9];
        private static Image[] images = new Image[9];
        private static string city;
        private static string city_old;
        private static bool chart_builded = false;

        OpenWeather.OpenWeather owCurrent;

        OpenWeatherForecast.OpenWeatherForecast owForecast;

        private Point lastpoint;

        HttpWebRequest myHttpWebRequest;

        HttpWebResponse myHttpWebResponse;

        private static readonly string testUrl = "http://api.openweathermap.org/data/2.5/forecast?q=Kyiv&units=metric&lang=ru&appid=570c596303b3a427d268327c855a1171";

        private static readonly string forecastUrlPt1 = "http://api.openweathermap.org/data/2.5/forecast?q=";

        private static readonly string forecastUrlPt3 = "&units=metric&lang=ru&appid=570c596303b3a427d268327c855a1171";

        private static readonly string urlForStart = "http://api.openweathermap.org/data/2.5/weather?q=Kyiv&units=metric&lang=ru&appid=570c596303b3a427d268327c855a1171";

        private static readonly string todayUrlPt1 = "http://api.openweathermap.org/data/2.5/weather?q=";

        private static readonly string todayUrlPt3 = "&units=metric&lang=ru&appid=570c596303b3a427d268327c855a1171";
        public Main_UI()
        {
            InitializeComponent();
        }
        private void For_Main_panel_click(Panel panel)
        {
            panel1.BringToFront();
            Size a = new Size(170, 484);
            Size b = new Size(170, 38);
            if (panel.Size == a)
            {
                panel.Size = b;
            }
            else panel.Size = a;
        }
        private async void For_click( Label label, string city_name)
        {
            city = city_name;
            await Task.Run(() => ShowInf(city));
            Size a = new Size(170, 38);
            panel1.Size = a;
            label16.Text = label.Text;
        }
        #region panel
        private void panel2_Click(object sender, EventArgs e)
        {
            For_Main_panel_click(panel1);
        }

        private void label16_Click(object sender, EventArgs e)
        {
            For_Main_panel_click(panel1);
        }
        

        private  void panel3_Click(object sender, EventArgs e)
        {
            For_click(label1, "Kyiv");    
        }

        private  void label1_Click(object sender, EventArgs e)
        {
            For_click(label1, "Kyiv");
        }
        //
        private  void panel4_Click(object sender, EventArgs e)
        {
            For_click(label4, "Lviv");
        }

        private void label4_Click(object sender, EventArgs e)
        {
            For_click(label4, "Lviv");
        }
        //
        private  void label5_Click(object sender, EventArgs e)
        {
            For_click(label5, "Odessa");
        }

        private  void panel5_Click(object sender, EventArgs e)
        {
            For_click(label5, "Odessa");
        }
        //
        private  void label6_Click(object sender, EventArgs e)
        {
            For_click(label6, "Herson");
        }

        private  void panel6_Click(object sender, EventArgs e)
        {
            For_click(label6, "Herson");
        }
        //
        private void label7_Click(object sender, EventArgs e)
        {
            For_click(label7, "Khmelnytskyi");
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            For_click(label7, "Khmelnytskyi");
        }
        //
        private void label8_Click(object sender, EventArgs e)
        {
            For_click(label8, "Kharkiv");
        }

        private void panel8_Click(object sender, EventArgs e)
        {
            For_click(label8, "Kharkiv");
        }
        //
        private void label9_Click(object sender, EventArgs e)
        {
            For_click(label9, "Vinnytsia");
        }

        private void panel9_Click(object sender, EventArgs e)
        {
            For_click(label9, "Vinnytsia");
        }
        //
        private void label10_Click(object sender, EventArgs e)
        {
            For_click(label10, "Uzhhorod");
        }

        private void panel10_Click(object sender, EventArgs e)
        {
            For_click(label10, "Uzhhorod");
        }
        //
        private void label11_Click(object sender, EventArgs e)
        {
            For_click(label11, "Chernivtsi");
        }

        private void panel11_Click(object sender, EventArgs e)
        {
            For_click(label11, "Chernivtsi");
        }
        //
        private void label12_Click(object sender, EventArgs e)
        {
            For_click(label12, "Donetsk");
        }

        private void panel12_Click(object sender, EventArgs e)
        {
             For_click(label12, "Donetsk");
        }
        //
        private void label13_Click(object sender, EventArgs e)
        {
            For_click(label13, "Poltava");
        }

        private void panel13_Click(object sender, EventArgs e)
        {
            For_click(label13, "Poltava");
        }
        //
        private void label14_Click(object sender, EventArgs e)
        {
            For_click(label14, "Sumy");
        }

        private void panel14_Click(object sender, EventArgs e)
        {
            For_click(label14, "Sumy");
        }
        //
        private void label15_Click(object sender, EventArgs e)
        {
            For_click(label15, "Dnepr");
        }

        private void panel15_Click(object sender, EventArgs e)
        {
            For_click(label15, "Dnepr");
        }
        //
        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(70, 110, 160);
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(94, 131, 186);
        }

        private void label16_MouseEnter(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(70, 110, 160);
        }

        private void label16_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(94, 131, 186);
        }
        //
        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(70, 110, 160);
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(94, 131, 186);
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(70, 110, 160);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(94, 131, 186);
        }
        //
        private void label4_MouseEnter(object sender, EventArgs e)
        {
            panel4.BackColor = Color.FromArgb(70, 110, 160);
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.FromArgb(94, 131, 186);
        }

        private void panel4_MouseEnter(object sender, EventArgs e)
        {
            panel4.BackColor = Color.FromArgb(70, 110, 160);
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.FromArgb(94, 131, 186);
        }
        //
        private void label5_MouseEnter(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(70, 110, 160);
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(94, 131, 186);
        }

        private void panel5_MouseEnter(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(70, 110, 160);
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(94, 131, 186);
        }
        //
        private void label6_MouseEnter(object sender, EventArgs e)
        {
            panel6.BackColor = Color.FromArgb(70, 110, 160);
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            panel6.BackColor = Color.FromArgb(94, 131, 186);
        }

        private void panel6_MouseEnter(object sender, EventArgs e)
        {
            panel6.BackColor = Color.FromArgb(70, 110, 160);
        }

        private void panel6_MouseLeave(object sender, EventArgs e)
        {
            panel6.BackColor = Color.FromArgb(94, 131, 186);
        }
        //
        private void label7_MouseEnter(object sender, EventArgs e)
        {
            panel7.BackColor = Color.FromArgb(70, 110, 160);
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            panel7.BackColor = Color.FromArgb(94, 131, 186);
        }

        private void panel7_MouseEnter(object sender, EventArgs e)
        {
            panel7.BackColor = Color.FromArgb(70, 110, 160);
        }

        private void panel7_MouseLeave(object sender, EventArgs e)
        {
            panel7.BackColor = Color.FromArgb(94, 131, 186);
        }
        //
        private void label8_MouseEnter(object sender, EventArgs e)
        {
            panel8.BackColor = Color.FromArgb(70, 110, 160);
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            panel8.BackColor = Color.FromArgb(94, 131, 186);
        }

        private void panel8_MouseEnter(object sender, EventArgs e)
        {
            panel8.BackColor = Color.FromArgb(70, 110, 160);
        }

        private void panel8_MouseLeave(object sender, EventArgs e)
        {
            panel8.BackColor = Color.FromArgb(94, 131, 186);
        }
        //
        private void label9_MouseEnter(object sender, EventArgs e)
        {
            panel9.BackColor = Color.FromArgb(70, 110, 160);
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            panel9.BackColor = Color.FromArgb(94, 131, 186);
        }

        private void panel9_MouseEnter(object sender, EventArgs e)
        {
            panel9.BackColor = Color.FromArgb(70, 110, 160);
        }

        private void panel9_MouseLeave(object sender, EventArgs e)
        {
            panel9.BackColor = Color.FromArgb(94, 131, 186);
        }
        //
        private void label10_MouseEnter(object sender, EventArgs e)
        {
            panel10.BackColor = Color.FromArgb(70, 110, 160);
        }

        private void label10_MouseLeave(object sender, EventArgs e)
        {
            panel10.BackColor = Color.FromArgb(94, 131, 186);
        }

        private void panel10_MouseEnter(object sender, EventArgs e)
        {
            panel10.BackColor = Color.FromArgb(70, 110, 160);
        }

        private void panel10_MouseLeave(object sender, EventArgs e)
        {
            panel10.BackColor = Color.FromArgb(94, 131, 186);
        }
        //
        private void label11_MouseEnter(object sender, EventArgs e)
        {
            panel11.BackColor = Color.FromArgb(70, 110, 160);
        }

        private void label11_MouseLeave(object sender, EventArgs e)
        {
            panel11.BackColor = Color.FromArgb(94, 131, 186);
        }

        private void panel11_MouseEnter(object sender, EventArgs e)
        {
            panel11.BackColor = Color.FromArgb(70, 110, 160);
        }

        private void panel11_MouseLeave(object sender, EventArgs e)
        {
            panel11.BackColor = Color.FromArgb(94, 131, 186);
        }
        //
        private void label12_MouseEnter(object sender, EventArgs e)
        {
            panel12.BackColor = Color.FromArgb(70, 110, 160);
        }

        private void label12_MouseLeave(object sender, EventArgs e)
        {
            panel12.BackColor = Color.FromArgb(94, 131, 186);
        }

        private void panel12_MouseEnter(object sender, EventArgs e)
        {
            panel12.BackColor = Color.FromArgb(70, 110, 160);
        }

        private void panel12_MouseLeave(object sender, EventArgs e)
        {
            panel12.BackColor = Color.FromArgb(94, 131, 186);
        }
        //
        private void label13_MouseEnter(object sender, EventArgs e)
        {
            panel13.BackColor = Color.FromArgb(70, 110, 160);
        }

        private void label13_MouseLeave(object sender, EventArgs e)
        {
            panel13.BackColor = Color.FromArgb(94, 131, 186);
        }

        private void panel13_MouseEnter(object sender, EventArgs e)
        {
            panel13.BackColor = Color.FromArgb(70, 110, 160);
        }

        private void panel13_MouseLeave(object sender, EventArgs e)
        {
            panel13.BackColor = Color.FromArgb(94, 131, 186);
        }
        //
        private void label14_MouseEnter(object sender, EventArgs e)
        {
            panel14.BackColor = Color.FromArgb(70, 110, 160);
        }

        private void label14_MouseLeave(object sender, EventArgs e)
        {
            panel14.BackColor = Color.FromArgb(94, 131, 186);
        }

        private void panel14_MouseEnter(object sender, EventArgs e)
        {
            panel14.BackColor = Color.FromArgb(70, 110, 160);
        }

        private void panel14_MouseLeave(object sender, EventArgs e)
        {
            panel14.BackColor = Color.FromArgb(94, 131, 186);
        }
        //
        private void label15_MouseEnter(object sender, EventArgs e)
        {
            panel15.BackColor = Color.FromArgb(70, 110, 160);
        }

        private void label15_MouseLeave(object sender, EventArgs e)
        {
            panel15.BackColor = Color.FromArgb(94, 131, 186);
        }

        private void panel15_MouseEnter(object sender, EventArgs e)
        {
            panel15.BackColor = Color.FromArgb(70, 110, 160);
        }

        private void panel15_MouseLeave(object sender, EventArgs e)
        {
            panel15.BackColor = Color.FromArgb(94, 131, 186);
        }

        
        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.BackColor = Color.FromArgb(94, 131, 186);
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.BackColor = Color.FromArgb(58, 78, 122);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.BackColor = Color.FromArgb(94, 131, 186);
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.BackColor = Color.FromArgb(58, 78, 122);
        }

        #endregion

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private async void Main_UI_Load(object sender, EventArgs e)
        {
            labelforselect.Select();
            myHttpWebRequest = (HttpWebRequest)WebRequest.Create(urlForStart);

            try
            {
                await Task.Run(() => GetInfoFromUrl.SetInf(testUrl, out owForecast));

                myHttpWebResponse = (HttpWebResponse)await myHttpWebRequest.GetResponseAsync();

                string answer = string.Empty;

                using (Stream s = myHttpWebResponse.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(s))
                    {
                        answer = await reader.ReadToEndAsync();
                    }
                }

                myHttpWebResponse.Close();

                OpenWeather.OpenWeather ow = JsonConvert.DeserializeObject<OpenWeather.OpenWeather>(answer);

                weather = DataHendler.GetArrayTemp(owForecast, 9);// - масив для температуры

                data = DataHendler.GetArrayData(owForecast, 9);// - масив для времени

                pictureBox1.Image = ow.weather[0].Icon;

                label22.Text = ow.weather[0].description;

                label21.Text = ow.main.temp.ToString("0.##")+ "℃";

                label23.Text = ow.wind.speed.ToString();

                label32.Text = ow.main.humidity.ToString();

                label24.Text = ((int)ow.main.pressure).ToString();

                label18.Text = ow.name.ToString();

                
                label61.Text = DataHendler.SplitDataData(owForecast.list[0].dt_txt);

                
                label49.Text = DataHendler.SplitDataData(owForecast.list[8].dt_txt);

                
                label33.Text = DataHendler.SplitDataData(owForecast.list[16].dt_txt);

                
                label43.Text = DataHendler.SplitDataData(owForecast.list[24].dt_txt);

                label28.Text = owForecast.list[8].wind.speed.ToString();

                label58.Text = owForecast.list[8].main.humidity.ToString();

                label30.Text = ((int)owForecast.list[8].main.pressure).ToString();

                label45.Text = (GetMinTemp(owForecast, 8, 17)).ToString("0.##") + "℃";

                label26.Text = (GetMaxTemp(owForecast, 8, 17)).ToString("0.##") + "℃";

                label40.Text = owForecast.list[16].wind.speed.ToString();

                label59.Text = owForecast.list[16].main.humidity.ToString();

                label37.Text = ((int)owForecast.list[16].main.pressure).ToString();

                label36.Text = (GetMinTemp(owForecast, 16, 25)).ToString("0.##") + "℃";

                label41.Text = (GetMaxTemp(owForecast, 16, 25)).ToString("0.##") + "℃";

                label55.Text = owForecast.list[24].wind.speed.ToString();

                label60.Text = owForecast.list[24].main.humidity.ToString();

                label52.Text = ((int)owForecast.list[24].main.pressure).ToString();

                label51.Text = (GetMinTemp(owForecast, 24, 33)).ToString("0.##") + "℃";

                label56.Text = (GetMaxTemp(owForecast, 24, 33)).ToString("0.##") + "℃";
            }
            catch (WebException ex)
            {
                MessageBox.Show($"Погода не найдена, проверте правильность данных.\n{ex.Status}", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка. Код ошибки: \n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == "Введите город")
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Введите город";
                labelforselect.Select();
            }
        }

        private void Main_UI_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void Main_UI_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;

            }
        }

        private async void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                city = textBox1.Text;
                await Task.Run(() => ShowInf(textBox1.Text));

                label16.Text = "Города Украины";
                textBox1.Text = "";
            }
        }
        /// <summary>
        ///  Заполняет данные про погоду по заданому городу
        /// </summary>
        /// <param name="town">Место с которого будет взята погода</param>
        private void ShowInf(string town)
        {
            if (UrlHandler.UrlCheck(todayUrlPt1 + town + todayUrlPt3) && UrlHandler.UrlCheck(forecastUrlPt1 + town + forecastUrlPt3))
            {
                GetInfoFromUrl.SetInf(todayUrlPt1 + town + todayUrlPt3, out owCurrent);

                GetInfoFromUrl.SetInf(forecastUrlPt1 + town + forecastUrlPt3, out owForecast);

                this.Invoke(new Action(() => {
                    images = DataHendler.GetArrayImg(owForecast, 9);

                    weather = DataHendler.GetArrayTemp(owForecast, 9);//Масив погоды

                    data = DataHendler.GetArrayData(owForecast, 9);//Маисв даты

                    if (chart_builded == false || city_old != city)
                    {

                        chart1.Series["Погода"].Points.Clear();
                        for (int i = 0, j = 0; j < 9; i++, j++)
                        {
                            chart1.Series["Погода"].Points.AddXY(data[j],weather[i]);
                        }
                        chart_builded = true;
                        city_old = city;
                        ptBoxa1.Image = images[0];
                        ptBoxa2.Image = images[1];
                        ptBoxa3.Image = images[2];
                        ptBoxa4.Image = images[3];
                        ptBoxa5.Image = images[4];
                        ptBoxa6.Image = images[5];
                        ptBoxa7.Image = images[6];
                        ptBoxa8.Image = images[7];
                        ptBoxa9.Image = images[8];
                    }

                    pictureBox1.Image = owCurrent.weather[0].Icon;

                    label22.Text = owCurrent.weather[0].description;

                    label21.Text = owCurrent.main.temp.ToString("0.##")+ "℃";

                    label23.Text = owCurrent.wind.speed.ToString();

                    label32.Text = owCurrent.main.humidity.ToString();

                    label24.Text = ((int)owCurrent.main.pressure).ToString();

                    label18.Text = owCurrent.name.ToString();

                    
                    label61.Text = DataHendler.SplitDataData(owForecast.list[0].dt_txt);

                    
                    label49.Text = DataHendler.SplitDataData(owForecast.list[8].dt_txt);

                    
                    label33.Text = DataHendler.SplitDataData(owForecast.list[16].dt_txt);

                    
                    label43.Text = DataHendler.SplitDataData(owForecast.list[24].dt_txt);

                    label28.Text = owForecast.list[8].wind.speed.ToString();

                    label58.Text = owForecast.list[8].main.humidity.ToString();

                    label30.Text = ((int)owForecast.list[8].main.pressure).ToString();

                    label45.Text = (GetMinTemp(owForecast, 8, 17)).ToString("0.##") + "℃";

                    label26.Text = (GetMaxTemp(owForecast, 8, 17)).ToString("0.##") + "℃";

                    label40.Text = owForecast.list[16].wind.speed.ToString();

                    label59.Text = owForecast.list[16].main.humidity.ToString();

                    label37.Text = ((int)owForecast.list[16].main.pressure).ToString();

                    label36.Text = (GetMinTemp(owForecast, 16, 25)).ToString("0.##") + "℃";

                    label41.Text = (GetMaxTemp(owForecast, 16, 25)).ToString("0.##") + "℃";

                    label55.Text = owForecast.list[24].wind.speed.ToString();

                    label60.Text = owForecast.list[24].main.humidity.ToString();

                    label52.Text = ((int)owForecast.list[24].main.pressure).ToString();

                    label51.Text = (GetMinTemp(owForecast, 24, 33)).ToString("0.##") + "℃";

                    label56.Text = (GetMaxTemp(owForecast, 24, 33)).ToString("0.##") + "℃";
                }));
            }
            else
                MessageBox.Show($"Погода не найдена, проверте правильность данных\nили подключение к интернету", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void label48_Click(object sender, EventArgs e)
        {

            images = DataHendler.GetArrayImg(owForecast, 9);
            Size old = new Size(739, 622);
            Size s_new = new Size(1360, 622);


            if (this.Size == old)
            {
                this.Size = s_new;
                label2.Location = new System.Drawing.Point(1326, -3);
                label3.Location = new System.Drawing.Point(1294, -3);
                if (chart_builded == false || city_old != city)
                {

                    chart1.Series["Погода"].Points.Clear();
                    for (int i = 0, j = 0; j < 9; i++, j++)
                    {
                        chart1.Series["Погода"].Points.AddXY(data[j], weather[i]);
                    }
                    chart_builded = true;
                    city_old = city;
                    ptBoxa1.Image = images[0];
                    ptBoxa2.Image = images[1];
                    ptBoxa3.Image = images[2];
                    ptBoxa4.Image = images[3];
                    ptBoxa5.Image = images[4];
                    ptBoxa6.Image = images[5];
                    ptBoxa7.Image = images[6];
                    ptBoxa8.Image = images[7];
                    ptBoxa9.Image = images[8];
                }
                //this.Show();
            }
            else
            {
                this.Size = old;
                label2.Location = new System.Drawing.Point(703, -3);
                label3.Location = new System.Drawing.Point(671, -3);
            //this.Show();
            }
        }

        private void label48_MouseEnter(object sender, EventArgs e)
        {
            label48.BackColor = Color.FromArgb(94, 131, 186);
        }

        private void label48_MouseLeave(object sender, EventArgs e)
        {
            label48.BackColor = Color.FromArgb(58, 78, 122);
        }

        private double GetMaxTemp(OpenWeatherForecast.OpenWeatherForecast ow,int start,int stop)
        {
            double temp = ow.list[start].main.temp;
            for(int i = start ;i < stop; i++)
            {
                if (temp < ow.list[i].main.temp)
                {
                    temp = ow.list[i].main.temp;
                }
            }
            return temp;
        }
        
        private double GetMinTemp(OpenWeatherForecast.OpenWeatherForecast ow,int start, int stop)
        {
            double temp = ow.list[start].main.temp;
            for (int i = start; i < stop; i++)
            {
                if (temp > ow.list[i].main.temp)
                {
                    temp = ow.list[i].main.temp;
                }
            }
            return temp;
        }
    }
}
