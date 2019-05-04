using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.Media;

namespace _4USD_CUR
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 
   
    public partial class MainWindow : Window
    {
       
        HttpWebRequest clsRequest;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 버튼 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            //sound
            SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.sound);
            soundPlayer.Play();

            //vals
            DateTime dateCur;
            string sName;
            double nRate;

            //https get
            string sUrl = "https://api.manana.kr/exchange/rate/";
            //sUrl += "USD/"+ cboCurrency.SelectionBoxItem.ToString() + ".json";
            sUrl += cboCurrency.SelectionBoxItem.ToString() + "/USD.json";

            string sRes = "";
            clsRequest = (HttpWebRequest)WebRequest.Create(sUrl);
            clsRequest.Method = "GET";
            clsRequest.Timeout = 30 * 1000; // 30초

            using (HttpWebResponse resp = (HttpWebResponse)clsRequest.GetResponse())
            {
                HttpStatusCode status = resp.StatusCode;
                Console.WriteLine(status);  // 정상이면 "OK"

                Stream respStream = resp.GetResponseStream();
                using (StreamReader sr = new StreamReader(respStream))
                {
                    sRes = sr.ReadToEnd();
                }

                sRes.Replace("[", "");
                sRes.Replace("]", "");
                
            }
           
            try
            {
                JArray jarr = JArray.Parse(sRes);
                
                dateCur = (DateTime)jarr[0]["date"];
                sName = jarr[0]["name"].ToString();
                nRate = Convert.ToDouble(jarr[0]["rate"]);
                
                nRate *= 4;

                lblResult.Content = nRate + " "+ cboCurrency.SelectionBoxItem.ToString();
                lblCurTime.Content = dateCur.ToString("yyyy-MM-dd");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR");
            }
           
        }

        private void BtnNotice_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("이 프로그램은 4달러를 여러 통화단위로 변환해주는 프로그램 입니다. \n환율정보는 오차가 있을 수 있습니다. \nPowered By pureani.tistory.com", "알림");
        }


    }
}
