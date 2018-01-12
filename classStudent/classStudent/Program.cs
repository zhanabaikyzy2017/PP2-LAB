using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classStudent
{
    class Students
    {
        string name;
        int age;
        double gpa;

        Students()
        {
            name = "Assem";
            age = 17;
            gpa = 4.0;
        }
        public override string ToString()
        {
            return name + " " + age + " " + gpa;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Students s = new Students();
            s.name = "Assemoka";
            Console.WriteLine(s);

            Student s2 = new Student();
            Console.WriteLine(s2);
            Console.ReadKey();


        }
    }
}
