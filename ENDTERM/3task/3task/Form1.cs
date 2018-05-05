using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3task
{
    public partial class Form1 : Form
    {
        Graphics g;
        Point[] p;
        int x1;
        int y1;
        int x2;
        int y2;
        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
           
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            g.DrawPolygon(new Pen(Color.Red), p);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
             x1 = e.Location.X;
             y1 = e.Location.Y;

       
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            x2 = e.Location.X;
            y2 = e.Location.Y;
            p = new Point[]
            {
                new Point((x1+x2)/2,y2),
                new Point((x1+x2)/2 + ),
                new Point(),
                new Point(),
                new Point(),
            };

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
