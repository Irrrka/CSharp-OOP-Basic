using System;
using System.Reflection;
using System.Collections.Generic;

namespace OOP_Classes
{
    class Launcher
    {
        public class Person
        {
            public string name;
            public int age;
            public List<Person> friends; //ако не го инициализираме листа, ако дадем person.friends.Add ще гръмне ексепшън

            public Person()
            {
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
                this.name = name;
                this.age = age;
            }
        }
        static void Main(string[] args)
        {
            Type personType = typeof(Person);
            //FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            //Console.WriteLine(fields.Length);

            Person pesho = new Person();//създава нова инстанция по шаблона на Person
            pesho.name = "Pesho";
            pesho.age = 20;
            Person gosho = new Person();
            gosho.name = "Gosho";
            gosho.age = 18;
            Person stamat = new Person
            {
                name = "Stamat",
                age = 43
            };

            ConstructorInfo emptyCtor = personType.GetConstructor(new Type[] { });
            ConstructorInfo ageCtor = personType.GetConstructor(new[] {typeof(int)});
            ConstructorInfo nameAgeCtor = personType.GetConstructor(new[] { typeof(string), typeof(int) });
            bool swapped = false;
            if (nameAgeCtor==null)
            {
                nameAgeCtor = personType.GetConstructor(new[] { typeof(int), typeof(string) });
                swapped = true;
            }
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Person basePerson = (Person)emptyCtor.Invoke(new object[] { });
            Person personWithAge = (Person)ageCtor.Invoke(new object[] { age});
            Person personwithAgeandName = swapped ? (Person)nameAgeCtor.Invoke(new object[] { name, age })
                : (Person)nameAgeCtor.Invoke(new object[] { name, age });

            Console.WriteLine("{0} {1}", basePerson.name, basePerson.age);
            Console.WriteLine("{0} {1}", personWithAge.name, personWithAge.age);
            Console.WriteLine("{0} {1}", personwithAgeandName.name, personwithAgeandName.age);

        }
    }
}
