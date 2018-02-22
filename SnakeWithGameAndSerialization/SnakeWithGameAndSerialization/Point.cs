using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeWithGameAndSerialization
{
    public class Point
    {
        public int x, y;
        public Point(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
        public Point()
        {
            x = 0;
            y = 0;

        }
    }
}
