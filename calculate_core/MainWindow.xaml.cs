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
        public MainWindow()
        {
            InitializeComponent();
            /*
            output.Text = "";
            for (int xx = 0; xx <= part_handled.Length - 1; xx++)
            {
               //output.Text = output.Text + "<" + part_num[xx].ToString() + ">";
            }
            */
            //这是测试用的。
        }
        static public string test(string input)
        {
            if (input.First().ToString().IndexOfAny("+-".ToArray()) == -1)//统一格式
            {
                input = "+" + input;
            }
            int x1 = 0;
            int x2 = 0;//多余
            int opnum = 0;
            x1 = input.IndexOfAny("+-".ToArray(), x1);//分割3
            x1++;
            opnum++;
            while (true)
            {
                x1 = input.IndexOfAny("+-".ToArray(), x1);
                if (x1 == -1)
                {
                    break;
                }
                if (input.Substring(x1 - 1).First().ToString() == "*" || input.Substring(x1 - 1).First().ToString() == "/")
                {
                    if (x1 != -1)
                    {
                        x1++;
                    }
                }
                else
                {
                    opnum++;
                    if (x1 != -1)
                    {
                        x1++;
                    }
                }
            }
            x1 = 0;
            x2 = 0;
            int[] oplocation = new int[opnum];
            string[] part = new string[opnum];
            x1 = input.IndexOfAny("+-".ToArray(), x1);//符号位置3
            oplocation[x2] = x1;
            x1++;
            x2++;
            while (true)
            {
                x1 = input.IndexOfAny("+-".ToArray(), x1);
                if (x1 == -1)
                {
                    break;
                }
                if (input.Substring(x1 - 1).First().ToString() == "*" || input.Substring(x1 - 1).First().ToString() == "/")
                {
                    if (x1 != -1)
                    {
                        x1++;
                    }
                }
                else
                {
                    oplocation[x2] = x1;
                    x2++;
                    if (x1 != -1)
                    {
                        x1++;
                    }
                }
            }
            string a = opnum.ToString();
            return a;
        }//test
        private void input_KeyUp(object sender, KeyEventArgs e)
        {
            output.Text = other.bracket1(input.Text);
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            input.Text = "";
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            output.Text = "";
        }
    }
}
