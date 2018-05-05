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

namespace task4
{
    public partial class Form1 : Form
    {
        List<Rectangle> list;
        List<string> clist;
        Graphics g;
        int y;
        public int cnt = 0;
        public Point cur;
        GraphicsPath path;
        public Point prev;
        string[] colors;
        public Form1()
        {
            InitializeComponent();
            list = new List<Rectangle>();
            clist = new List<string>();
            g = CreateGraphics();
            timer1.Start();
            timer2.Start();
            y = 0;
            colors = new string[] { "Red", "Blue", "Green"};
            path = new GraphicsPath();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            Rectangle rec = new Rectangle(r.Next(0,Width),y,20,20);
            list.Add(rec);
            Random s = new Random();
            Color color = Color.FromName(colors[s.Next(0, 3)]);
            clist.Add(color.Name);
            g.FillEllipse(new SolidBrush(color), rec);
           //Refresh();
            y+=10;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            /*List<Rectangle> nlist = new List<Rectangle>();
            for(int i = 0; i < list.Count; i++)
            {
                nlist.Add(new Rectangle(list[i].Location.X, list[i].Location.Y + 15, 20, 20));
            }
            
          foreach(Rectangle t in nlist)
            {
                Random s = new Random();
                Color color = Color.FromName(colors[s.Next(0, 3)]);
                g.FillEllipse(new SolidBrush(color), t);
            }
            */
            
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if(cnt == 0)
            {
                prev = e.Location;
            }
            
            if (cnt == 1)
            {
                MessageBox.Show("asd");

                cur = e.Location;
                cnt = 0;
            }
            for(int i = 0; i < list.Count; i++)
            {
                for(int j = 0; j < list.Count; j++)
                {
                    if(list[i] != list[j])
                    {
                        if (list[i].Location == prev && list[j].Location == cur)
                        {
                            if (clist[i] == clist[j])
                            {
                            }
                        }
                    }
                }
            }
            cnt++;
        }
    }
}
