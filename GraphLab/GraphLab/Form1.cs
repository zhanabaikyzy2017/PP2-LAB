using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphLab
{
    public partial class Form1 : Form
    {
        Graphics g;
        List<Star> stars = new List<Star>();
        List<Asteroid> asteroids = new List<Asteroid>();
        Star a;
        Asteroid aa;
        Spaceship spaceship;

        public Form1()
        {
            InitializeComponent();
            Width = 1000;
            Height = 700;
            a = new Star();
            aa = new Asteroid();
            spaceship = new Spaceship(350,250);
            Random t = new Random();

            for(int i = 0; i < 8; i++)
            {
                int x = t.Next(0, 870);
                int y = t.Next(0, 600);

                stars.Add(new Star(x, y));
            }

            for(int i = 0; i < 4; i++)
            {
                int _x = t.Next(0, 870);
                int _y = t.Next(0, 600);

                asteroids.Add(new Asteroid(_x, _y));
            }
            timer1.Start();

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            
            for(int i = 0; i < stars.Count; i++)
            {
                stars[i].Move_Star(g);
            }
            for(int i = 0; i < asteroids.Count; i++)
            {
                asteroids[i].Move_Asterod(g);
            }
           
            Refresh();
          
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = CreateGraphics();

            Rectangle r = new Rectangle(0, 0, 870, 600);
            g.FillRectangle(new SolidBrush(Color.Blue), r); 
            g.DrawRectangle(new Pen(Color.Black, 6), r);
            
            spaceship.Draw_Spaceship(g);
           
            for(int i = 0; i < stars.Count; i++)
            {
                stars[i].Draw_Star(g);
            }
            for(int i = 0; i < asteroids.Count; i++)
            {
                asteroids[i].Draw_Asteroid(g);
            }
            for(int i = 0; i < stars.Count; i++)
            {
                if(stars[i].Colision(stars,a) == true)
                {
                    stars[i].dx *= -1;
                    stars[i].dy *= -1;
                    a.dx *= -1;
                    a.dy *= -1;
                    
                    stars[i].ok = false;
                   
                }
            }
            for(int i = 0; i < asteroids.Count; i++)
            {
                if(asteroids[i].Colision(asteroids,aa) == true)
                {
                    asteroids[i].dx *= -1;
                    asteroids[i].dy *= -1;
                    aa.dx *= -1;
                    aa.dy *= -1;

                    asteroids[i].ok = false;

                }
            }
           

            
            Rectangle rr = new Rectangle(700, 20, 140, 30);
            g.FillRectangle(new SolidBrush(Color.White), rr);
            g.DrawRectangle(new Pen(Color.Yellow, 3), rr);
            Font f = new Font(FontFamily.GenericSansSerif, 8);
            Brush b = new SolidBrush(Color.Black);
            Point p = new Point(702, 30);
            g.DrawString("Level:1 Score:200 Live:***", f, b, p);
            
           /*
            Point s1 = new Point(500, 80);
            Point s2 = new Point(920, 85);
            Point s3 = new Point(800, 200);
            g.DrawLine(new Pen(Color.Black,2),s1,s2);
            g.DrawLine(new Pen(Color.Black,2), s2, s3);
            g.DrawString("Stars", f, b, 920,80);
            

            Point[] PointsOfBullet = new Point[8];
            PointsOfBullet[0] = new Point(370, 220);
            PointsOfBullet[1] = new Point(375, 225);
            PointsOfBullet[2] = new Point(390, 230);
            PointsOfBullet[3] = new Point(375, 235);
            PointsOfBullet[4] = new Point(370, 240);
            PointsOfBullet[5] = new Point(365, 235);
            PointsOfBullet[6] = new Point(350, 230);
            PointsOfBullet[7] = new Point(365, 225);

            g.FillPolygon(new SolidBrush(Color.Green), PointsOfBullet);
            

            
             Point d1 = new Point(190, 450);
             Point d2 = new Point(350, 620);
             Point d3 = new Point(490, 520);

             g.DrawLine(new Pen(Color.Black, 2), d1, d2);
             g.DrawLine(new Pen(Color.Black, 2), d3, d2);
             g.DrawString("Asteroids", f, b, d2);
             

            
            Point pp1 = new Point (835,35);
            Point pp2 = new Point(950, 60);
            g.DrawLine(new Pen(Color.Black,2), pp1, pp2);
            g.DrawString("Info Table", f, b, 920, 60); 
            
            
            Point k = new Point(920, 400);
            g.DrawLine(new Pen(Color.Black,2), PointsOfBullet[2],k );
            g.DrawString("Bullet", f, b, k);
             
            Point g1 = new Point(350, 325);
            Point g2 = new Point(920, 500);
            g.DrawLine(new Pen(Color.Black,2), g1, g2);
            g.DrawString("Gun", f, b, g2);
           
            Point a1 = new Point(420, 325);
            Point a2 = new Point(920, 330);
            g.DrawLine(new Pen(Color.Black,2), a1, a2);
            g.DrawString("Spaceship", f, b, a2);
            
            */

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    spaceship.Move_Spaceship(g, 1);
                    break;
                case Keys.Down:
                    spaceship.Move_Spaceship(g, 2);
                    break;
                case Keys.Left:
                    spaceship.Move_Spaceship(g, 3);
                    break;
                case Keys.Right:
                    spaceship.Move_Spaceship(g, 4);
                    break;
            }
            Refresh();
        }


    }
}
