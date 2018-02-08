using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Food
    {
        char sign;
        public Point location;
        ConsoleColor color;

        public Food()
        {
            sign = '@';
            color = ConsoleColor.White;
            location = new Point(20, 10);
        }
        public void SetPosition(Wall wall)
        {
            int x = new Random().Next(0, 120);
            int y = new Random().Next(0, 30);
            bool ok = false; 
            for(int i = 0; i < wall.body.Count; i++)
            {
                if (wall.body[i].x == x && wall.body[i].y == y)
                    ok = true;
            }
            if (ok == false)
            {
                location.x = x;
                location.y = y;
            }
            else
            {
                SetPosition(wall);
            }
               
            

          
        }
        public void Draw()
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(location.x, location.y);
            Console.Write(sign);
        }
    }
}
