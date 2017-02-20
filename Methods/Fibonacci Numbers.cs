using System;
using System.Collections.Generic;
using System.Linq;
public class Fibonacci
{
    public List<long> fibList;
    public Fibonacci(long n)
    {
        List<long> result = new List<long>();
        long n1 = 0;
        long n2 = 1;
        result.Add(n1);
        result.Add(n2);
        long n3 = 0;
        for (int i = 0; i <= n; i++)
        {
            n3 = n1 + n2;
            n1 = n2;
            n2 = n3;
            result.Add(n3);
        }
        this.fibList = result;
    }
    public List<long> GetNumbersInRange(int startPosition, int endPosition)
    {
        List<long> result = new List<long>();
        for (int i = startPosition; i < endPosition; i++)
        {
            result.Add(fibList[i]);
        }
        return result;
    }
}
class Program
{
    static void Main(string[] args)
    {
        int startPosition = int.Parse(Console.ReadLine());
        int endPosition = int.Parse(Console.ReadLine());
        Fibonacci fibList = new Fibonacci(endPosition);
        Console.WriteLine(string.Join(", ", fibList.GetNumbersInRange(startPosition, endPosition)));
    }
}
