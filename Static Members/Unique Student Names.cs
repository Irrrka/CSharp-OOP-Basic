using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueStudent
{
    public class Student
    {
        public string name;

        public Student(string name)
        {
            this.name = name;
        }
    }
    public class StudentGroup
    {
        public HashSet<Student> hashSet;
        public static int staticCount=0;
        //public StudentGroup()
        //{
        //    this.studentGroup = new HashSet<string>();
        //    staticCount++;
        //}
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            string inputName = "";

            StudentGroup sss = new StudentGroup();
            sss.hashSet = new HashSet<Student>();
            while ((inputName=Console.ReadLine())!="End")
            {
                Student ivan = new Student(inputName);
                if (!sss.hashSet.Any(x=>x.name==inputName))
                {
                    StudentGroup.staticCount++;
                    sss.hashSet.Add(ivan);
                }

            }
            Console.WriteLine(StudentGroup.staticCount);
        }
    }
}
