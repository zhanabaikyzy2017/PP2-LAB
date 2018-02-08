using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmanager
{
    class Program
    {
        static void Show (DirectoryInfo cur, int pos ,int cnt)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.CursorVisible = false;
            int k = cur.GetFileSystemInfos().Length;

            FileSystemInfo[] data = cur.GetFileSystemInfos();
            
            for(int i = 0; i < data.Length; i++)
            {
              
                if (i == pos)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;

                }
                if (data[i].GetType() == typeof(FileInfo))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                    Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(data[i]);
                cnt++;
                if (cnt == 20)
                {
                    break;
                }

               
            }


        }
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\HP\Documents\asem");
            int pos = 0;
            int cnt = 0;
            int k = dir.GetFileSystemInfos().Length;
            
            while (true)
            {
                
                Show(dir, pos , cnt);
                ConsoleKeyInfo btn = Console.ReadKey();
         
                switch (btn.Key)
                {
                    case ConsoleKey.UpArrow:
                        pos--;
                        if(k != cnt && k == cnt)
                        {
                            if(pos == -1)
                        {
                            pos = k - 1;
                        }
                       
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        pos++;

                        if (pos == k || pos == cnt )
                        {
                            pos = 0;
                        }
                        break;

                    case ConsoleKey.Enter:
                        FileSystemInfo f = dir.GetFileSystemInfos()[pos];
                        
                        if(f.GetType() == typeof(DirectoryInfo))
                        {
                            dir = new DirectoryInfo(f.FullName);
                            pos = 0;
                            Console.BackgroundColor = ConsoleColor.Black;

                        }
                        else{
                            pos = 0;
                            FileStream ff = new FileStream(f.FullName, FileMode.Open, FileAccess.Read);
                            StreamReader d = new StreamReader(ff);
                            Console.BackgroundColor = ConsoleColor.Black;

                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Black;
                            string line = d.ReadToEnd();

                            Console.WriteLine(line);
                            Console.ReadKey();
                            d.Close();
                            ff.Close();

                        }
                        break;

                    case ConsoleKey.Escape:
                        dir = dir.Parent;
                        
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;


                     


                }
                Console.Clear();
            }

        }
    }
}
