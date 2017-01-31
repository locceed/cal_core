using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculate_core
{
    class Cal2
    {
        bool not_a_formula = false;
        string formula = "";
        string result = "";
        ArrayList level_1 = new ArrayList();
        ArrayList level_2 = new ArrayList();

        public Cal2(string input)//构造函数
        {
            formula = input;
            if (formula.First().ToString().IndexOfAny("*/".ToArray()) != -1)//规范格式
            {
                formula = "1*" + formula;
            }
            else if (formula.First().ToString().IndexOfAny("1234567890".ToArray()) != -1)
            {
                formula = "+" + formula;
            }
            if (formula.IndexOfAny("+-*/1234567890".ToArray()) != -1)//意料外的字符
            {
                not_a_formula = true;
            }
        }
        private string add(string num1, string num2)
        {
            return (Convert.ToDouble(num1) + Convert.ToDouble(num2)).ToString();
        }
        private string minus(string num1, string num2)
        {
            return (Convert.ToDouble(num1) - Convert.ToDouble(num2)).ToString();
        }
        private string Multiply(string num1, string num2)
        {
            return (Convert.ToDouble(num1) * Convert.ToDouble(num2)).ToString();
        }
        private string divide(string num1, string num2)
        {
            if (num2 == "0")
            {
                return double.PositiveInfinity.ToString();
            }
            return (Convert.ToDouble(num1) / Convert.ToDouble(num2)).ToString();
        }
        private void lvl1()//"+","-";except"*+""*-""/+""/-"
        {
            bool condition1 = true;
            foreach (char each in formula.ToArray())
            {
                if (each.ToString() == "+" && condition1 == true)
                {
                    level_1.Add(each);
                    condition1 = true;
                }
                else if (each.ToString() == "-" && condition1 == true)
                {
                    level_1.Add(each);
                    condition1 = true;
                }
                else
                {
                    condition1 = true;
                    if (each.ToString().IndexOfAny("*/".ToArray()) != -1)
                    {
                        condition1 = false;
                    }
                    level_1[level_1.Count - 1] += each.ToString();
                }
            }
        }
        private void lvl2()//"*""/"
        {
            foreach (object each1 in level_1)
            {
                ArrayList temp = new ArrayList();
                foreach (char each in each1.ToString().ToArray())
                {
                    if (each.ToString() == "+")
                    {
                        temp.Add("");
                    }
                    else if (each.ToString() == "-")
                    {
                        temp.Add("");
                    }
                    if (each.ToString() == "*")
                    {
                        temp.Add(each);
                    }
                    else if (each.ToString() == "/")
                    {
                        temp.Add(each);
                    }
                    else
                    {
                        temp[temp.Count - 1] += each.ToString();
                    }
                }
                level_2.Add(temp);
            }
        }
        private void cal()
        {
            string temp = "0";
            foreach (ArrayList each1 in level_2)
            {
                string temp1 = "0";
                foreach (object each in each1)
                {
                    switch (each.ToString().First().ToString())
                    {
                        case "+":
                            {
                                temp1 = add(temp1.ToString(), each.ToString().Substring(1));
                                break;
                            }
                        case "-":
                            {
                                temp1 = minus(temp1.ToString(), each.ToString().Substring(1));
                                break;
                            }
                        case "*":
                            {
                                temp1 = Multiply(temp1.ToString(), each.ToString().Substring(1));
                                break;
                            }
                        case "/":
                            {
                                temp1 = divide(temp1.ToString(), each.ToString().Substring(1));
                                break;
                            }
                    }
                }
                if (temp1.First().ToString() != "-")
                {
                    temp1 = "+" + temp1;
                }
                switch (temp1.ToString().First().ToString())
                {
                    case "+":
                        {
                            temp = add(temp.ToString(), temp1.ToString().Substring(1));
                            break;
                        }
                    case "-":
                        {
                            temp = minus(temp.ToString(), temp1.ToString().Substring(1));
                            break;
                        }
                }
            }
            result = temp;
        }
        private void start()
        {
            lvl1();
            lvl2();
            cal();
        }
        public string getresult()
        {
            start();
            return result;
        }
    }
}
