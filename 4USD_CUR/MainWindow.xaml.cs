using System;
using System.Collections.Generic;
using System.Linq;
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


namespace _4USD_CUR
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 
   
    public partial class MainWindow : Window
    {
        string sReqStr = "";
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
            string sUrl = "http://api.manana.kr/exchange/rate/";
            sUrl += "USD/"+ cboCurrency.SelectionBoxItem.ToString() + ".Json";


        }

        private void BtnNotice_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("이 프로그램은 4달러를 여러 통화단위로 변환해주는 프로그램 입니다. \n환율정보는 오차가 있을 수 있습니다. \nPowered By pureani.tistory.com", "알림");
        }


    }
}
