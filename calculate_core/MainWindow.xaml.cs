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
        private string cal2(string input)//运算法则更新
        {
            try
            {
                if (input.First().ToString().IndexOfAny("+-".ToArray()) == -1)//统一格式
                {
                    input = "+" + input;
                }
                int x1 = 0;//计数
                int opnum = 0;//符号个数
                while (x1 != -1)//符号个数
                {
                    x1 = input.IndexOfAny("+-".ToArray(), x1 + 1);
                    opnum++;
                }
                x1 = 0;//计数器归零
                int[] oplocation = new int[opnum];
                string[] part = new string[opnum];
                for (int for1 = 0; for1 <= part.Length - 1; for1++)//符号位置
                {
                    x1 = input.IndexOfAny("+-".ToArray(), x1);
                    oplocation[for1] = x1;
                    x1++;
                }
                x1 = 0;//计数器归零
                for (int for1 = 0; for1 <= part.Length - 1; for1++)//加减分割
                {
                    if (for1 >= oplocation.Length - 1)
                    {
                        part[for1] = input.Substring(oplocation[for1]);
                    }
                    else
                    {
                        part[for1] = input.Substring(oplocation[for1], oplocation[for1 + 1] - oplocation[for1]);
                    }
                }
                string[] part_handled = new string[opnum];
                ///////////////////////////////////////////////////////////////
                for (int for1 = 0; for1 <= part.Length - 1; for1++)
                {
                    if (part[for1].IndexOfAny("*/".ToArray()) == -1)
                    {
                        part_handled[for1] = part[for1];
                    }
                    else
                    {
                        int part_opnum = 0;
                        while (x1 != -1)//符号个数(部分)
                        {
                            x1 = part[for1].IndexOfAny("*/".ToArray(), x1 + 1);
                            part_opnum++;
                        }
                        x1 = 0;//计数器归零
                        int[] part_oplocation = new int[part_opnum];
                        string[] part_part = new string[part_opnum];
                        for (int for2 = 1; for2 <= part_oplocation.Length - 1; for2++)//符号位置(部分)
                        {
                            x1 = part[for1].IndexOfAny("*/".ToArray(), x1 + 1);
                            if (x1 != -1)
                            {
                                part_oplocation[for2] = x1;
                            }
                        }
                        x1 = 0;//计数器归零
                        for (int for2 = 0; for2 <= part_oplocation.Length - 1; for2++)//四则分割(部分)
                        {
                            if (for2 == part_oplocation.Length - 1)
                            {
                                part_part[for2] = part[for1].Substring(part_oplocation[for2]);
                            }
                            else
                            {
                                part_part[for2] = part[for1].Substring(part_oplocation[for2], part_oplocation[for2 + 1] - part_oplocation[for2]);
                            }
                        }
                        string[] part_part_op = new string[part_opnum];
                        string[] part_part_num = new string[part_opnum];
                        for (int for2 = 0; for2 <= part_part.Length - 1; for2++)//数符分割（部分）
                        {
                            part_part_op[for2] = part_part[for2].First().ToString();
                            part_part_num[for2] = part_part[for2].Substring(1);
                        }
                        double part_result = Convert.ToDouble(part_part_num[0]);
                        for (int for2 = 0; for2 <= part_part.Length - 1; for2++)//计算（部分）
                        {
                            switch (part_part_op[for2])
                            {
                                case ("*"):
                                    {
                                        part_result = part_result * Convert.ToDouble(part_part_num[for2]);
                                        break;
                                    }
                                case ("/"):
                                    {
                                        part_result = part_result / Convert.ToDouble(part_part_num[for2]);
                                        break;
                                    }
                            }
                            part_handled[for1] = part[for1].First().ToString() + part_result.ToString();
                        }
                    }
                }
                ////////////////////////////////////////////////////////////////////////////////
                string[] part_op = new string[part_handled.Length];
                string[] part_num = new string[part_handled.Length];
                for (int for1 = 0; for1 <= part_handled.Length - 1; for1++)//运算前分割
                {
                    part_op[for1] = part_handled[for1].First().ToString();
                    part_num[for1] = part_handled[for1].Substring(1);
                }
                double result = 0;
                for (int for1 = 0; for1 <= part_handled.Length - 1; for1++)
                {
                    switch (part_op[for1])
                    {
                        case ("+"):
                            {
                                result = result + Convert.ToDouble(part_num[for1]);
                                break;
                            }
                        case ("-"):
                            {
                                result = result - Convert.ToDouble(part_num[for1]);
                                break;
                            }
                    }
                }
                return result.ToString();
                /////////////////////////////////////////////////////////////////////////////////
                /*
                output.Text = "";
                for (int xx = 0; xx <= part_handled.Length - 1; xx++)
                {
                    output.Text = result.ToString();
                    //output.Text = output.Text + "<" + part_num[xx].ToString() + ">";
                }
                */
                //这是测试用的。
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                return "error";
            }
        }
        private string cal2_forward(string input)//关于cal2的更新
        {
            string result = "";
            int x1 = 0;
            string rescache = "";
            while (x1 != -1)
            {
                x1 = 0;
                if (input == "" == true) 
                {
                    break;
                }
                if (input.IndexOf("*-", x1 + 1) != -1)
                {
                    x1 = input.IndexOf("*-", x1 + 1);
                }
                else if (input.IndexOf("/-", x1 + 1) != -1)
                {
                    x1 = input.IndexOf("/-", x1 + 1);
                }
                else
                {
                    break;
                }
                rescache = input.Substring(0, x1 + 1);//分割
                input = input.Substring(x1 + 2);//分割
                if (rescache.IndexOfAny("+-".ToArray()) != -1)
                {
                    if (rescache.Last() == Convert.ToChar("+"))
                    {
                        rescache = rescache.Substring(0, rescache.LastIndexOf("+")) + "-" + rescache.Substring(rescache.LastIndexOf("+") + 1);
                    }
                    else if (rescache.Last() == Convert.ToChar("-"))
                    {
                        rescache = rescache.Substring(0, rescache.LastIndexOf("-")) + "+" + rescache.Substring(rescache.LastIndexOf("-") + 1);
                    }
                }
                result = result + rescache;
            }
            result = result + input;
            return result;
        }
        private void input_KeyUp(object sender, KeyEventArgs e)
        {
            //output.Text = cal2_forward(input.Text);
            //a(input.Text);
        }
        private void a(string input)
        {
            /*output.Text = "";
            output.Text = output.Text + input.IndexOf("5").ToString() + "\r\n";
            output.Text = output.Text + input.IndexOf("567").ToString() + "\r\n";*/
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            input.Text = cal2_forward(input.Text);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            input.Text = output.Text;
        }
    }
}
