using System;
using System.Collections.Generic;
using System.Linq;

namespace Pr3
{
    class Pr_3
    {
        public class Person
        {
            private string name;
            private int age;
            private List<Person> friends; 

            public Person()
            {
                //if (person.name==null)
                //{
                //    throw new ArgumentException("Name cannot be null!");
                //}
                this.name = "No name";
                this.age = 1;
            }
            public Person(int age)
            {
                this.name = "No name";
                this.age = age;
            }
            public Person(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }
            public Person(string name, int age, List<Person> friends)
                : this(name, age)
            {
                this.friends = new List<Person>();
            }
            public string Name
            {
                get;set;
            }
            public int Age
            {
                get; set;
            }
            public List<Person> Friends
            {
                get; set;
            }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            List<Person> persons = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                var personInfo = Console.ReadLine().Split();
                Person person = new Person(
                    personInfo[0],
                    int.Parse(personInfo[1]));

                persons.Add(person);
            }
            persons
            .Where(p => p.Age >= 30)
            .OrderBy(p => p.Name)
            .ToList().ForEach(na => Console.WriteLine("{0} - {1}", na.Name, na.Age));
        }
    }
}
