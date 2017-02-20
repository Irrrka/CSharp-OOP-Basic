using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_Inheritance
{
    public class Person
    {
        private string name;
        private int age;
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public virtual string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                if (value.Length<3)
                {
                    throw new ArgumentException("Name's length should not be less than 3 symbols!");
                }
                this.name = value;
            }
        }
        public virtual int Age
        {
            get
            {
                return this.age;
            }
            protected set
            {
                if (value<0)
                {
                    throw new ArgumentException("Age must be positive!");
                }
                this.age = value;
            }
        }

        public override string ToString()
        {
            StringBuilder stringbuilder = new StringBuilder();
            stringbuilder.Append(String.Format("Name: {0}, Age: {1}",
                this.Name,
                this.Age));
            return stringbuilder.ToString();
        }
    }
    public class Child : Person
    {
        public Child(string name, int age)
            : base(name, age)
        {
        }
        public override int Age
        {
            get
            {
                return base.Age;
            }
            protected set
            {
                if (value>15)
                {
                    throw new ArgumentException("Child's age must be less than 15!");
                }
                base.Age = value;
            }
        }
    }
    class Demo
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            try
            {
                Child child = new Child(name, age);
                Console.WriteLine(child);
            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
            }
        }
    }
}
