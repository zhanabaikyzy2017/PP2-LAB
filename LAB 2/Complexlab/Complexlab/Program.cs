using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complexlab
{
   public class Complex
    {
        int a, b;
        public Complex() { }
        public Complex(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public static Complex operator + (Complex c1, Complex c2)
        {
            Complex C = new Complex();
            C.a = c1.a + c2.a;
            C.b = c1.b + c2.b;
            return C;
        }
        public override string ToString()
        {
            return a + " " + b;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Complex c1 = new Complex(2, 3);
            Complex c2 = new Complex(4, 5);

            Complex result = c1 + c2;
            Console.WriteLine(result);



            Console.ReadKey();


        }
    }
}
