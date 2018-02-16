using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(120, 30);
            int lev = 1;
            int counter = 0;
            Snake snake = new Snake();
            Food food = new Food();
            Wall wall = new Wall(lev);

            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.BackgroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;

                Console.Write(counter + snake.cnt);
                ConsoleKeyInfo btn = Console.ReadKey();
                switch (btn.Key)
                {
                    case ConsoleKey.UpArrow:
                        snake.Move(0, -1);
                        break;
                    case ConsoleKey.DownArrow:
                        snake.Move(0, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        snake.Move(-1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        snake.Move(1, 0);
                        break;
                }

                if (snake.body[0].x > 119)
                {
                    snake.body[0].x = 0;
                }
                if (snake.body[0].x < 0)
                {
                    snake.body[0].x = 119;
                }
                if (snake.body[0].y > 29)
                {
                    snake.body[0].y = 0;
                }
                if (snake.body[0].y < 0)
                {
                    snake.body[0].y = 29;
                }

                if (snake.Eat(food))
                {
                    food.SetPosition(wall);
                }
                if(snake.cnt == lev*2)
                {
                    lev++;
                    wall = new Wall(lev);
                    counter += snake.cnt;
                    snake.cnt = 0;
                    Console.SetCursorPosition(20,20);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("GOOD JOB! " +
                        "PRESS ANY KEY TO PASS TO THE NEXT LEVEL");
                    Console.ReadKey();
                    Console.Clear();
                }

                if(snake.Colision() == true || snake.ColisionWithWall(wall) == true)
                {
                    Console.Clear();
                    Console.SetCursorPosition(15, 15);
                    Console.WriteLine("GAME OVER!" +
                        " PRESS ANY KEY TPO RESTART");
                    Console.ReadKey();
                    Console.Clear();

                    snake = new Snake();
                    lev = 1;
                    wall = new Wall(lev);
                }
                snake.Draw();
                food.Draw();
                wall.Draw();
                //Console.Clear();

            }  
        }
    }
}
