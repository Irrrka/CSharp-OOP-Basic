using System;
using System.Collections.Generic;
using System.Linq;
public class Number
{
    public int number;
    public bool isPrime;
    public Number(int number)
    {
        this.number=number;
        this.isPrime = IsPrime(number);
    }
    public static bool IsPrime(int number)
    {
        if (number <= 1)
        {
            return false;
        }

        int divider = 2;
        int maxDivider = (int)Math.Sqrt(number);
        while (divider <= maxDivider)
        {
            if (number % divider == 0)
            {
                return false;
            }
            divider++;
        }
        return true;
    }

    public int FindNextNumber()
    {
        for (int i = this.number+1; i < Int32.MaxValue; i++)
        {
            if (IsPrime(i))
            {
                return i;
            }
        }
        return this.number;
    }
}
class Program
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        Number n = new Number(number);
        Console.WriteLine(n.FindNextNumber() + ", " + n.isPrime.ToString().ToLower());
    }
}
