using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculate_core
{
    class num
    {
        private double basenum = 0;//底数
        private double exponentnum = 1;//指数
        public num(double base_num, double exponent_num)
        {
            basenum = base_num;
            exponentnum = exponent_num;
        }
        public num(double base_num)
        {
            basenum = base_num;
            exponentnum = 1;
        }
        public num(num num1)
        {
            basenum = num1.getvalue();
            exponentnum = 1;
        }
        public void rewrite(double base_num, double exponent_num)
        {
            basenum = base_num;
            exponentnum = exponent_num;
        }
        public void rewrite(double base_num)
        {
            basenum = base_num;
            exponentnum = 1;
        }
        public double getvalue()
        {
            return Math.Pow(basenum, exponentnum);
        }
        public double getexponent()
        {
            return exponentnum;
        }
        override public string ToString()
        {
            return getvalue().ToString();
        }
        static public num operator +(num a, num b)
        {
            return new num(a.getvalue() + b.getvalue());
        }
        static public num operator -(num a, num b)
        {
            return new num(a.getvalue() - b.getvalue());
        }
        static public num operator *(num a, num b)
        {
            return new num(a.getvalue() * b.getvalue());
        }
        static public num operator /(num a, num b)
        {
            return new num(a.getvalue() / b.getvalue());
        }
    }
}
