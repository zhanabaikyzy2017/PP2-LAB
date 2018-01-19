using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle
{
    public class Circle
    {
        public int r;
        public double area;
        public double diameter;
        public double circ;

       public Circle()
        {
            r = 1;
            area = 0;
            diameter = 0;
            circ = 0;
        }
        public Circle(int a){
            r = a;
        }
        public  void FindArea()
        {
            area = Math.PI * r * r;
        }
        public void  FindDiameter()
        {
            diameter = 2 * r;
        }
        public void FindCircumference()
        {
            circ = 2 * Math.PI * r;
        }
        public override string ToString()
        {
            return area + " " + diameter + " " + circ;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Circle c = new Circle(int.Parse(Console.ReadLine()));
            c.FindArea();
            c.FindDiameter();
            c.FindCircumference();


            Console.WriteLine(c);



            Console.ReadKey();

        }
    }
}
