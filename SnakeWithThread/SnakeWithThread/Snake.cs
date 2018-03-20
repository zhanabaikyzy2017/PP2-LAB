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
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Score:" + Game.counter);
            Console.SetCursorPosition(10, 0);
            Console.WriteLine("Level:" + Game.level);
            Console.SetCursorPosition(20, 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press F1 to pause the game");
            Console.SetCursorPosition(body[body.Count - 1].x, body[body.Count - 1].y);
            Console.Write(' ');
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
               body[0].y = 1;
            }
            if (body[0].y < 1)
            {
                body[0].y = 29;
            }
            
            if (Eat())
            {
                Game.food.SetPosition();
            }
            
            if (Game.snake.Colision() == true || Game.snake.ColisionWithWall(Game.wall) == true)
            {
                Console.Clear();
                 Console.SetCursorPosition(50, 10);
                Console.WriteLine("GAME OVER!" +
                    " PRESS ANY KEY TO RESTART");
                Console.ReadKey();
                Console.Clear();
                Game.Init();
                
                
            }

            if (Game.counter == Game.level * 2 )
            {
              
                Console.Clear();
                Console.SetCursorPosition(50, 10);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Good job, press ENTER to pass to the next level");
                Console.ReadKey();
                Game.level++;
                Game.speed -= 50;
                Game.wall = new Wall(Game.level);
                Console.Clear();

            }
        }

        bool Eat()
        {
            if (body[0].x == Game.food.loc.x && body[0].y == Game.food.loc.y)
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
            FileStream fs = new FileStream("data.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer s = new XmlSerializer(typeof(Snake));
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
            FileStream f = new FileStream("data.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer ss = new XmlSerializer(typeof(Snake));
            try
            {
                Game.snake = ss.Deserialize(f) as Snake; 

            }
            catch (Exception e)
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
