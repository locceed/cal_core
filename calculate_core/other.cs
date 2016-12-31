using System;
using System.Collections;
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
        static private ArrayList finder(string input, string find)//绝对值2，辅助方法
        {
            ArrayList list = new ArrayList();
            int x = input.IndexOf(find);
            if (x == -1)
            {
                list.Add(-1);
                return list;
            }
            list.Add(x);
            int xmax = input.LastIndexOf(find);
            while (true)
            {
                x = input.IndexOf(find, x + 1);
                list.Add(x);
                if (x == xmax || x == -1)
                {
                    break;
                }
            }
            return list;
        }
        static public string abs2(string input)//绝对值2,完成
        {
            int x = 0;
            string a = "";
            ArrayList location;
            while (true)
            {
                location = finder(input, "|");
                x = 0;
                if (Convert.ToInt32(location[location.Count - 1]) == -1) 
                {
                    break;
                }
                while (true)
                {
                    a = input.Substring(0, Convert.ToInt32(location[x + 1]));
                    if (a.Last().ToString().IndexOfAny("+-*/".ToArray()) == -1)
                    {
                        input = input.Substring(0, Convert.ToInt32(location[x])) + Cal.cal4(input.Substring(Convert.ToInt32(location[x]) + 1, Convert.ToInt32(location[x + 1]) - Convert.ToInt32(location[x]) - 1)) + input.Substring(Convert.ToInt32(location[x + 1]) + 1);
                        break;
                    }
                    else
                    {
                        x++;
                        if (x >= location.Count - 1) 
                        {
                            return "error";
                        }
                    }
                }
            }
            if (input.IndexOf("|") == -1)
            {
                return input;
            }
            else
            {
                return "error";
            }
        }
        static public string abs3(string input)
        {

            return "";
        }
    }
}
