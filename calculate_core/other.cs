using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculate_core
{
    class other
    {
        //准备写括号。
        static public string bracket1(string input)//括号
        {
            int x1 = 0;
            int bracketnum = 0;
            while (true)
            {
                x1 = input.IndexOfAny("()".ToArray(), x1);
                if (x1 == -1)
                {
                    break;
                }
                else
                {
                    x1++;
                    bracketnum++;
                }
            }
            string a = bracketnum.ToString();
            return a;
        }
    }
}
