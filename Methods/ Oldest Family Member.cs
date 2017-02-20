using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Person
{
    public string name;
    public int age;

    public Person(string name, int age)
    {
        this.name=name;
        this.age=age;
    }
}
public class Family
{
    public List<Person> people;
    public Family()
    {
        this.people = new List<Person>();
    }
    public void AddMember(Person member)
    {
        this.people.Add(member);
    }
    public Person GetOldestMember()
    {
        Person result = people.OrderByDescending(x => x.age).FirstOrDefault();
        return result;
    }
}
class Program
{
    static void Main(string[] args)
    {
        MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
        MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
        if (oldestMemberMethod == null || addMemberMethod == null)
        {
            throw new Exception();
        }

        int n = int.Parse(Console.ReadLine());
        Family family = new Family();
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            string memberName = input[0];
            int memberAge = int.Parse(input[1]);
            Person member = new Person(memberName, memberAge);
            family.AddMember(member);
        }
        Console.WriteLine($"{family.GetOldestMember().name} {family.GetOldestMember().age}");
    }
}

