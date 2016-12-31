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
        static public string one_one(string input)//一元一次方程
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
                    if (temp1.IndexOf("x") == -1)//
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
                    if (temp1.IndexOf("x") == -1)//
                    {
                        constant = constant - Convert.ToDouble(temp1);
                    }
                    else
                    {
                        linear = linear - Convert.ToDouble(temp1.Replace("x", ""));
                    }
                }
                if (linear == 0)
                {
                    return "not a linear equation";
                }
                double result = -(constant / linear);
                return "x=" + result.ToString();
            }
            catch
            {
                return "error";
            }
        }
        static public string one_two(string input)//一元二次方程
        {
            try
            {
                string positive = "+" + input.Substring(0, input.IndexOf("="));
                string negative = "+" + input.Substring(input.IndexOf("=") + 1);
                double quadratic = 0;
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
                    if (temp1.IndexOf("x^x") != -1)
                    {
                        quadratic = quadratic + Convert.ToDouble(temp1.Replace("x^x", ""));
                    }
                    else
                    {
                        if (temp1.IndexOf("x") != -1)
                        {
                            linear = linear + Convert.ToDouble(temp1.Replace("x", ""));
                        }
                        else
                        {
                            constant = constant + Convert.ToDouble(temp1);
                        }
                    }
                }
                foreach (object o in negativelocation)
                {
                    temp1 = Convert.ToString(o);
                    if (temp1.IndexOf("x^x") != -1)
                    {
                        quadratic = quadratic - Convert.ToDouble(temp1.Replace("x^x", ""));
                    }
                    else
                    {
                        if (temp1.IndexOf("x") != -1)
                        {
                            linear = linear - Convert.ToDouble(temp1.Replace("x", ""));
                        }
                        else
                        {
                            constant = constant - Convert.ToDouble(temp1);
                        }
                    }
                }
                if (linear == 0)
                {
                    return "not a linear equation";
                }
                if (Math.Pow(linear, 2) - 4 * quadratic * constant < 0) 
                {
                    return "this equation has no solution";
                }
                else
                {
                    double result1 = (-linear + Math.Sqrt(Math.Pow(linear, 2) - 4 * quadratic * constant)) / (2 * quadratic);
                    double result2 = (-linear - Math.Sqrt(Math.Pow(linear, 2) - 4 * quadratic * constant)) / (2 * quadratic);
                    return "x1=" + result1.ToString() + "    x2=" + result2.ToString();
                }
            }
            catch
            {
                return "error";
            }
        }
    }
}
