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

namespace PAINT
{
    public enum Tools {Pencil,Line, Rectangle,Circle,Rtriangle,Itriangle,Eraser,Fill};
    public partial class Form1 : Form
    {
        Graphics g;
        GraphicsPath path;
        Pen pen;
        Point prev;
        Bitmap btm;
        Tools t;
        Queue<Point> q;
        Color Color1, Color2;


        public Form1()
        {
            InitializeComponent();
            //pen = new Pen(Color.Red, 3);
            path = new GraphicsPath();
            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = btm;
            g = Graphics.FromImage(btm);
            g.Clear(Color.White);
            pen = new Pen(Color.Yellow, 3);
            q = new Queue<Point>();
            t = Tools.Pencil;
            numericUpDown1.Value = 2;

            button7.BackColor = pen.Color;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            prev = e.Location;
            if(t == Tools.Fill)
            {
                q.Enqueue(e.Location);
                Color1 = btm.GetPixel(e.X, e.Y);
                Color2 = button7.BackColor;
                while (q.Count > 0)
                {
                    int x = q.First().X;
                    int y = q.First().Y;
                    Fill(x, y + 1);
                    Fill(x, y - 1);
                    Fill(x - 1, y);
                    Fill(x + 1, y);
                    q.Dequeue();

                }
            }
        }
        void Fill(int x, int y)
        {
            if (x >= btm.Width)
                return;
            if (x < 0)
                return;
            if (y >= btm.Height)
                return;
            if (y < 0)
                return;
            if (btm.GetPixel(x, y) != Color1)
                return;
            btm.SetPixel(x, y, Color2);
            q.Enqueue(new Point(x, y));
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            path.Reset();
            Point cur = e.Location;

            if (e.Button == MouseButtons.Left)
            {
                switch (t)
                {
                    case Tools.Pencil:
                        g.DrawLine(pen, prev, cur);
                        prev = cur;
                        break;
                    case Tools.Line:
                        path.AddLine(prev, cur);
                        break;
                    case Tools.Rectangle:
                        int x = Math.Min(prev.X, cur.X);
                        int y = Math.Min(prev.Y, cur.Y);
                        int w = Math.Abs(prev.X - cur.X);
                        int h = Math.Abs(prev.Y - cur.Y);

                        path.AddRectangle(new Rectangle(x, y, w, h));
                        break;
                    case Tools.Circle:
                        int xx = Math.Min(prev.X, cur.X);
                        int yy = Math.Min(prev.Y, cur.Y);
                        int ww = Math.Abs(prev.X - cur.X);
                        int hh = Math.Abs(prev.Y - cur.Y);

                        path.AddEllipse(new Rectangle(xx, yy, ww, hh));
                        break;
                    case Tools.Rtriangle:
                        Point[] p = new Point[3];
                        p[0] = prev;
                        p[1] = cur;
                        p[2] = new Point(prev.X, cur.Y);
                        path.AddPolygon(p);
                        break;
                    case Tools.Itriangle:
                        Point [] pp = new Point[3];
                        /*pp[0] = prev;
                        pp[1] = cur;
                        pp[2] = new Point((prev.X - cur.X),cur.Y);
                        */
                        pp[0] = new Point((prev.X + cur.X)/2,prev.Y);
                        pp[1] = cur;
                        pp[2] = new Point(prev.X, cur.Y);
                        path.AddPolygon(pp);
                        break;
                    case Tools.Eraser:
                        g.DrawLine(new Pen(Color.White, float.Parse((numericUpDown1.Value).ToString())), prev, cur);
                        prev = cur;
                        break;

                }
                
                pictureBox1.Refresh();
            }

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (path != null)
            {
                g.DrawPath(pen, path);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawPath(pen, path);
        }

        private void Tools_clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            switch (btn.Text)
            {
                case "Pencil":
                    t = Tools.Pencil;
                    break;
                case "Line":
                    t = Tools.Line;
                    break;
                case "Rectangle":
                    t = Tools.Rectangle;
                    break;
                case "Circle":
                    t = Tools.Circle;
                    break;
                case "Rtriangle":
                    t = Tools.Rtriangle;
                    break;
                case "Itriangle":
                    t = Tools.Itriangle;
                    break;
                case "Eraser":
                    t = Tools.Eraser;
                    break;
                case "Fill":
                    t = Tools.Fill;
                    break;
            }
        }
        private void Color_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = button7.BackColor;
            if(colorDialog1.ShowDialog()== DialogResult.OK)
            {
                button7.BackColor = colorDialog1.Color;
                pen = new Pen(colorDialog1.Color, float.Parse(numericUpDown1.Value.ToString()));
            }
        }



        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.OpenFile();
                btm = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = btm; 

            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Bitmap Image(.bmp)| *.bmp |
              saveFileDialog1.Filter = "Png Image (.png)|*.png ";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;

                btm.Save(filename);
                
            }
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            pen = new Pen(colorDialog1.Color, float.Parse((numericUpDown1.Value).ToString()));
        }
    }
}
