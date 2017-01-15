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
        private string result = "";
        public Cal2(string input)
        {
            try
            {
                if (input.First().ToString().IndexOfAny("+-".ToArray()) == -1)//统一格式
                {
                    input = "+" + input;
                }
                ArrayList primary = new ArrayList();
                int x = 0;
                decimal q = 0;
                primary.Add(" ");
                while (true)//加减分割
                {
                    x = input.Substring(1).IndexOfAny("+-".ToArray());
                    if (x == -1)
                    {
                        if (primary[primary.Count - 1].ToString().Last().ToString().IndexOfAny("*/".ToArray()) == 0)
                        {
                            primary[primary.Count - 1] = primary[primary.Count - 1] + input;
                        }
                        else
                        {
                            primary.Add(input);
                        }
                        break;
                    }
                    else
                    {
                        x = x + 1;
                        if (primary[primary.Count - 1].ToString().Last().ToString().IndexOfAny("*/".ToArray()) == 0)
                        {
                            primary[primary.Count - 1] = primary[primary.Count - 1] + input.Substring(0, x);
                        }
                        else
                        {
                            primary.Add(input.Substring(0, x));
                        }
                    }
                    input = input.Substring(x);
                }
                primary.RemoveAt(0);
                ArrayList secondary = new ArrayList();
                ArrayList results = new ArrayList();
                x = 0;//变量重用
                input = "";
                foreach (string a in primary)//分割内乘除运算
                {
                    input = "*" + a;//乘除分割
                    while (true)
                    {
                        x = input.Substring(1).IndexOfAny("*/".ToArray());
                        if (x == -1)
                        {
                            secondary.Add(input);
                            break;
                        }
                        else
                        {
                            x = x + 1;
                            secondary.Add(input.Substring(0, x));
                        }
                        input = input.Substring(x);
                    }
                    q = 1;
                    foreach (string b in secondary)//乘除运算
                    {
                        switch (b.First().ToString())
                        {
                            case "*":
                                {
                                    q = q * Convert.ToDecimal(b.Substring(1));
                                    break;
                                }
                            case "/":
                                {
                                    q = q / Convert.ToDecimal(b.Substring(1));
                                    break;
                                }
                        }
                    }
                    results.Add(q);
                    x = 0;//下一轮的初始化
                    input = "";
                    secondary.Clear();
                }
                q = 0;//变量重用
                foreach (decimal a in results)
                {
                    q = q + a;
                }
                result = q.ToString();
            }
            catch (Exception ex)
            {
                result = "error";
            }
        }
    }
}
