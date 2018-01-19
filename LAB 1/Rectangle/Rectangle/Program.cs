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
        public int area;
        public int perimeter;
        public rectangle()
        {
            w = 1;
            h = 1;
            area = 0;
            perimeter = 0;


        }
        public rectangle(int w, int h)
        {
            this.w = w;
            this.h = h;
        }
        public override string ToString()
        {
            return w + " " + h + " " + area + " " + perimeter;
        }
       
        public void Findarea()
        {
            area = w * h;

        }


        public void FindPerimeter()
        {
            perimeter = 2 * (w + h);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
          
            rectangle d = new rectangle(2,3);
            d.Findarea();
            d.FindPerimeter();
            Console.WriteLine(d);


            Console.ReadKey();






        }
    }
}
