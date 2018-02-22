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
    public class Snake
    {
        public char sign;
        public List<Point> body;
        public ConsoleColor color;
        

        public Snake()
        {
            sign = '0';
            body = new List<Point>();
            
            body.Add(new Point(12, 10));
            body.Add(new Point(11, 10));
            body.Add(new Point(10, 10));

            color = ConsoleColor.Green;
        }

        public void Draw()
        {
            for (int i = 0; i < body.Count; i++)
            {
                if (i == 0)
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = color;

                Console.SetCursorPosition(body[i].x, body[i].y);
                Console.Write(sign);
            }
        }


        public void Move(int dx, int dy)
        {
            Console.SetCursorPosition(body[body.Count - 1].x, body[body.Count - 1].y);
            Console.Write(' ');
            /*Console.SetCursorPosition(body[0].x, body[0].y);
            Console.ForegroundColor = color;
            Console.Write(sign);
            */
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            body[0].x += dx;
            body[0].y += dy;

            if (body[0].x > 119)
            {
                body[0].x = 0;
            }
            if (body[0].x < 0)
            {
                body[0].x = 119;
            }
            if (body[0].y > 29)
            {
                body[0].y = 0;
            }
            if (body[0].y < 0)
            {
                body[0].y = 29;
            }

            //Console.Clear();
        }
        public bool Eat(Food food)
        {
            if (body[0].x == food.loc.x && body[0].y == food.loc.y)
            {
                body.Add(new Point(body[body.Count - 1].x, body[body.Count - 1].y));
                Game.counter++;

                return true;
            }
            return false;
        }
        public bool ColisionWithWall(Wall w)
        {
            foreach (Point p in w.body)
            {
                if (p.x == body[0].x && p.y == body[0].y)
                    return true;

            }
            return false;
        }
        public bool Colision()
        {
            for (int i = 1; i < body.Count; i++)
            {
                if (body[0].x == body[i].x && body[0].y == body[i].y)
                    return true;

            }
            return false;
        }
        public void Serialize()
        {
            FileStream fs = new FileStream("data1.xml", FileMode.OpenOrCreate, FileAccess.Write);
            XmlSerializer xm = new XmlSerializer(typeof(Snake));
            xm.Serialize(fs,Game.snake);
            fs.Close();

        }
        public void Deserialize()
        {
            FileStream fs = new FileStream("data1.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xm = new XmlSerializer(typeof(Snake));
            Snake s = new Snake();
            s = xm.Deserialize(fs) as Snake;
            fs.Close();

        }

    }
}
