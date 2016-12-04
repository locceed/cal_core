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
        
        private void input_KeyUp(object sender, KeyEventArgs e)
        {
            //output.Text = other.bracket1(input.Text);
            output.Text = other.abs1(input.Text);
            //output.Text = Cal.test(input.Text);
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            output.Text = Cal.test(input.Text);
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            output.Text = Cal.cal4(input.Text);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
