using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task3
{
    public partial class Form1 : Form
    {
        int x, y;
        int cx, kx, co, ko;
        List<Button> list;
        int cnt;
        public bool ok;
        public Form1()
        {
            InitializeComponent();
            list = new List<Button>();
            cnt = 0;
            kx = 0;
            cx = 0;
            ok = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            x = 15;
            y = 15;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button b = new Button();
                    b.Size = new Size(50, 50);
                    b.Location = new Point(x, y);
                    b.Text = "";
                    b.Click += button_Click;
                    Controls.Add(b);
                    list.Add(b);
                    x += 55;

                }
                y += 55;
                x = 15;
            }
        }

    

        private void button_Click(object sender, EventArgs e)
        {
            cnt++;
            Button btn = sender as Button;
            if (cnt % 2 != 0)
            {
                btn.Text = "X";
                btn.Click -= button_Click;
            } else if (cnt % 2 == 0)
            {
                btn.Text = "O";
            }
            for(int i = 0; i < list.Count; i++)
            {
                if (list[i].Text == btn.Text)
                {
                    if ((list[i].Location.X == btn.Location.X + 55 && list[i].Location.X == btn.Location.X + 110)  )
                    {
                        if(btn.Text == "X")
                        {
                            cx++;

                        }
                        if(btn.Text == "O")
                        {
                            co++;
                        }
                       /* MessageBox.Show(cx.ToString());
                        MessageBox.Show(co.ToString());
                        */
                    }
                    if (list[i].Location.Y == btn.Location.Y - 55 || list[i].Location.Y == btn.Location.Y + 55)
                    {
                        if(btn.Text == "X")
                        {
                            kx++;

                        }
                        if(btn.Text == "O")
                        {
                            ko++;
                        }
                      /*  MessageBox.Show(kx.ToString());
                        MessageBox.Show(ko.ToString());
*/
                    }
                }
            }
            if(kx == 2 || cx == 2)
            {
                MessageBox.Show("X wins");
                

            }
            if(ko == 2|| co == 2)
            {
                MessageBox.Show("O wins");
              
            }
           
          
        }
    }
}
