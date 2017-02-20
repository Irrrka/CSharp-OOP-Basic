using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureConvertor
{
    public class Convertor
{
        public static double CelsiiToFarenheit(double celsii)
        {
            return ((9.0 / 5.0) * celsii) + 32;
        }
        public static double FarenheitToCelsii(double farenheit)
        {
            return ((5.0 / 9.0) * (farenheit - 32));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] arg = Console.ReadLine().Split();
            while (arg[0]!="End")
            {
                double tempToConvert = double.Parse(arg[0]);
                string type = arg[1];
                switch (type)
                {
                    case "Celsius":
                        var result = Convertor.CelsiiToFarenheit(tempToConvert);
                        Console.WriteLine($"{result:F2}" + " Fahrenheit");
                        break;
                    case "Fahrenheit":
                        result = Convertor.FarenheitToCelsii(tempToConvert);
                        Console.WriteLine($"{result:F2}" + " Celsius");
                        break;
                }
                arg= Console.ReadLine().Split();
            }
            


        }

        
    }
}
