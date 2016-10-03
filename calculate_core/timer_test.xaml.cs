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

namespace calculate_core
{
    /// <summary>
    /// 计时器.xaml 的交互逻辑
    /// </summary>
    public partial class 计时器 : Window
    {
        public 计时器()
        {
            InitializeComponent();
        }
        System.Timers.Timer timer1 = new System.Timers.Timer(1);
        static public int a;//15~16
        DateTime b;
        public void timer()
        {
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Elapsed);
            timer1.AutoReset = true;
            timer1.Enabled = true;
        }
        public void timer1_Elapsed(object source, System.Timers.ElapsedEventArgs e)

        {
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                timeshow.Text = (DateTime.Now - b).ToString();
            }));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            b = DateTime.Now.AddHours(Convert.ToInt64(hh.Text)).AddMinutes(Convert.ToInt64(mm.Text)).AddSeconds(Convert.ToInt64(ss.Text));
            timer();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            b = DateTime.Now;
            timer();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            timer1.Enabled = false;
            b = Convert.ToDateTime("00:00:00");
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            timeshow.Text = "00:00:00";
        }
    }
}
