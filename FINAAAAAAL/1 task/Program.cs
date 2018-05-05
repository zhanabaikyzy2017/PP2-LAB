using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_task
{
    class Program
    {
        static void Main(string[] args)
        {
            string s;
            int cnt = 0;
            s = Console.ReadLine();
            string[] ss;
            ss = s.Split(' ');
            Console.WriteLine(ss.Length.ToString());
            for(int i = 0; i < ss.Length; i++)
            {
                for(int j = 0; j < ss[i].Length; j++)
                {
                    if(ss[i][j] == ss[i][ss[i].Length - j - 1])
                    {
                        cnt++;

                    }
                    if(cnt == ss[i].Length)
                    {
                        Console.WriteLine(ss[i]);
                        cnt = 0;

                    }
                }
                
            }
            Console.ReadKey();
        }
    }
}
