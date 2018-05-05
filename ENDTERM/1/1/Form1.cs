using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Font f = new Font(FontFamily.GenericSansSerif, int.Parse(toolStripMenuItem3.Text.ToString()));
            label1.Font = f;
          
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Font f = new Font(FontFamily.GenericSansSerif, int.Parse(toolStripMenuItem2.Text.ToString()));
            label1.Font = f;
           
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Font f = new Font(FontFamily.GenericSansSerif, int.Parse(toolStripMenuItem4.Text.ToString()));
            label1.Font = f;
            
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            int x = trackBar1.Value;
          
          
                label1.Location = new Point(label1.Location.X + x, label1.Location.Y);

        }

        private void trackBar1_RightToLeftChanged(object sender, EventArgs e)
        {
            int a = trackBar1.Value;
            label1.Location = new Point(label1.Location.X - a, label1.Location.Y);
        }
    }
}
