using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeWithGameAndSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Game.Init();


            while (!Game.GameOver)
            {
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.BackgroundColor = ConsoleColor.Black;

                Console.Write(Game.counter);

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
                    case ConsoleKey.F1:
                        Game.Serialize();
                        Console.Clear();
                        break;
                    case ConsoleKey.F2:
                        Game.Desialize();
                        break;

                }

                if (Game.snake.Eat(Game.food))
                {
                    Game.food.SetPosition(Game.wall);
                }
                if (Game.counter == Game.level * 2)
                {
                    Game.level++;
                    Game.wall = new Wall();
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
                    Game.GameOver = true;
                    //Console.ReadKey();
                    Console.Clear();
                    Console.SetCursorPosition(15, 15);
                    Console.WriteLine("GAME OVER!");
                    Game.counter = 0;
                    Console.ReadKey();
                    Console.Clear();
                    
                    Game.snake = new Snake();
                    Game.level = 1;
                    Game.wall = new Wall();
                }
                /*if (counter + Game.snake.cnt % 5 == 0)
                {
                    if (Game.speed > 0)
                    {
                        Game.speed -= 10;

                    }
                }*/

                Game.Draw();
                //Console.Clear();

            }
        }
    }
}
