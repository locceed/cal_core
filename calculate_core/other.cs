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
        static public string abs1(string input)//绝对值（有缺陷）
        {
            try
            {
                while (true)
                {
                    if (input.IndexOf("|~") == -1)
                    {
                        break;
                    }
                    input = input.Substring(0, input.Substring(0, input.IndexOf("|~")).LastIndexOf("|")) + Math.Abs(Convert.ToDouble(Cal.cal4(input.Substring(input.Substring(0, input.IndexOf("|~")).LastIndexOf("|") + 1, input.IndexOf("|~") - input.Substring(0, input.IndexOf("|~")).LastIndexOf("|") - 1)))) + input.Substring(input.IndexOf("|~") + 2);
                }
                return input;
            }
            catch (Exception e)
            {
                return "error";
            }
        }
        static public string abs2(string input)
        {

            return "";
        }
    }
}
