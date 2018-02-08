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
            int level = 1;
            Snake snake = new Snake();
            Food food = new Food();
            Wall wall = new Wall(level);
            

            while (true)
            {
                Console.Clear();
                snake.Draw();
                food.Draw();
                wall.Draw();

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
                if(snake.body[0].y < 0)
                {
                    snake.body[0].y = 29;
                }
             

                if (snake.Eat(food))
                {
                       food.SetPosition(wall);
                }
                if(snake.ColisionWithWall(wall) == true || snake.Colision() == true)
                {
                    Console.Clear();
                    Console.SetCursorPosition(60, 15);
                    Console.WriteLine("Game Over!/n Press any key to restart");
                    Console.ReadKey();
                    snake = new Snake();
                    level = 1;
                    wall = new Wall(level);
                }
                if(snake.cnt == 2)
                {
                    level++;
                    wall = new Wall(level);
                    snake.ColisionWithWall(wall);
                    snake.cnt = 0;
                    Console.Clear();
                    Console.SetCursorPosition(50, 15);
                    Console.WriteLine("Good job! /n Press ane key to pass to the next level");
                    Console.ReadKey();

                }
               
                snake.Draw();
                wall.Draw();
               

            }

        }
    }
}
