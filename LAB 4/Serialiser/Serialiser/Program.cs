using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialiser
{
    class Program
    {
        static void f1(Complex c)
        {
            FileStream fs = new FileStream(@"data.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xm = new XmlSerializer(typeof(Complex));

            try
            {
                xm.Serialize(fs, c);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                fs.Close();
            }
            Console.WriteLine("5");
            Console.ReadKey();
        }
        static void Main(string[] args)
        {

            string s = Console.ReadLine();
            string[] ss = s.Split(' ');
            string[] n1 = ss[0].Split('/');
            string[] n2 = ss[1].Split('/');
            int a = int.Parse(n1[0]);
            int b = int.Parse(n1[1]);
            int c = int.Parse(n2[0]);
            int d = int.Parse(n2[1]);


            Complex c1 = new Complex(a, b);
            Complex c2 = new Complex(c, d);

            c1.Simplify();
            c2.Simplify();

            Complex c3 = c1 + c2;
            f1(c3);
        }
    }
}
