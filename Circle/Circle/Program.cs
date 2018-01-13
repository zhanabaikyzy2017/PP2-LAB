using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle
{
    public class circle
    {
        public int r;

       public circle()
        {
            r = 1;
        }
        public static double FindArea(int a)
        {
           double p = 3.14;
            return p * a * a;
             
        }
        public static int FindDiameter(int a)
        {
         
            return 2 * a;
        }
        public static double FindCircumference(int a)
        {
            double p = 3.14;
            return 2 * p * a;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            circle c = new circle();
            c.r = int.Parse(Console.ReadLine());
            Console.WriteLine(circle.FindArea(c.r));
            Console.WriteLine(circle.FindDiameter(c.r));
            Console.WriteLine(circle.FindCircumference(c.r));

            Console.ReadKey();

        }
    }
}
