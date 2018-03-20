using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        int score = 0;

        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            timer2.Start();
            label2.Text = score.ToString();
          
        }
        List<Label> list = new List<Label>();
        bool game = true;
        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    button1.Location = new Point(button1.Location.X - 10, button1.Location.Y);
                    if (button1.Location.X < 0)
                        button1.Location = new Point(Width, button1.Location.Y);
                     
                    break;
                case Keys.S:
                    button1.Location = new Point(button1.Location.X + 10, button1.Location.Y);
                    if (button1.Location.X > Width)
                        button1.Location = new Point(0, button1.Location.Y);

                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (game)
            {
                Label l = new Label();
                l.Size = new Size(20, 20);
                l.Text = "O";
                int r = new Random().Next(0, Width);
                l.Location = new Point(r, 0);
                list.Add(l);
                Controls.Add(l);
            }
           
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (game)
            {
                foreach (Label ll in list)
                {
                    ll.Location = new Point(ll.Location.X, ll.Location.Y + 10);
                    if(ll.Location.Y == Height - 70)
                    {
                        label2.Text = (int.Parse(label2.Text) + 1).ToString();
                    }
                    if (Math.Abs(ll.Location.Y - button1.Location.Y) <= button1.Size.Height && Math.Abs(ll.Location.X - button1.Location.X) <= button1.Size.Width)
                    {
                        Controls.Clear();
                        Controls.Add(label1);
                        label1.Text = "Game Over";
                        game = false;
                        timer1.Stop();
                        timer2.Stop();
                    }
                }

            }

          
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.D)
            {
                this.Close();
            }
        }
    }
}
