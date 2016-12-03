using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculate_core
{
    class timer
    {
        static public TimeSpan t1()
        {
            bool isend = false;
            TimeSpan a;
            DateTime past = DateTime.Now;
            if (isend==false)
            {
                a = TimeSpan.Zero;
                past = DateTime.Now;
                isend = true;
            }
            else
            {
                a = DateTime.Now - past;
                isend = false;
            }
            return a;
        }
    }
}
