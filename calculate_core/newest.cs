using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculate_core
{
    class newest
    {
        static public string cal4(string input)//使用ArrayList
        {
            try
            {
                if (input.First().ToString().IndexOfAny("+-".ToArray()) == -1)//统一格式
                {
                    input = "+" + input;
                }
                ArrayList primary = new ArrayList();
                int x = 0;
                decimal q = 0;
                primary.Add(" ");
                while (true)//加减分割
                {
                    x = input.Substring(1).IndexOfAny("+-".ToArray());
                    if (x == -1)
                    {
                        if (primary[primary.Count - 1].ToString().Last().ToString().IndexOfAny("*/".ToArray()) == 0)
                        {
                            primary[primary.Count - 1] = primary[primary.Count - 1] + input;
                        }
                        else
                        {
                            primary.Add(input);
                        }
                        break;
                    }
                    else
                    {
                        x = x + 1;
                        if (primary[primary.Count - 1].ToString().Last().ToString().IndexOfAny("*/".ToArray()) == 0)
                        {
                            primary[primary.Count - 1] = primary[primary.Count - 1] + input.Substring(0, x);
                        }
                        else
                        {
                            primary.Add(input.Substring(0, x));
                        }
                    }
                    input = input.Substring(x);
                }
                primary.RemoveAt(0);
                ArrayList secondary = new ArrayList();
                ArrayList results = new ArrayList();
                x = 0;//变量重用
                input = "";
                foreach (string a in primary)//分割内乘除运算
                {
                    input = "*" + a;//乘除分割
                    while (true)
                    {
                        x = input.Substring(1).IndexOfAny("*/".ToArray());
                        if (x == -1)
                        {
                            secondary.Add(input);
                            break;
                        }
                        else
                        {
                            x = x + 1;
                            secondary.Add(input.Substring(0, x));
                        }
                        input = input.Substring(x);
                    }
                    q = 1;
                    foreach (string b in secondary)//乘除运算
                    {
                        switch (b.First().ToString())
                        {
                            case "*":
                                {
                                    q = q * Convert.ToDecimal(b.Substring(1));
                                    break;
                                }
                            case "/":
                                {
                                    q = q / Convert.ToDecimal(b.Substring(1));
                                    break;
                                }
                        }
                    }
                    results.Add(q);
                    x = 0;//下一轮的初始化
                    input = "";
                    secondary.Clear();
                }
                q = 0;//变量重用
                foreach (decimal a in results)
                {
                    q = q + a;
                }
                return q.ToString();
            }
            catch (Exception ex)
            {
                return "error";
            }
        }
        static public string bracket1(string input)//括号(包括计算)
        {
            try
            {
                input = "(" + input + ")";
                while (true)
                {
                    if (input.IndexOf(")") == -1)
                    {
                        break;
                    }
                    input = input.Substring(0, input.Substring(0, input.IndexOf(")")).LastIndexOf("(")) + Cal.cal4(input.Substring(input.Substring(0, input.IndexOf(")")).LastIndexOf("(") + 1, input.IndexOf(")") - input.Substring(0, input.IndexOf(")")).LastIndexOf("(") - 1)) + input.Substring(input.IndexOf(")") + 1);
                }
                return input;
            }
            catch (Exception e)
            {
                return "error";
            }
        }
        static public string abs3(string input)//完成！
        {
            while (true)
            {
                ArrayList location = new ArrayList();
                int lo_temp = -1;
                while (true)
                {
                    if (lo_temp == input.LastIndexOf("|"))
                    {
                        break;
                    }
                    else
                    {
                        lo_temp++;
                    }
                    lo_temp = input.IndexOf("|", lo_temp);
                    location.Add(lo_temp);
                }
                lo_temp = 0;//重用
                while (lo_temp <= location.Count - 1)
                {
                    if (input.Substring(0, Convert.ToInt32(location[lo_temp + 1])).Last().ToString().IndexOfAny("+-*/".ToArray()) == -1)
                    {
                        input = input.Substring(0, Convert.ToInt32(location[lo_temp])) + Cal.cal4(input.Substring(Convert.ToInt32(location[lo_temp]) + 1, Convert.ToInt32(location[lo_temp + 1]) - Convert.ToInt32(location[lo_temp]) - 1)) + input.Substring(Convert.ToInt32(location[lo_temp + 1]) + 1);
                        break;
                    }
                    else
                    {
                        lo_temp++;
                    }
                    if (lo_temp > location.Count - 1)
                    {
                        return "error";
                    }
                }
                if (input.IndexOf("|") == -1)
                {
                    break;
                }
            }
            return input;
        }
        static public string rannum(int digit)//create a random number
        {
            try
            {
                Random ran = new Random();
                string result = "";
                while (digit >= 1)
                {
                    result = result + ran.Next(0, 10);
                    digit--;
                }
                return result;
            }
            catch
            {
                return "error";
            }
        }
        static public string rannum(int digit, int times)//create a random formula
        {
            try
            {
                Random ran = new Random();
                string result = "";
                int digit_copy;
                while (times >= 1)
                {
                    switch (ran.Next(0, 3))
                    {
                        case 0:
                            {
                                result = result + "+";
                                break;
                            }
                        case 1:
                            {
                                result = result + "-";
                                break;
                            }
                        case 2:
                            {
                                result = result + "*";
                                break;
                            }
                        case 3:
                            {
                                result = result + "/";
                                break;
                            }
                    }
                    digit_copy = digit;
                    while (digit_copy >= 1)
                    {
                        result = result + ran.Next(0, 10);
                        digit_copy--;
                    }
                    times--;
                }
                return result.Substring(1);
            }
            catch
            {
                return "error";
            }
        }
    }
}
