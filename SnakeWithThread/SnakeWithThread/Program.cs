using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeWithThread
{
    class Program
    {
        static void MoveSnake()
        {
            while (true)
            {
                switch (Game.direction)
                {
                    case 1:
                        Game.snake.Move(0, -1);
                        break;
                    case 2:
                        Game.snake.Move(0, 1);
                        break;
                    case 3:
                        Game.snake.Move(-1, 0);
                        break;
                    case 4:
                        Game.snake.Move(1, 0);
                        break;


                }
              
                Thread.Sleep(Game.speed);
                Game.Draw();
            }
        }
        static void Main(string[] args)
        {
                
            Game.Init();
            
            Thread t = new Thread(MoveSnake);
            t.Start();

            while (true)
             {
                Console.SetCursorPosition(0, 0);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Score:" + Game.counter);
                Console.SetCursorPosition(10, 0);
                Console.WriteLine("Level:" + Game.level);
                Console.BackgroundColor = ConsoleColor.Black;
                ConsoleKeyInfo btn = Console.ReadKey();
                switch (btn.Key)
                {
                    case ConsoleKey.UpArrow:
                        Game.direction = 1;
                        break;
                    case ConsoleKey.DownArrow:
                        Game.direction = 2;
                        break;
                    case ConsoleKey.LeftArrow:
                        Game.direction = 3;
                        break;
                    case ConsoleKey.RightArrow:
                        Game.direction = 4;
                        break;
                    case ConsoleKey.F1:
                        Game.Serialize();
                        t.Suspend();
                        Console.Clear();
                        Console.SetCursorPosition(60, 10);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("PRESS F2 TO RESUME THE GAME");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case ConsoleKey.F2:
                        Game.Deserialize();
                        t.Resume();  
                        break;
                    case ConsoleKey.Escape:
                        break;
                    
                        
                }
               
                /*if (Game.snake.Eat(Game.food))
                {
                    Game.food.SetPosition(Game.wall);
                }*/
                /*if (Game.snake.cnt == Game.level * 2)
                {
                    Game.level++;
                    Game.wall = new Wall(Game.level);
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
                */

                /*if (Game.snake.Colision() == true || Game.snake.ColisionWithWall(Game.wall) == true)
                {
                    //t = new Thread(MoveSnake);
                    Console.Clear();
                   // Console.SetCursorPosition(15, 15);
                    //Console.WriteLine("GAME OVER!" +
                    //    " PRESS ANY KEY TO RESTART");
                    Console.ReadKey();
                    //Console.Clear();

                    Game.snake = new Snake();
                    Game.level = 1;
                    Game.wall = new Wall(Game.level);
                }*/

                //Game.Draw();
                // Console.Clear();
                
                }
            }
        }
    }

