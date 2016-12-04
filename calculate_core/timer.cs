using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculate_core
{
    class timer
    {       bool isend = false;
            TimeSpan a;
            DateTime past = DateTime.Now;
        public TimeSpan t1()
        {
            
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
        public TimeSpan on()
        {
            if (isend == false)
            {
                t1();
                isend = true;
                return TimeSpan.Zero;
            }
            else
            {
                return TimeSpan.Zero;
            }
            
        }
        public TimeSpan off()
        {
            if (isend == true)
            {
                t1();
                isend = false;
                return a;
            }
            else
            {
                return TimeSpan.Zero;
            }
        }
    }
}
