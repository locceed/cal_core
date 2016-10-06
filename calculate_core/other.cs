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
            if (input.First().ToString().IndexOfAny("+-".ToArray()) == -1)//统一格式
            {
                input = "+" + input;
            }
            string part_op = "";
            string part_cal = "";
            part_op = input.First().ToString();
            part_cal = Cal.cal3(input.Substring(2, input.Length - 3));
            if (part_cal.IndexOf("error") != -1)
            {
                return "error";
            }
            return part_op + part_cal;
        }
        static public string use2(string input)//分解多括号
        {
            string[] part = new string[Convert.ToInt32(Math.Pow(input.Length,2))];
            int x1 = 0 ;
            for (int for1 = 0; for1 <= input.Length; for1++) 
            {
                for (int for2 = input.Length; for2 >= 0; for2--) 
                {
                    try
                    {
                        part[x1]= use1(input.Substring(for1, for2));
                        x1++;
                    }
                    catch
                    {
                        x1++;
                    }
                }
            }
            return "";
        }
    }
}
