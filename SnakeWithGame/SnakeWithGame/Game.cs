using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeWithGame
{
    class Game
    {

        public static Snake snake;
        public static Food food;
        public static Wall wall;
        public static int level;
        public static bool GameOver;
        public static int direction;
        public static int speed;
        public static void Init()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(120, 30);
            level = 1;
            snake = new Snake();
            food = new Food();
            wall = new Wall();
            direction = 1;
            speed = 500;
            GameOver = false;
        }
        
        public static void Draw()
        {
            snake.Draw();
            food.Draw();
            wall.Draw();
        }
    }
}
