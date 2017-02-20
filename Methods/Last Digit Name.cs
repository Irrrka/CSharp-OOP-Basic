using System;
public class Number
{
    public int number;
    public Number(int number)
    {
        this.number = number;
    }
    public string NameOfDigit()
    {
        string numberAsString = this.number.ToString();
        char lastDigit = numberAsString[numberAsString.Length - 1];
        switch (lastDigit)
        {
            case '0': return "zero"; 
            case '1': return "one";  
            case '2': return "two";  
            case '3': return "three";
            case '4': return "four"; 
            case '5': return "five"; 
            case '6': return "six";  
            case '7': return "seven";
            case '8': return "eight";
            case '9': return "nine";
            default:  return "";
        }
    }
}
    class Program
    {
        static void Main(string[] args)
        {
        int integer = int.Parse(Console.ReadLine());
        Number number = new Number(integer);
        string result = number.NameOfDigit();
        Console.WriteLine(result);
    }
    }
