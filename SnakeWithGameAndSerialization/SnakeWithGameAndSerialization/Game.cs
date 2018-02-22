using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeWithGameAndSerialization
{
    class Game
    {
        public static Snake snake;
        public static Food food;
        public static Wall wall;
        public static int level;
        public static bool GameOver;
        public static int counter;

        public static void Init()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(120, 30);
            level = 1;
            snake = new Snake();
            food = new Food();
            wall = new Wall();
            counter = 0;
            GameOver = false;
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
            //Console.Clear();
        }
        public static void Desialize()
        {
            snake.Deserialize();
            food.Deserialize();
            wall.Deserialize();
        }
    }
}
