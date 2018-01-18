using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void f1()
        {
            FileStream fs = new FileStream(@"C:\Users\HP\Documents\asd.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string  s;
            string[] ss;
            s = sr.ReadLine();
            ss = s.Split(' ');
            int m = int.Parse(ss[0]);
            int mi = int.Parse(ss[0]);
            for(int i = 0; i < ss.Length; i++)
            {
                if(int.Parse(ss[i]) >= m)
                {
                    m = int.Parse(ss[i]);
                }
                if (int.Parse(ss[i]) <= mi)
                {
                    mi = int.Parse(ss[i]);
                }

            }

            Console.WriteLine(m + " " + mi);

        }
        static void Main(string[] args)
        {
            f1();
            Console.ReadKey();

        }
    }
}
