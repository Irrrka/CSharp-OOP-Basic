using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintPeople
{
    public class Person : IComparable
    {
        public string name;
        public int age;
        public string occupation;
        public Person(string name, int age, string occupation)
        {
            this.name = name;
            this.age = age;
            this.occupation = occupation;
        }
        public override string ToString()
        {
            return $"{this.name} - age: {this.age}, occupation: {this.occupation}";
        }
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Person tempPerson = obj as Person;
            if (tempPerson != null)
                return this.age.CompareTo(tempPerson.age);
            else
                throw new ArgumentException("Please provide age!");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input = "";
            while ((input=Console.ReadLine())!="END")
            {
                string[] inputArgs = input.Split();
                string name = inputArgs[0];
                int age = int.Parse(inputArgs[1]);
                string occupation = inputArgs[2];
                Person person = new Person(name, age, occupation);
                people.Add(person); 
            }
            people.Sort();
            foreach (Person pers in people)
            {
                Console.WriteLine(pers.ToString());
            }
        }
    }
}
