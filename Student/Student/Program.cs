using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class Students
    {
        public string name;
        public string surname;
        public int course;
        public string faculty;

         public Students()
        {
            name = "Assem";
            surname = "Dosniyaz";
            course = 1;
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
            Students S = new Students();
            Console.WriteLine(S);
            Students k = new Students();
            k.name = "Assema";
            k.course = 2;
            Console.WriteLine(k);

            Console.ReadKey();


        }
    }
}
