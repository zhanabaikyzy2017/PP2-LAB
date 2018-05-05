using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2task
{
    public partial class Form1 : Form
    {
        Graphics g;
        public Rectangle r;
        public Point p;
        List<Rectangle> list;
        int i;
        bool ok;
        int k = 0;
        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
            list = new List<Rectangle>();
            i = 10;
            int j = 5;
            ok = false;
            label1.Text = k.ToString();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ok = true;
            p = e.Location;
            r = new Rectangle(p.X - 10, p.Y - 10, 20, 20);
            i = 10;
            list.Add(r);
           
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            i+=3;
            Refresh();
            /*r.Y += 10;
            g.DrawEllipse(new Pen(Color.Black), new Rectangle(r.X, r.Y, 20, 20));
            */
            foreach (Rectangle r in list)
            {

                g.DrawEllipse(new Pen(Color.Black), new Rectangle(r.X,r.Y+i,20,20));
                
               /* if(r.Location.Y + 20 > Height)
                {
                    k++;
                    label1.Text = k.ToString();
                }
                */
            }
            
            
            
        }
    }
}
