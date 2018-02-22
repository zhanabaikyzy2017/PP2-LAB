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
    public class Food
    {
        public char sign;
        public Point loc;
        public ConsoleColor color;

        public Food()
        {
            sign = '@';
            color = ConsoleColor.White;
            loc = new Point(20, 10);
        }
        public void SetPosition(Wall wall)
        {
            int x = new Random().Next(0, 120);
            int y = new Random().Next(0, 30);

            bool ok = false;
            for (int i = 0; i < wall.body.Count; i++)
            {
                if (wall.body[i].x == x && wall.body[i].y == y)
                    ok = true;
            }
            if (ok == false)
            {
                loc.x = x;
                loc.y = y;
            }
            else
            {
                //while(ok != true)
                SetPosition(wall);
            }

        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(loc.x, loc.y);
            Console.Write(sign);
        }
        public void Serialize()
        {
            FileStream fs = new FileStream("data3.xml", FileMode.OpenOrCreate, FileAccess.Write);
            XmlSerializer xm = new XmlSerializer(typeof(Food));
            xm.Serialize(fs, Game.food);
            fs.Close();

        }
        public void Deserialize()
        {
            FileStream fs = new FileStream("data3.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xm = new XmlSerializer(typeof(Food));
            Food s = new Food();
            s = xm.Deserialize(fs) as Food;
            fs.Close();

        }
    }
}
