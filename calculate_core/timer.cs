using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculate_core
{
    class timer
    {
        bool isend = false;
        TimeSpan a;
        DateTime past;
        public void on()
        {
            if (isend == false)
            {
                past = DateTime.Now;
                isend = true;
            }
        }
        public TimeSpan off()
        {
            if (isend == true)
            {
                isend = false;
                return DateTime.Now - past;
            }
            else
            {
                return TimeSpan.Zero;
            }
        }
        public TimeSpan get()
        {
            if (isend == true)
            { 
                return DateTime.Now - past;
            }
            else
            {
                return TimeSpan.Zero;
            }
        }
    }
}
