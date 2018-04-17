using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphLab
{
    class Asteroid
    {
        public int x;
        public int y;
        public int dx;
        public int dy;
        public bool ok;
        Point[] points;
        public Asteroid()
        {

        }
        public Asteroid(int _x, int _y)
        {
            x = _x;
            y = _y;
            dx = 20;
            dy = 20;
            ok = false;

            points = new Point[] {

                    new Point(x, y), //0
                    new Point(x + 7, y + 15),//1
                    new Point(x + 17, y + 15),//2
                    new Point(x + 12, y + 25),//3
                    new Point(x + 17, y + 35),//4
                    new Point(x + 7, y + 35),//5
                    new Point(x, y + 50),//6
                    new Point(x - 7, y + 35),//7
                    new Point(x - 17, y + 35),//8
                    new Point(x - 12, y + 25),//9
                    new Point(x - 17, y + 15),//10
                    new Point(x - 7, y + 15),//11};

             };
        }
        public void Draw_Asteroid(Graphics g)
        {
            g.FillPolygon(new SolidBrush(Color.Red), points);
        }
        public void Move_Asterod(Graphics g)
        {
            if (x < 0 || x + 30 > 870)
                dx *= -1;
            if (y < 0 || y + 30 > 600)
                dy *= -1;
            x += dx;
            y += dy;
            
            points = new Point[] {
                    new Point(x, y), //0
                    new Point(x + 7, y + 15),//1
                    new Point(x + 17, y + 15),//2
                    new Point(x + 12, y + 25),//3
                    new Point(x + 17, y + 35),//4
                    new Point(x + 7, y + 35),//5
                    new Point(x, y + 50),//6
                    new Point(x - 7, y + 35),//7
                    new Point(x - 17, y + 35),//8
                    new Point(x - 12, y + 25),//9
                    new Point(x - 17, y + 15),//10
                    new Point(x - 7, y + 15),//11};
            };
            Draw_Asteroid(g);
           
        }
        public bool Colision(List<Asteroid> asteroids,Asteroid aa)
        {
            foreach(Asteroid a in asteroids)
            {
                
                if(a.x != this.x && a.y!= y)
                {
                    if(a.x>=x && a.x<=x+34 && a.y >= y && a.y <= y + 50)
                    {
                        ok = true;
                        aa = a;
                    }
                }
            }
            return ok;
        }
    }
}
