﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace calculate_core
{
    class other
    {
        //准备写括号。
        static public string bracket1(string input)//括号（ing）
        {

            if (input.First().ToString().IndexOfAny("+-".ToArray()) == -1)//统一格式
            {
                input = "+" + input;
            }

            return "";
        }
        static public string use1(string input)//单括号计算
        {
            string part_op = input.First().ToString();
            string part_cal = Cal.cal3(input.Substring(2, input.Length - 3));
            return part_op + part_cal;
        }
        static public string use2(string input)//分解多括号
        {
            if (input.IndexOf("(") == -1)
            {
                return (-1).ToString();
            }
            else
            {

            }
            return "";
        }
    }
}
