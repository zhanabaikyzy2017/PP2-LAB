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
       public static bool IsPrime(int a)
        {
            bool asd = true;
            if(a == 1)
            {
                asd = false;
            }
            if (a == 2 && a == 3) 
            {
                asd = true;
            }
            for(int i = 3; i <= Math.Sqrt(a); i++)
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
            FileStream fr = new FileStream(@"C:\Users\HP\Documents\asd.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fr);
            string s = sr.ReadLine();
            string[] ss = s.Split(' ');
            
            int[] a = new int[ss.Length];

            for(int i = 0; i < ss.Length; i++)
            {
               
                a[i] = int.Parse(ss[i]);
            }
           
            var b = new List<int>();
            int m = -1;
            
            bool ok = false;
            for(int i = 0; i < a.Length; i++)
            {

                if (IsPrime(a[i]))
                {
                    if (ok == true)
                    {
                        m = a[i];
                        ok = false;
                    }
                    else
                    {
                        if(a[i] >= m)
                        {
                            m = a[i];
                        }
                    }

                    
                  //  b.Add(a[i]);
                }
            }
        
      

         // int m = b[0];

            /*for (int i = 0; i < b.Count; i++)
            {
                if (b[i] <= m)
                {
                    m = b[i];
                }
            }
            */
            

            sr.Close();
            fr.Close();
 
                FileStream fs = new FileStream(@"C:\Users\HP\Documents\Otvet.txt", FileMode.Open, FileAccess.Write);
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
