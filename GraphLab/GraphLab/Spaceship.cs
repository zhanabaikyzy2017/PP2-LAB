using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace GraphLab
{
    class Spaceship
    {
        int x;
        int y;
        int dx;
        int dy;
        public Point[] points;
        public Point[] pointsOfGun;
        public Spaceship(int x, int y)
        {
            dx = 10;
            dy = 10;
            this.x = x;
            this.y = y;
            points = new Point[]
            {
                new Point(x,y),
                new Point(x + 50, y + 50),
                new Point(x + 50, y + 100),
                new Point(x, y + 150),
                new Point(x - 50, y + 100),
                new Point(x - 50, y + 50),


            };
            pointsOfGun = new Point[]
            {
                new Point(x,y+50),
                new Point(x+10,y+70),
                new Point(x+5,y+70),
                new Point(x+5,y+100),
                new Point(x-5,y+100),
                new Point(x-5,y+70),
                new Point(x-10,y+70),
            };
        }
        public void Draw_Spaceship(Graphics g)
        {
            g.FillPolygon(new SolidBrush(Color.Yellow),points);
            g.FillPolygon(new SolidBrush(Color.Green), pointsOfGun);
        }
        public void Move_Spaceship(Graphics g, int k)
        {
            switch (k)
            {
                case 1:
                    y -= dy;
                    break;
                case 2:
                    y += dy;
                    break;
                case 3:
                    x -= dx;
                    break;
                case 4:
                    x += dx;
                    break;
            }
            
            points = new Point[]
            {
                new Point(x,y),
                new Point(x + 50, y + 50),
                new Point(x + 50, y + 100),
                new Point(x, y + 150),
                new Point(x - 50, y + 100),
                new Point(x - 50, y + 50),


            };
            pointsOfGun = new Point[]
            {
                new Point(x,y+50),
                new Point(x+10,y+70),
                new Point(x+5,y+70),
                new Point(x+5,y+100),
                new Point(x-5,y+100),
                new Point(x-5,y+70),
                new Point(x-10,y+70),
            };
            Draw_Spaceship(g);
        }

    }
}
