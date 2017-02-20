using System;
using System.Linq;
using System.Text;

public class DecimalNumber
{
    public decimal decimalNum;
    public DecimalNumber(decimal decimalNum)
    {
        this.decimalNum = decimalNum;
    }
    public decimal ReverseDecimal()
    {
        string numToString = this.decimalNum.ToString();
        StringBuilder reversed = new StringBuilder();
        for (int i = numToString.Length-1; i >= 0; i--)
        {
            reversed.Append(numToString[i]);
        }
        return decimal.Parse(reversed.ToString());
    }
}
class Program
{
    static void Main(string[] args)
    {
        decimal num = decimal.Parse(Console.ReadLine());
        DecimalNumber decnum = new DecimalNumber(num);
        var result = decnum.ReverseDecimal();
        Console.WriteLine(result);
    }
}


