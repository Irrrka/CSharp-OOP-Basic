using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Classes
{
    class Classes
    {
        public class Person
        {
            public string name;
            public int age;
        }
        static void Main(string[] args)
        {
            Type personType = typeof (Person);
            FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine(fields.Length);

            Person pesho = new Person();
            pesho.name = "Pesho";
            pesho.age = 20;
            Person gosho = new Person();
            gosho.name = "Gosho";
            gosho.age = 18;
            Person stamat = new Person();
            gosho.name = "Stamat";
            gosho.age = 43;
        }
    }
}
