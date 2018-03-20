using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            int n = int.Parse(s);
            int k = 1;
            for(int i = 0; i < n; i++)
            {
                k *= 2;
            }
            Console.WriteLine(k);
            Console.ReadKey();
        }
    }
}
