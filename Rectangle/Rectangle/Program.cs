using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangle
{
    class rectangle
    {
       public  int w;
       public int h;
        public rectangle()
        {
            w = 1;
            h = 1;

        }
        public rectangle(int w, int h)
        {
            this.w = w;
            this.h = h;
        }
        public override string ToString()
        {
            return w + " " + h;
        }
        public static int FindArea (int a, int b)
        {
            return a*b; 

        }

        public static int FindPerimeter(int a, int b)
        {
            return 2 * (a + b);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            rectangle r = new rectangle();
            int ww = int.Parse(Console.ReadLine());
            r.w = ww;
            int hh = int.Parse(Console.ReadLine());
            r.h = hh;
            Console.WriteLine(r);
            Console.WriteLine(rectangle.FindArea(ww, hh));
            Console.WriteLine(rectangle.FindPerimeter(ww, hh));

            Console.ReadKey();






        }
    }
}
