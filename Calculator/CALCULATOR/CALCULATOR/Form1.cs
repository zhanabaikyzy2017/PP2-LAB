using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CALCULATOR
{
    public partial class Form1 : Form
    {
        CalcBase Calc = new CalcBase();
        bool asd = false;
        public Form1()
        {
            InitializeComponent();
            label1.Text = Calc.memory.ToString();
        }
       
        private void Number_Click(object sender, EventArgs e)
        {

            Button btn = sender as Button;
            /*if (asd)
            {
                textBox1.Text = "";
                asd = false;
            }
            */
            if (Calc.ok == true && textBox1.Text != "0,")
            {
                textBox1.Text = "";
            }

            if (textBox1.Text == "0")
            {

                textBox1.Text = "";
            }
            
            textBox1.Text += btn.Text;
            Calc.ok = false;
        }
        private void Operation_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            
            string s = textBox1.Text;
            Calc.first = double.Parse(s);
            Calc.second = double.Parse(s);
            asd = true;
           Calc.ok = true;
            Calc.operation = btn.Text;
           // textBox1.Text = "0";
           
        }

        private void Result_Click(object sender, EventArgs e)
        {
            
            if (Calc.ok == true)
            {
                Calc.first = Calc.result;
              
                Calc.operate();
                textBox1.Text = Calc.result.ToString();
                
            }
             
            if (Calc.ok == false)
            {
                /*if(textBox1.Text == "")
                {
                    Calc.second = Calc.first;
                }
                else
                {*/
                
                    Calc.second = double.Parse(textBox1.Text);
                    textBox1.Text = Calc.result.ToString();
                //MessageBox.Show(Calc.second.ToString());
//                }

                Calc.operate();
                textBox1.Text = Calc.result.ToString();
                
            }
            if(Calc.operation == "/" && Calc.second == 0)
            {
                textBox1.Text = "ERROR";
            }
        }
        
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar <= 48 || e.KeyChar >= 59) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
           
        }

       private void Mod_Click(object sender, EventArgs e)
        {
            Calc.first = double.Parse(textBox1.Text);
            Calc.ok = true;
            Calc.operation = "Mod";
            
        }
       
        private void buttonsqrt_Click(object sender, EventArgs e)
        {
         
            Calc.one = double.Parse(textBox1.Text);
            if(Calc.one > 0)
            {
                Calc.oneop = "sqrt";
                Calc.calculate();
                textBox1.Text = Calc.result.ToString();
            }
            else
            {
                textBox1.Text = "ERROR";
            }
           
            Calc.ok = true;


        }

        private void buttonpoint_Click(object sender, EventArgs e)
        {
            if(Calc.ok == true)
            {
                textBox1.Text = "0,";
            }
            if (!textBox1.Text.Contains(","))
            {
                textBox1.Text += ",";
            }
            
        }
        private void plusorminus_Click(object sender , EventArgs e)
        {
            double d = double.Parse(textBox1.Text);
            d = d * -1;
            textBox1.Text = d.ToString();
           
        }
        private void Factorial_Click(object sender , EventArgs e)
        {
            Calc.one = double.Parse(textBox1.Text);
            Calc.oneop = "!";
            Calc.calculate();
            textBox1.Text = Calc.result.ToString();
            Calc.ok = true;

        }
        private void xSquare_Click(object sender, EventArgs e)
        {
            Calc.one = double.Parse(textBox1.Text);
            Calc.oneop = "x^2";
            Calc.calculate();
            textBox1.Text = Calc.result.ToString();
            Calc.ok = true;
            
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            Calc = new CalcBase();
            label1.Text = Calc.memory.ToString();
            FileStream f = new FileStream(@"data.txt", FileMode.Open, FileAccess.Write);
            StreamWriter s = new StreamWriter(f);
            s.Write("0");
            s.Close();
            f.Close();
        }

        private void XinY(object sender, EventArgs e)
        {
            Calc.first = double.Parse(textBox1.Text);
            Calc.operation = "x^y";
            Calc.operate();
            Calc.ok = true;
        }
        private void  OneDivideByX_Click(object sender, EventArgs e)
        {
            
            Calc.one = double.Parse(textBox1.Text);
            if(Calc.one == 0)
            {
                textBox1.Text = "ERROR";
                Calc.ok = true;

            }
            else
            {
                Calc.oneop = "1/x";
                Calc.calculate();
                Calc.ok = true;
                textBox1.Text = Calc.result.ToString();
            }
        }
        private void E_Click(object sender , EventArgs e)
        {
            Calc.one = double.Parse(textBox1.Text);
            Calc.oneop = "e^x";
            Calc.ok = true;
            Calc.calculate();
            textBox1.Text = Calc.result.ToString();
            
        }
        private void BackSpace_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length == 2  && double.Parse(textBox1.Text) <= 0 )
            {
                textBox1.Text = "0";
            } 
            if(textBox1.Text.Length == 1 && double.Parse(textBox1.Text) > 0)
            {
                textBox1.Text = "0";
                 
            }
            if(textBox1.Text.Length == 3 && double.Parse(textBox1.Text)  == 0)
            {
                textBox1.Text = "0";

            }

            if (textBox1.Text != "0")
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);

            }
            
          
        }
        private void Percent_Click(object sender, EventArgs e)
        {
            Calc.second = double.Parse(textBox1.Text);
            Calc.oneop = "%";
            Calc.calculate();
            textBox1.Text = Calc.result.ToString();
            Calc.ok = true;
           
        }
        private void tanx_Click(object sender, EventArgs e)
        {
            Calc.one = (double.Parse(textBox1.Text) * Math.PI) / 180;
            Calc.oneop = "tan";
            Calc.calculate();
            textBox1.Text = Calc.result.ToString();
            Calc.ok = true;
        }
        private void sinx_Click(object sender, EventArgs e)
        {
            Calc.one =(double.Parse(textBox1.Text) * Math.PI) /180;
            Calc.oneop = "sin";
            Calc.calculate();
            textBox1.Text = Calc.result.ToString();
            Calc.ok = true;

        }
        private void cosx_Click(object sender, EventArgs e)
        {
            Calc.one = (double.Parse(textBox1.Text) * Math.PI) / 180;
            Calc.oneop = "cos";
            Calc.calculate();
            textBox1.Text = Calc.result.ToString();
            Calc.ok = true;
        }
        private void ln_Click(object sender , EventArgs e)
        {
            Calc.one = double.Parse(textBox1.Text);
            Calc.oneop = "ln";
            Calc.calculate();
            Calc.ok = true;
            textBox1.Text = Calc.result.ToString();
        }
        private void MS_Click(object sender, EventArgs e)
        {
            Calc.memory = double.Parse(textBox1.Text);
            label1.Text = Calc.memory.ToString();
            FileStream fs = new FileStream(@"data.txt", FileMode.Open, FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);
            sr.WriteLine(Calc.memory);
            sr.Close();
            fs.Close();
        }
        private void MPlus_Click(object sender, EventArgs e)
        {
            Calc.memory += Calc.result;
            label1.Text = Calc.memory.ToString();
        }
        private void MMinus_Click(object sender, EventArgs e)
        {
            Calc.memory -= Calc.result;
            label1.Text = Calc.memory.ToString();

        }
        private void MCLear_Click(object sender, EventArgs e)
        {
            Calc.memory = 0;
            label1.Text = Calc.memory.ToString();
            FileStream fs = new FileStream(@"data.txt", FileMode.Open, FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);
            sr.WriteLine(0);


        }
        private void MRead_Click(object sender, EventArgs e)
        {
            FileStream fss = new FileStream(@"data.txt", FileMode.Open, FileAccess.Read);
            StreamReader srr = new StreamReader(fss);
            string d = srr.ReadLine();
            textBox1.Text = d;
            srr.Close();
            fss.Close();

        }
    }
}
