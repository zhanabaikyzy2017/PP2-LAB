using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static bool IsPrime(int a)
        {
            bool asd = true;
            if(a == 1)
            {
                asd = false;
            }
            if (a == 2)
            {
                asd = true;
            }
            for(int i = 2; i >= Math.Sqrt(a); i++)
            {
                if (a % i == 0)
                {
                    asd = false;
                    break;
                }
            }
            return asd;

        }
        static void f1()
        {
            FileStream fr = new FileStream(@"C:\Users\HP\Documents\asd.txt",FileMode.Open , FileAccess.Read);
            StreamReader sr = new StreamReader(fr);
            string s = sr.ReadLine();
            string[] ss;
            ss = s.Split(' ');
            
            int[] a = new int [ss.Length];
            for(int j = 0; j < ss.Length; j++)
            {
                if(IsPrime(int.Parse(ss[j])) == true)
                {
                   a[j] = int.Parse(ss[j]);
    
                }
            }
            int m = a[0];
            for(int i = 0; i <= a.Length; i++)
            {
                if(a[i] <= m)
                {
                    m = a[i];
                }
            }
            sr.Close();
            fr.Close();


             FileStream fs = new FileStream(@"C:\Users\HP\Documents\asd.txt", FileMode.Open, FileAccess.Write);
            StreamWriter ds = new StreamWriter(fs);
            ds.WriteLine(m);
            ds.Close();
            fs.Close();

            
        }
      
        static void Main(string[] args)
        {
            f1();


        }
    }
}
