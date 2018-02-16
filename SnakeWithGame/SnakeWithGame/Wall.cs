using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeWithGame
{
    class Wall
    {
        char sign;
        public List<Point> body;
        ConsoleColor color;


        public Wall()
        {
            sign = '#';
            body = new List<Point>();
            color = ConsoleColor.Yellow;
            LoadLevel(Game.level);

        }
        public void LoadLevel(int level)
        {
            string fileName = string.Format(@"Levels\level{0}.txt", Game.level);
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            int row = 0;
            string line = "";
            while (row < 20)
            {
                line = sr.ReadLine();
                for (int col = 0; col < line.Length; col++)
                {
                    if (line[col] == '*')
                        body.Add(new Point(col, row));
                }
                row++;
            }
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);

            }
        }
    }
}
