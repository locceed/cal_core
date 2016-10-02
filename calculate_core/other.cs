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
            return "";
        }
        static public string time(string input)
        {
            try
            {
                string result = (Convert.ToInt64(input) / (60 * 60 * 1000)).ToString("00") + ":" + ((Convert.ToInt64(input) % (60 * 60 * 1000)) / (60 * 1000)).ToString("00") + ":" + (((Convert.ToInt64(input) % (60 * 60 * 1000)) % (60 * 1000)) / 1000).ToString("00") + ":" + ((((Convert.ToInt64(input) % (60 * 60 * 1000)) % (60 * 1000)) % 1000) / 1).ToString("000");
                return result;
            }
            catch(Exception a)
            {
                return "error";
            }
        }
    }
}
