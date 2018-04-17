using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsExample
{
    public partial class Form1 : Form
    {
        Rectangle r = new Rectangle(100, 70, 30, 30);
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(new SolidBrush(Color.Blue), r);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            r = new Rectangle(r.Location.X + 10, r.Location.Y, 30, 30);
            Invalidate();
            Update();
        }
    }
}
