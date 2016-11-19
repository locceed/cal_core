using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace calculate_core
{
    class other
    {
        static public string bracket1(string input)//括号
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
        static public string abs(string input)//绝对值(不包括计算)
        {
            try
            {
                int x = 0;
                int y = 0;
                while (true)
                {
                    x = input.IndexOf("|");
                    if (x == -1)
                    {
                        break;
                    }
                    if (input.Substring(0, x).Last().ToString().IndexOfAny("+-*/".ToArray()) == -1)
                    {
                        input = input.Substring(0, x) + "*" + input.Substring(x);
                    }
                    x = input.IndexOf("|");
                    y = input.Substring(x + 1).IndexOf("|") + 1;
                    input = input.Substring(0, x) + Math.Abs(Convert.ToDecimal(Cal.cal4(input.Substring(x + 1, y - 1)))) + input.Substring(x + y + 1);
                }
                return input;
            }
            catch
            {
                return "error";
            }
        }
    }
}
