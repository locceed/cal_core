using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculate_core
{
    class timer
    {
        static public void timer1()
        {
            System.Timers.Timer timer1 = new System.Timers.Timer(1000);
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Elapsed);
            timer1.AutoReset = true;
            timer1.Enabled = true;
        }
        static public void timer1_Elapsed(object source, System.Timers.ElapsedEventArgs e)

        {

        }
    }
}
