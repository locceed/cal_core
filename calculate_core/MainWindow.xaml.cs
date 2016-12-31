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
        timer t1 = new timer();
        private void input_KeyUp(object sender, KeyEventArgs e)
        {
            output.Text = equation.one_one(input.Text);
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            output.Text = equation.two_one(input.Text.Substring(0, input.Text.IndexOf("&")), input.Text.Substring(input.Text.IndexOf("&") + 1));
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            input.Text = other.rannum(1,1);
            output.Text = Cal.docal(input.Text);
        }
    }
}
