using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake
    {
        char sign;
        public List<Point> body;
        ConsoleColor color;
        public int cnt = 0;

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
            for(int i = 0; i < body.Count; i++)
            {
                if (i == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                    Console.ForegroundColor = color;

                Console.SetCursorPosition(body[i].x, body[i].y);
                Console.Write(sign);
                Console.SetCursorPosition(0, 0);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(cnt);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = color;
            }
        }

        public void Move(int dx, int dy)
        {
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }
            body[0].x += dx;
            body[0].y += dy;
        }
        public bool Eat(Food food)
        {
            if(body[0].x == food.location.x && body[0].y == food.location.y)
            {
                body.Add(new Point(body[body.Count - 1].x, body[body.Count - 1].y));
                cnt++;
                return true;
            }
            return false;
        }
        public bool ColisionWithWall(Wall w)
        {
            foreach(Point p in w.body)
            {
                if(p.x == body[0].x && p.y == body[0].y)
                {
                    return true;
                }
                
            }
            return false;
        }
        public bool Colision()
        {
            for(int i = 1; i < body.Count; i++)
            {
                if (body[0].x == body[i].x && body[0].y == body[i].y)
                    return true;
            }
            return false;
        }
    }
}
