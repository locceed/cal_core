using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace calculate_core
{
    class Cal
    {
        static public string divide(string input)//test
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
        }
        static public string test(string input)
        {
            if (input.First().ToString().IndexOfAny("+-".ToArray()) == -1)//统一格式
            {
                input = "+" + input;
            }
            int x1 = 0;//计数
            int opnum = 0;//符号个数
            while (x1 != -1)//符号个数
            {
                if (x1 != -1 && x1 != 0)
                {
                    if (input.Substring(x1 - 1).First().ToString() == "*" || input.Substring(x1 - 1).First().ToString() == "/")
                    {
                        x1 = input.IndexOfAny("+-".ToArray(), x1 + 1);
                    }
                    else
                    {
                        x1 = input.IndexOfAny("+-".ToArray(), x1 + 1);
                        opnum++;
                    }
                }
                else if (x1 == 0)
                {
                    x1 = input.IndexOfAny("+-".ToArray(), x1 + 1);
                    opnum++;
                }
            }
            x1 = 0;//计数器归零
            int[] oplocation = new int[opnum];
            string[] part = new string[opnum];
            int x2 = 0;//计数
            MessageBox.Show(opnum.ToString());
            while (x1 != -1)//符号位置
            {
                if (x1 != -1 && x1 != 0)
                {
                    if (input.Substring(x1 - 1).First().ToString() == "*" || input.Substring(x1 - 1).First().ToString() == "/")
                    {
                        x1 = input.IndexOfAny("+-".ToArray(), x1 + 1);
                    }
                    else
                    {
                        x1 = input.IndexOfAny("+-".ToArray(), x1 + 1);
                        oplocation[x2] = x1;
                        x2++;
                    }
                }
                else if (x1 == 0)
                {
                    x1 = input.IndexOfAny("+-".ToArray(), x1 + 1);
                    oplocation[x2] = x1;
                    x2++;
                }
            }
            string a = "";
            for (int for1 = 0; for1 <= oplocation.Length - 1; for1++)//打印
            {
                a = a + "<" + oplocation[for1].ToString() + ">";
            }
            return a;
        }
        static public string cal3(string input)//更新ing
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
            try
            {

            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                return "error";
            }
        }
    }
}
