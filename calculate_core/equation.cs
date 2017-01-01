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
                string positive = input.Substring(0, input.IndexOf("="));
                string negative = input.Substring(input.IndexOf("=") + 1);
                if (positive.First().ToString().IndexOfAny("+-*/".ToArray()) == -1) 
                {
                    positive = "+" + positive;
                }
                if (negative.First().ToString().IndexOfAny("+-*/".ToArray()) == -1)
                {
                    negative = "+" + negative;
                }
                positive = positive.Replace("+x", "+1x");
                positive = positive.Replace("-x", "-1x");
                negative = negative.Replace("+x", "+1x");
                negative = negative.Replace("-x", "-1x");
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
                    if (temp1.IndexOf("x") == -1)
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
                    if (temp1.IndexOf("x") == -1)
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
                string positive = input.Substring(0, input.IndexOf("="));
                string negative = input.Substring(input.IndexOf("=") + 1);
                if (positive.First().ToString().IndexOfAny("+-*/".ToArray()) == -1)
                {
                    positive = "+" + positive;
                }
                if (negative.First().ToString().IndexOfAny("+-*/".ToArray()) == -1)
                {
                    negative = "+" + negative;
                }
                positive = positive.Replace("+x^x", "+1x^x");
                positive = positive.Replace("-x^x", "-1x^x");
                negative = negative.Replace("+x^x", "+1x^x");
                negative = negative.Replace("-x^x", "-1x^x");
                positive = positive.Replace("+x", "+1x");
                positive = positive.Replace("-x", "-1x");
                negative = negative.Replace("+x", "+1x");
                negative = negative.Replace("-x", "-1x");
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
                    return "not a quadratic equation";
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
        static public string two_one(string input1,string input2)//二元一次方程
        {
            try
            {
                string positive1 = input1.Substring(0, input1.IndexOf("="));
                string negative1 = input1.Substring(input1.IndexOf("=") + 1);
                if (positive1.First().ToString().IndexOfAny("+-*/".ToArray()) == -1)
                {
                    positive1 = "+" + positive1;
                }
                if (negative1.First().ToString().IndexOfAny("+-*/".ToArray()) == -1)
                {
                    negative1 = "+" + negative1;
                }
                positive1 = positive1.Replace("+x", "+1x");
                positive1 = positive1.Replace("-x", "-1x");
                positive1 = positive1.Replace("+y", "+1y");
                positive1 = positive1.Replace("-y", "-1y");
                negative1 = negative1.Replace("+x", "+1x");
                negative1 = negative1.Replace("-x", "-1x");
                negative1 = negative1.Replace("+y", "+1y");
                negative1 = negative1.Replace("-y", "-1y");
                double linear1x = 0;
                double linear1y = 0;
                double constant1 = 0;
                ArrayList positivelocation1 = new ArrayList();
                int temp = -1;
                int templast = 0;
                while (true)
                {
                    if (temp == positive1.LastIndexOfAny("+-*/".ToArray()))
                    {
                        positivelocation1.Add(positive1.Substring(positive1.LastIndexOfAny("+-*/".ToArray())));
                        positivelocation1.RemoveAt(0);
                        break;
                    }
                    else
                    {
                        temp++;
                    }
                    temp = positive1.IndexOfAny("+-*/".ToArray(), temp);
                    positivelocation1.Add(positive1.Substring(templast, temp - templast));
                    templast = temp;
                }
                ArrayList negativelocation1 = new ArrayList();
                temp = -1;
                templast = 0;
                while (true)
                {
                    if (temp == negative1.LastIndexOfAny("+-*/".ToArray()))
                    {
                        negativelocation1.Add(negative1.Substring(negative1.LastIndexOfAny("+-*/".ToArray())));
                        negativelocation1.RemoveAt(0);
                        break;
                    }
                    else
                    {
                        temp++;
                    }
                    temp = negative1.IndexOfAny("+-*/".ToArray(), temp);
                    negativelocation1.Add(negative1.Substring(templast, temp - templast));
                    templast = temp;
                }
                string positive2 = input2.Substring(0, input2.IndexOf("="));
                string negative2 = input2.Substring(input2.IndexOf("=") + 1);
                if (positive2.First().ToString().IndexOfAny("+-*/".ToArray()) == -1)
                {
                    positive2 = "+" + positive2;
                }
                if (negative2.First().ToString().IndexOfAny("+-*/".ToArray()) == -1)
                {
                    negative2 = "+" + negative2;
                }
                positive2 = positive2.Replace("+x", "+1x");
                positive2 = positive2.Replace("-x", "-1x");
                positive2 = positive2.Replace("+y", "+1y");
                positive2 = positive2.Replace("-y", "-1y");
                negative2 = negative2.Replace("+x", "+1x");
                negative2 = negative2.Replace("-x", "-1x");
                negative2 = negative2.Replace("+y", "+1y");
                negative2 = negative2.Replace("-y", "-1y");
                double linear2x = 0;
                double linear2y = 0;
                double constant2 = 0;
                ArrayList positivelocation2 = new ArrayList();
                temp = -1;
                templast = 0;
                while (true)
                {
                    if (temp == positive2.LastIndexOfAny("+-*/".ToArray()))
                    {
                        positivelocation2.Add(positive2.Substring(positive2.LastIndexOfAny("+-*/".ToArray())));
                        positivelocation2.RemoveAt(0);
                        break;
                    }
                    else
                    {
                        temp++;
                    }
                    temp = positive2.IndexOfAny("+-*/".ToArray(), temp);
                    positivelocation2.Add(positive2.Substring(templast, temp - templast));
                    templast = temp;
                }
                ArrayList negativelocation2 = new ArrayList();
                temp = -1;
                templast = 0;
                while (true)
                {
                    if (temp == negative2.LastIndexOfAny("+-*/".ToArray()))
                    {
                        negativelocation2.Add(negative2.Substring(negative2.LastIndexOfAny("+-*/".ToArray())));
                        negativelocation2.RemoveAt(0);
                        break;
                    }
                    else
                    {
                        temp++;
                    }
                    temp = negative2.IndexOfAny("+-*/".ToArray(), temp);
                    negativelocation2.Add(negative2.Substring(templast, temp - templast));
                    templast = temp;
                }
                string temp1 = "";
                temp = 0;
                templast = 0;
                foreach (object o in positivelocation1)
                {
                    temp1 = Convert.ToString(o);
                    if (temp1.IndexOf("x") != -1)
                    {
                        linear1x = linear1x + Convert.ToDouble(temp1.Replace("x", ""));
                    }
                    else
                    {
                        if (temp1.IndexOf("y") != -1)
                        {
                            linear1y = linear1y + Convert.ToDouble(temp1.Replace("y", ""));
                        }
                        else
                        {
                            constant1 = constant1 + Convert.ToDouble(temp1);
                        }
                    }
                }
                foreach (object o in negativelocation1)
                {
                    temp1 = Convert.ToString(o);
                    if (temp1.IndexOf("x") != -1)
                    {
                        linear1x = linear1x - Convert.ToDouble(temp1.Replace("x", ""));
                    }
                    else
                    {
                        if (temp1.IndexOf("y") != -1)
                        {
                            linear1y = linear1y - Convert.ToDouble(temp1.Replace("y", ""));
                        }
                        else
                        {
                            constant1 = constant1 - Convert.ToDouble(temp1);
                        }
                    }
                }
                temp1 = "";
                temp = 0;
                templast = 0;
                foreach (object o in positivelocation2)
                {
                    temp1 = Convert.ToString(o);
                    if (temp1.IndexOf("x") != -1)
                    {
                        linear2x = linear2x + Convert.ToDouble(temp1.Replace("x", ""));
                    }
                    else
                    {
                        if (temp1.IndexOf("y") != -1)
                        {
                            linear2y = linear2y + Convert.ToDouble(temp1.Replace("y", ""));
                        }
                        else
                        {
                            constant2 = constant2 + Convert.ToDouble(temp1);
                        }
                    }
                }
                foreach (object o in negativelocation2)
                {
                    temp1 = Convert.ToString(o);
                    if (temp1.IndexOf("x") != -1)
                    {
                        linear2x = linear2x - Convert.ToDouble(temp1.Replace("x", ""));
                    }
                    else
                    {
                        if (temp1.IndexOf("y") != -1)
                        {
                            linear2y = linear2y - Convert.ToDouble(temp1.Replace("y", ""));
                        }
                        else
                        {
                            constant2 = constant2 - Convert.ToDouble(temp1);
                        }
                    }
                }
                double resulty = (-(constant2) - (linear2x / linear1x * (-constant1))) / (linear2y - (linear2x / linear1x * linear1y));
                double resultx = (-(constant1) - (linear1y * resulty)) / (linear1x);
                return "x=" + resultx.ToString() + "    y=" + resulty.ToString();
            }
            catch
            {
                return "error";
            }
        }
    }
}
