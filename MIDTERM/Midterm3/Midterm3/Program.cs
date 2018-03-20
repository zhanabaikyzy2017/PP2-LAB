using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm3
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\HP\Desktop\PP2-LAB\MIDTERM\Directories");
            FileSystemInfo [] k = dir.GetFileSystemInfos();
            for(int i = 0; i < k.Length; i++)
            {
                string path = k[i].FullName;
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                string s = sr.ReadToEnd();
                for(int j = 0; j < s.Length; j++)
                {
                    if(s[j] == 'F' && s[j+1] == 'I' && s[j+2] == 'T')
                    {
                        Console.WriteLine(k[i]);

                    }

                }
            }
            Console.ReadKey();
        }
    }
}
