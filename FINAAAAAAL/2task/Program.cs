using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2task
{
    class Program
    {
        static void Main(string[] args)
        {
           
            DirectoryInfo dirs = new DirectoryInfo(@"Files");
            FileInfo[] files = dirs.GetFiles();
            bool ok = false;
            foreach(FileInfo f in files)
            {
                string path = f.FullName;
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                string s = sr.ReadLine();
                string [] ss = s.Split(' ');

                for(int i = 0; i < ss.Length; i++)
                {
                    if(int.Parse(ss[i]) == 1 || int.Parse(ss[i]) == 2)
                    {
                        ok = true;
                    }
                    for(int j = 3; j <= Math.Sqrt(int.Parse(ss[i])); j++)
                    {
                        if(int.Parse(ss[i]) % j != 0)
                        {
                            ok = true;
                        }
                       
                    }
                  
                }
                if (ok == true)
                {
                    Console.WriteLine(f.Name);
                }
            }
            Console.ReadKey();
        }

    }
}
