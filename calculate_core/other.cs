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
                    input = input.Substring(0, input.Substring(0, input.IndexOf(")")).LastIndexOf("(")) + Cal.cal3(input.Substring(input.Substring(0, input.IndexOf(")")).LastIndexOf("(") + 1, input.IndexOf(")") - input.Substring(0, input.IndexOf(")")).LastIndexOf("(") - 1)) + input.Substring(input.IndexOf(")") + 1);
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
