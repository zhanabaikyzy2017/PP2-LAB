using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLab
{
    class Star
    {
        public int x;
        public int y;
        public int dx;
        public int dy;
        public Rectangle r;
        public bool ok;

        public Star()
        {

        }
        public Star(int _x, int _y)
        {
            x = _x;
            y = _y;
            dx = 10;
            dy = 10;
            r = new Rectangle(x, y, 30, 30);
            ok = false;

        }
        public void Draw_Star(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.White),r);

        }
        public void Move_Star(Graphics g)
        {
            if (x < 0 || x + 30 > 870)
                dx *= -1;
            if (y < 0 || y + 30 > 600)
                dy *= -1;
            x += dx;
            y += dy;

            r = new Rectangle(x, y, 30, 30);
            Draw_Star(g);
            
            
            
        }
        public bool Colision(List<Star> stars,Star a)
        {
            foreach(Star s in stars)
            {
                if(s.x!=x && s.y != y)
                {
                    if(s.x>=x && s.x<=x+30 && s.y>=y && s.y <= y+30)
                    {
                        ok = true;
                        a = s;
                    }
                }
            }
           
            return ok;
        }
    }
}
