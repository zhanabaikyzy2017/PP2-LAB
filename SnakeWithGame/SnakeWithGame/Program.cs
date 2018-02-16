using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeWithGame
{
    class Program
    {
        
       
        static void Main(string[] args)
        {
            int counter = 0;
            Game.Init();
            

            while (!Game.GameOver)
            {
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.BackgroundColor = ConsoleColor.Black;
               
                Console.Write(counter + Game.snake.cnt);

                ConsoleKeyInfo btn = Console.ReadKey();
                switch (btn.Key)
                {
                    case ConsoleKey.UpArrow:
                        Game.snake.Move(0, -1);
                        break;
                    case ConsoleKey.DownArrow:
                        Game.snake.Move(0, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        Game.snake.Move(-1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        Game.snake.Move(1, 0);
                        break;
                }

                if (Game.snake.Eat(Game.food))
                {
                    Game.food.SetPosition(Game.wall);
                }
                if (Game.snake.cnt == Game.level * 2)
                {
                    Game.level++;
                    Game.wall = new Wall();
                    counter += Game.snake.cnt;
                    Game.snake.cnt = 0;
                    Console.Clear();
                    Console.SetCursorPosition(20, 20);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("GOOD JOB! " +
                        "PRESS ANY KEY TO PASS TO THE NEXT LEVEL");
                    Console.ReadKey();
                    Console.Clear();
                }

                if (Game.snake.Colision() == true || Game.snake.ColisionWithWall(Game.wall) == true)
                {
                    Console.Clear();
                    Console.SetCursorPosition(15, 15);
                    Console.WriteLine("GAME OVER!" +
                        " PRESS ANY KEY TO RESTART");
                    Game.snake.cnt = 0;
                    counter = 0;
                    Console.ReadKey();
                    Console.Clear();

                    Game.snake = new Snake();
                    Game.level = 1;
                    Game.wall = new Wall();
                }
                if(counter + Game.snake.cnt % 5 == 0)
                {
                    if (Game.speed > 0)
                    {
                        Game.speed -= 10;

                    }
                }

               Game.Draw();
                //Console.Clear();

            }
        }
    }
    
}
