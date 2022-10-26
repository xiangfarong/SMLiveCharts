using Mw.SimulationCore.ClientHC.ViewModel;
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
using System.Windows.Shapes;
using Mw.SimulationCore.ClientHC.ViewModel;

namespace Mw.SimulationCore.ClientHC
{
    /// <summary>
    /// LiveChartWin.xaml 的交互逻辑
    /// </summary>
    public partial class LiveChartWin : Window
    {
        Mode modes = null;
        public LiveChartWin()
        {
            modes = new Mode();
            InitializeComponent();
        }
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    //int count = 100;
        //    //while (count>0) 
        //    //{
        //    //    modes.OnClick();

        //    //    count--;
        //    //    System.Threading.Thread.Sleep(200);
        //    //}
        //    modes.OnClick();

        //}

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = modes;
        }
    }
}
