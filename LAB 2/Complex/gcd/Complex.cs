using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gcd
{
    public class Complex
    {

        public int x, y;
        public Complex() { }
        public Complex(int _x, int _y)
        {
            x = _x;
            y = _y;

        }
        public static int GCD(int n, int m)
        {
            int remainder;
            while(m != 0)
            {
                remainder = m % n;
                n = m;
                m = remainder;

            }
            return n;
        }

        public static int LCM(int n, int m)
        {
            return n * m/ GCD(m, n); 

        }
        public override string ToString()
        {
            return x + "/" + y;

        }
        public void Simplify()
        {
            int _a = x;
            int _b = y;

            while (_a > 0 && _b > 0)
            {
                if (_a > _b)
                {
                    _a = _a % _b;
                }
                else
                {
                    _b = _b % _a;
                }
            }
           
                int k = _a + _b;
                x /= k;
                y /= k;

             
        }
        public static Complex operator + (Complex a, Complex b)
        {
            int lcm = LCM(a.y, b.y);

            Complex c = new Complex(a.x * (lcm / b.y) + b.x * (lcm / a.y), lcm);
            c.Simplify();
            return c;
        }

    }
}

