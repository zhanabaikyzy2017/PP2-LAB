using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SnakeWithThread
{
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
         public void SetPosition()
        {
            int x = new Random().Next(0, 120);
            int y = new Random().Next(1, 30);

            bool ok = false;
            for (int i = 0; i < Game.wall.body.Count; i++)
            {
                if (Game.wall.body[i].x == x && Game.wall.body[i].y == y)

                    ok = true;
            }
            for(int i = 0; i < Game.snake.body.Count; i++)
            {
                if(x == Game.snake.body[i].x && y == Game.snake.body[i].y)
                {
                    ok = true;
                }
            }

            if (ok == false)
            {
                loc.x = x;
                loc.y = y;
            }
            else
            {
                SetPosition();
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
            FileStream fs = new FileStream("data3.xml", FileMode.Create, FileAccess.ReadWrite);
            XmlSerializer s = new XmlSerializer(typeof(Food));
            try
            {
                s.Serialize(fs, this);
                

            }
            catch (Exception e)
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
            FileStream f = new FileStream("data3.xml", FileMode.Open, FileAccess.ReadWrite);
            XmlSerializer ss = new XmlSerializer(typeof(Food));
            try
            {
               Game.food = ss.Deserialize(f) as Food;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                
            }

            finally
            {
               f.Close();

            }

        }
    }
}
