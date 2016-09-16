using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculate_core
{
    class Cal
    {
        public void divide()
        {

        }
        public string docal(string num1, string op, string num2)
        {
            try
            {
                string result = "";
                switch (op)
                {
                    case "+":
                        {
                            result = (Convert.ToDouble(num1) + Convert.ToDouble(num2)).ToString();
                            break;
                        }
                    case "-":
                        {
                            result = (Convert.ToDouble(num1) - Convert.ToDouble(num2)).ToString();
                            break;
                        }
                    case "*":
                        {
                            result = (Convert.ToDouble(num1) * Convert.ToDouble(num2)).ToString();
                            break;
                        }
                    case "/":
                        {
                            result = (Convert.ToDouble(num1) / Convert.ToDouble(num2)).ToString();
                            break;
                        }
                }
                return result;
            }
            catch(Exception a)
            {
                return a.ToString();
            }
        }
    }
}
