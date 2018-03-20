using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\Users\HP\Desktop\PP2-LAB\MIDTERM\Midterm2\input.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string s = sr.ReadLine();
            string[] ss = s.Split(' ');
            List<int> k = new List<int>();
            for(int i = 0; i < ss.Length; i++)
            {
                k.Add(int.Parse(ss[i]));
            }
            int min1 = k[0];
            for(int i = 0; i< k.Count; i++)
            {
                if(k[i] <= min1)
                {
                    min1 = k[i];
                }
            }
            Console.WriteLine(min1);
            int min2 = k[0];
            for(int i = 0; i< k.Count; i++)
            {
                if (k[i] == min1)
                    continue;
                if(k[i] < min2)
                {
                    min2 = k[i]; 
                }
            }
            Console.WriteLine(min2);
            Console.ReadKey();
        }
    }
}
