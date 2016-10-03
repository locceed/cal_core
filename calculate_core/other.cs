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
        static public string bracket1(string input)//括号（未开工）
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
        }//ok
        static public void timer()
        {
            System.Timers.Timer timer1 = new System.Timers.Timer(1000);
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Elapsed);
            timer1.AutoReset = true;
            timer1.Enabled = true;
        }
        static public void timer1_Elapsed(object source, System.Timers.ElapsedEventArgs e)

        {
            MainWindow.a += 1;
        }
    }
}
