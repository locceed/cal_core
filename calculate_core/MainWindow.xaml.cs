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
using System.Threading;
namespace calculate_core
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        static public int a;//15~16
        DateTime b;
        private void input_KeyUp(object sender, KeyEventArgs e)
        {
            output.Text = other.time(input.Text);
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
           timer();
            b = DateTime.Now.AddMinutes(1);
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
        }
        
        public void timer()
        {
            System.Timers.Timer timer1 = new System.Timers.Timer(1);
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Elapsed);
            timer1.AutoReset = true;
            timer1.Enabled = true;
        }
        public void timer1_Elapsed(object source, System.Timers.ElapsedEventArgs e)

        {
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                output.Text = (DateTime.Now - b).ToString() ;
            }));
        }
    }
}
