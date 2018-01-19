using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class Student
    {
        public string name;
        public string surname;
        public int course;
        public string faculty;

         public Student()
        {
            name = "Assem";
            surname = "Dosniyaz";
            course = 1;
            faculty = "FIT";
        }
        public Student(string n, string sn, int c)
        {
            name = n;
            surname = sn;
            course = c;
           faculty = "FIT";
        }
        public override string ToString()
        {
            return name + " " + surname + " " + course + " " + faculty;

        }


    }
    class Program
    {
        static void Main(string[] args)
        {
          
            Student s = new Student("Asem", "DoSniyaz", 1);
            Console.WriteLine(s);


            Console.ReadKey();


        }
    }
}
