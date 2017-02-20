using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

class Program
{

class ImmutableList
{
    public List<int> collection = new List<int>();

    public ImmutableList(List<int> collection)
    {
        this.collection = collection;
    }
    public ImmutableList Get()
    {
        List<int> newCollection = new List<int>(this.collection);
        var newImmutable = new ImmutableList(newCollection);
        return newImmutable;
    }
}
static void Main(string[] args)
    {
        Type immutableList = typeof(ImmutableList);
        FieldInfo[] fields = immutableList.GetFields();
        if (fields.Length < 1)
        {
            throw new Exception();
        }
        else
        {
            Console.WriteLine(fields.Length);
        }

        MethodInfo[] methods = immutableList.GetMethods();
        bool containsMethod = methods.Any(m => m.ReturnType.Name.Equals("ImmutableList"));
        if (!containsMethod)
        {
            throw new Exception();
        }
        else
        {
            Console.WriteLine(methods[0].ReturnType.Name);
        }

    }
}
