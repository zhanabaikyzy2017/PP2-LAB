using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SnakeWithThread
{
    [Serializable]
    public class Snake
    {
        public char sign;
        public List<Point> body;
        public ConsoleColor color;
        

        public Snake()
        {
            sign = 'o' ;
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
           /* Console.SetCursorPosition(body[0].x, body[0].y);
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

            if (Eat(Game.food))
            {
                Game.food.SetPosition(Game.wall);
            }

            if (Game.snake.Colision() == true || Game.snake.ColisionWithWall(Game.wall) == true)
            {
                Console.Clear();
                 Console.SetCursorPosition(15, 15);
                Console.WriteLine("GAME OVER!" +
                    " PRESS ANY KEY TO RESTART");
                Console.ReadKey();
                Console.Clear();
                
                Game.snake = new Snake();
                Game.level = 1;
                Game.wall = new Wall(Game.level);
                Game.wall.Draw();
                Game.counter = 0;
                
            }
            if (Game.counter == Game.level * 2 )
            {
                Game.level++;
                Game.speed -= 50;
                Game.wall = new Wall(Game.level);
               
                Console.Clear();
                Console.SetCursorPosition(20, 20);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("GOOD JOB! " +
                    "PRESS ANY KEY TO PASS TO THE NEXT LEVEL");
                Console.ReadKey();
                Console.Clear();

            }
           
            //Console.Clear();
        }
         bool Eat(Food food)
        {
            if (body[0].x == Game.food.loc.x && body[0].y == food.loc.y)
            {
                body.Add(new Point(body[body.Count - 1].x, body[body.Count - 1].y));

                Game.counter++;

                return true;
            }
            return false;
        }

        bool ColisionWithWall(Wall w)
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
            FileStream fs = new FileStream("data.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer s = new XmlSerializer(typeof(Snake));
            
                s.Serialize(fs, Game.snake);
                
            
                fs.Close();
                
            
        }
        public void Deserialize()
        {
            FileStream f = new FileStream("data.xml", FileMode.Open, FileAccess.ReadWrite);
            XmlSerializer ss = new XmlSerializer(typeof(Snake));
            try
            {
                Snake s = ss.Deserialize(f) as Snake;
                Game.snake = s;
            }
            catch(Exception e)
            {
                Console.WriteLine(" ");
            }
            finally
            {
                f.Close();
            }
            
        }
    }
}
