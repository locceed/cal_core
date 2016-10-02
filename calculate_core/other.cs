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
            int x2 = 0;
            int bracketnum = 0;
            while (true)//检测个数
            {
                if (x1 != -1)
                {
                    x1 = input.IndexOf("(", x1);
                }
                if (x2 != -1)
                {
                    x2 = input.IndexOf("(", x2);
                }
                if (x1 == -1 && x2 == -1)
                {
                    break;
                }
                else if (x1 != -1)
                {
                    x1++;
                    bracketnum++;
                }
                else if (x2 != -1) 
                {
                    x2++;
                    bracketnum--;
                }
            }
            string a = bracketnum.ToString();
            return a;
        }
    }
}
