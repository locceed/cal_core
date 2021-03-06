﻿using System;
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rannum"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="abs"></param>
        /// <returns></returns>
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
            try
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
            catch
            {
                ArrayList a = new ArrayList();
                return a;
            }
        }
        static public string abs2(string input)//绝对值2,完成
        {
            try
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
            catch
            {
                return "error";
            }
        }
        static public string abs3(string input)//完成，绝对值！
        {
            try
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
            catch
            {
                return "error";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bracket"></param>
        /// <returns></returns>
        static public string bracket1(string input)//括号(包括计算,所以待改进)
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
    }
}
