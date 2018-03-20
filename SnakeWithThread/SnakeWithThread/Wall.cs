using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SnakeWithThread
{
    public class Wall
    {
        public char sign;
        public List<Point> body;
        public ConsoleColor color;

        public Wall()
        {
            sign = '#';
            body = new List<Point>();
            color = ConsoleColor.Yellow;
            
        }
        public Wall(int level)
        {
            sign = '#';
            body = new List<Point>();
            color = ConsoleColor.Yellow;

            LoadLevel(level);

        }
        public void LoadLevel(int level)
        {
            string fileName = string.Format(@"Levels\level{0}.txt", level);
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
        public void Serialize()
        {
            FileStream fs = new FileStream("data2.xml", FileMode.Create, FileAccess.ReadWrite);
            XmlSerializer s = new XmlSerializer(typeof(Wall));
            try
            {
                s.Serialize(fs, this);

            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                fs.Close();

            }

        }
        public void Deserialize()
        {
            FileStream fs = new FileStream("data2.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer ss = new XmlSerializer(typeof(Wall));
            try
            {
                Game.wall = ss.Deserialize(fs) as Wall;

            }
            catch(Exception e)
            {
                Console.WriteLine(e);

            }
            finally
            {
                fs.Close();
            }

        }
    }
}
