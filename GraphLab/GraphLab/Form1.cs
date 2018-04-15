using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphLab
{
    public partial class Form1 : Form
    {
        Graphics g;
        public List<Rectangle> stars = new List<Rectangle>();
        public Form1()
        {
            InitializeComponent();
            Width = 1000;
            Height = 700;
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controls.Clear();

            g = CreateGraphics();
           
            Rectangle r = new Rectangle(0, 0, 870, 600);
            g.FillRectangle(new SolidBrush(Color.Blue), r);
            g.DrawRectangle(new Pen (Color.Black, 6), r);

            Rectangle rr = new Rectangle(700, 20, 140,30);
            g.FillRectangle(new SolidBrush(Color.White), rr);
            g.DrawRectangle(new Pen(Color.Yellow, 3), rr);
            Font f = new Font(FontFamily.GenericSansSerif,8);
            Brush b = new SolidBrush(Color.Black);
            Point p = new Point(702, 30);
            g.DrawString("Level:1 Score:200 Live:***", f, b,p );
            /*

            Point pp1 = new Point (835,35);
            Point pp2 = new Point(950, 60);
            g.DrawLine(new Pen(Color.Black,2), pp1, pp2);
            g.DrawString("Info Table", f, b, 920, 60); 
            */
            void Draw_Stars(int q, int w)
            {
                SolidBrush S = new SolidBrush(Color.White);
                Rectangle star = new Rectangle(q, w, 30, 30);
                stars.Add(star);
                g.FillEllipse(S, star);
            }
            Draw_Stars(50, 70);
            Draw_Stars(55, 500);
            Draw_Stars(270, 55);
            Draw_Stars(470, 80);
            Draw_Stars(770, 200);
            Draw_Stars(270, 470);
            Draw_Stars(650, 400);
            Draw_Stars(770, 530);

            /*
            Point s1 = new Point(500, 80);
            Point s2 = new Point(920, 85);
            Point s3 = new Point(800, 200);
            g.DrawLine(new Pen(Color.Black,2),s1,s2);
            g.DrawLine(new Pen(Color.Black,2), s2, s3);
            g.DrawString("Stars", f, b, 920,80);
            
            */
            Point[] PointsOfPolygon = new Point[6];
            PointsOfPolygon[0] = new Point(350,250);
            PointsOfPolygon[1] = new Point(400,300);
            PointsOfPolygon[2] = new Point(400,350);  // drawing spaceship
            PointsOfPolygon[3] = new Point(350,400);
            PointsOfPolygon[4] = new Point(300,350);
            PointsOfPolygon[5] = new Point(300,300);
           
            g.FillPolygon(new SolidBrush(Color.Yellow), PointsOfPolygon);// drawing spaceship
            /*
            Point a1 = new Point(420, 325);
            Point a2 = new Point(920, 330);
            g.DrawLine(new Pen(Color.Black,2), a1, a2);
            g.DrawString("Spaceship", f, b, a2);
            */
            
            Point[] PointsOfGun = new Point[7];
            PointsOfGun[0] = new Point(350, 300);
            PointsOfGun[1] = new Point(360, 320);
            PointsOfGun[2] = new Point(355, 320);
            PointsOfGun[3] = new Point(355, 350); // drawing Gun
            PointsOfGun[4] = new Point(345, 350);
            PointsOfGun[5] = new Point(345, 320);
            PointsOfGun[6] = new Point(340, 320);

            g.FillPolygon(new SolidBrush(Color.Green), PointsOfGun);
            /*
            Point g1 = new Point(350, 325);
            Point g2 = new Point(920, 500);
            g.DrawLine(new Pen(Color.Black,2), g1, g2);
            g.DrawString("Gun", f, b, g2);
            
            */

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
            /*
            Point k = new Point(920, 400);
            g.DrawLine(new Pen(Color.Black,2), PointsOfBullet[2],k );
            g.DrawString("Bullet", f, b, k);
            */

            void Draw_Asteroid(int x, int y)
            {
                Point[] point = new Point[]
                {
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
                    new Point(x - 7, y + 15),//11
                };
                g.FillPolygon(new SolidBrush(Color.Red), point);
            }
            Draw_Asteroid(180, 100);
            Draw_Asteroid(190, 400);
            Draw_Asteroid(760, 95);
            Draw_Asteroid(490, 470);
            
           /*
            Point d1 = new Point(190, 450);
            Point d2 = new Point(350, 620);
            Point d3 = new Point(490, 520);

            g.DrawLine(new Pen(Color.Black, 2), d1, d2);
            g.DrawLine(new Pen(Color.Black, 2), d3, d2);
            g.DrawString("Asteroids", f, b, d2);
            */
        }
    }
}
