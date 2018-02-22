using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SnakeWithGameAndSerialization
{
    [Serializable]
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
        public void Serialize()
        {
            FileStream fs = new FileStream("data2.xml", FileMode.OpenOrCreate, FileAccess.Write);
            XmlSerializer xm = new XmlSerializer(typeof(Wall));
            xm.Serialize(fs, Game.wall);
            fs.Close();

        }
        public void Deserialize()
        {
            FileStream fs = new FileStream("data2.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xm = new XmlSerializer(typeof(Wall));
            Wall s = new Wall();
            s = xm.Deserialize(fs) as Wall;
            fs.Close();

        }
    }
}
