using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    public class Student
    {
        public string name;
        public static int instanceOfStudents=0;
        public Student(string name)
        {
            this.name = name;
            instanceOfStudents++;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            string inputName = "";
            while ((inputName=Console.ReadLine())!="End")
            {
                Student student = new Student(inputName);
            }
            int count = Student.instanceOfStudents;
            Console.WriteLine(count);
        }
    }
}
