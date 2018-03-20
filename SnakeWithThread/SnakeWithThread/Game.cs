using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeWithThread
{
    class Game
    {
        public static Snake snake;
        public static Food food;
        public static Wall wall;

        public static int level;
        public static int direction;
        public static int counter;
        public static int speed;

        public static void Init()
        {
            speed = 300;
            level = 1;
            snake = new Snake();
            food = new Food();
            wall = new Wall(level);
            Console.CursorVisible = false;
            Console.SetWindowSize(120, 30);
            direction = 4;
            counter = 0;
            Console.BackgroundColor = ConsoleColor.Black;
            snake.body.Add(new Point(12, 10));
            snake.body.Add(new Point(11, 10));
            snake.body.Add(new Point(10, 10));
          
        }
        
        public static void Draw()
        {
            
            snake.Draw();
            food.Draw();
            wall.Draw();
        }
        public static void Serialize()
        {
           snake.Serialize();
            food.Serialize();
            wall.Serialize();
            
        } 
        public static void Deserialize()
        {
            snake.Deserialize();
            food.Deserialize();
            wall.Deserialize();
            Draw();
            
        } 
    }
}


