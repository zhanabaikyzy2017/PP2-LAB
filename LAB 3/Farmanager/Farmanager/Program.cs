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
        static void Show (DirectoryInfo cur, int pos)
        {
            Console.CursorVisible = false;

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
            }


        }
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\HP\Documents\asem");
            int pos = 0;
            while (true)
            {
                Console.Clear();
                Show(dir, pos);
                ConsoleKeyInfo btn = Console.ReadKey();
                switch (btn.Key)
                {
                    case ConsoleKey.UpArrow:
                        pos--;
                        if(pos < 0)
                        {
                            pos = dir.GetFileSystemInfos().Length - 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        pos++;
                        if(pos > dir.GetFileSystemInfos().Length - 1)
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

                            FileStream ff = new FileStream(f.FullName, FileMode.Open, FileAccess.Read);
                            StreamReader d = new StreamReader(ff);
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
    
            }

        }
    }
}
