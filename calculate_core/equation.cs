using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculate_core
{
    class equation
    {
        static public string one_one(string input)
        {
            try
            {
                string positive = "+" + input.Substring(0, input.IndexOf("="));
                string negative = "+" + input.Substring(input.IndexOf("=") + 1);
                double linear = 0;
                double constant = 0;
                ArrayList positivelocation = new ArrayList();
                int temp = -1;
                int templast = 0;
                while (true)
                {
                    if (temp == positive.LastIndexOfAny("+-*/".ToArray()))
                    {
                        positivelocation.Add(positive.Substring(positive.LastIndexOfAny("+-*/".ToArray())));
                        positivelocation.RemoveAt(0);
                        break;
                    }
                    else
                    {
                        temp++;
                    }
                    temp = positive.IndexOfAny("+-*/".ToArray(), temp);
                    positivelocation.Add(positive.Substring(templast, temp - templast));
                    templast = temp;
                }
                ArrayList negativelocation = new ArrayList();
                temp = -1;
                templast = 0;
                while (true)
                {
                    if (temp == negative.LastIndexOfAny("+-*/".ToArray()))
                    {
                        negativelocation.Add(negative.Substring(negative.LastIndexOfAny("+-*/".ToArray())));
                        negativelocation.RemoveAt(0);
                        break;
                    }
                    else
                    {
                        temp++;
                    }
                    temp = negative.IndexOfAny("+-*/".ToArray(), temp);
                    negativelocation.Add(negative.Substring(templast, temp - templast));
                    templast = temp;
                }
                string temp1 = "";
                temp = 0;
                templast = 0;
                foreach (object o in positivelocation)
                {
                    temp1 = Convert.ToString(o);
                    if (temp1.Last().ToString().IndexOf("x") == -1)
                    {
                        constant = constant + Convert.ToDouble(temp1);
                    }
                    else
                    {
                        linear = linear + Convert.ToDouble(temp1.Replace("x", ""));
                    }
                }
                foreach (object o in negativelocation)
                {
                    temp1 = Convert.ToString(o);
                    if (temp1.Last().ToString().IndexOf("x") == -1)
                    {
                        constant = constant - Convert.ToDouble(temp1);
                    }
                    else
                    {
                        linear = linear - Convert.ToDouble(temp1.Replace("x", ""));
                    }
                }
                double result = -(constant / linear);
                return result.ToString();
            }
            catch (DivideByZeroException)
            {
                return "not a linear equation";
            }
            catch
            {
                return "error";
            }
        }
    }
}
