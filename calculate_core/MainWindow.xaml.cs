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
        }
        private string cal1(string input)
        {
            try
            {
                if (input.First().ToString().IndexOfAny("-*/".ToArray()) == -1)
                {
                    input = "+" + input;
                }
                int if1 = 0;
                int x1 = 0;
                char[] a1 = "+-*/".ToArray();
                while (x1 != -1)//检测符号个数ok
                {
                    x1 = input.IndexOfAny(a1, x1 + 1);
                    if1++;
                }
                int[] x2 = new int[if1];
                string[] part = new string[if1 + 1];
                x1 = 0;
                if1 = 0;
                while (x1 != -1)//检测符号位置ok
                {
                    x1 = input.IndexOfAny(a1, x1 + 1);
                    if (x1 != -1)
                    {
                        x2[if1 + 1] = x1;
                        if1++;
                    }
                }
                for (int x3 = 0; x3 <= x2.Length - 1; x3++) //string分割ok
                {
                    if (x3 == x2.Length - 1)
                    {
                        part[x3] = input.Substring(x2[x3]);
                    }
                    else
                    {
                        part[x3] = input.Substring(x2[x3], x2[x3 + 1] - x2[x3]);
                    }
                }
                string[] part_op = new string[part.Length];
                double[] part_num = new double[part.Length - 1];
                for (int x4 = 0; x4 <= part.Length - 2; x4++)//分类ok
                {
                    part_op[x4] = part[x4].Substring(0, 1);
                    part_num[x4] = Convert.ToDouble(part[x4].Substring(1));
                }
                double result = 0;
                for (int x5 = 0; x5 <= part.Length - 2; x5++)//运算ok
                {
                    switch (part_op[x5])
                    {
                        case ("+"):
                            {
                                result = result + part_num[x5];
                                break;
                            }
                        case ("-"):
                            {
                                result = result - part_num[x5];
                                break;
                            }
                        case ("*"):
                            {
                                result = result * part_num[x5];
                                break;
                            }
                        case ("/"):
                            {
                                result = result / part_num[x5];
                                break;
                            }
                    }
                }
                return result.ToString();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                return "error";
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            output.Text = cal1(input.Text);
        }
    }
}
