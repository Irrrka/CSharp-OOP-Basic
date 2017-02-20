using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMath
{
    public class MathUtil
    {
        public double firstNumber = 0.0;
        public double secondNumber = 0.0;

        public static double Sum(double firstNumber, double secondNumber)
        {
            return (firstNumber + secondNumber);
        }
        public static double Subtract(double firstNumber, double secondNumber)
        {
            return (firstNumber - secondNumber);
            //return $"{result:F2}";
        }
        public static double Multiply(double firstNumber, double secondNumber)
        {
            return (firstNumber * secondNumber);
            //return $"{result:F2}";
        }
        public static double Divide(double divident, double divisor)
        {
            return (divident / divisor);
            //return $"{result:F2}";
        }
        public static double Percentage(double totalNumber, double percentOfThanNumber)
        {
            return ((totalNumber * percentOfThanNumber)/100);
            //return $"{result:F2}";
        }
        public static void Print(double result)
        {
            Console.WriteLine($"{result:F2}");
        }

    }
    class BasicMath
    {
        static void Main(string[] args)
        {
            string[] inputArg = Console.ReadLine().Split();
            double result = 0.0;

            while (inputArg[0]!="End")
            {
                string command = inputArg[0];
                double firstNumber = double.Parse(inputArg[1]);
                double secondNumber = double.Parse(inputArg[2]);
                

                switch (command)
                {
                    case "Sum":
                        result = MathUtil.Sum(firstNumber, secondNumber);
                        MathUtil.Print(result);
                        break;
                    case "Subtract":
                        result = MathUtil.Subtract(firstNumber, secondNumber);
                        MathUtil.Print(result);
                        break;
                    case "Multiply":
                        //result = MathUtil.Multiply(firstNumber, secondNumber);
                        MathUtil.Print(MathUtil.Multiply(firstNumber, secondNumber));
                        break;
                    case "Divide":
                        //result = MathUtil.Divide(firstNumber, secondNumber);
                        MathUtil.Print(MathUtil.Divide(firstNumber, secondNumber));
                        break;
                    case "Percentage":
                        result = MathUtil.Percentage(firstNumber, secondNumber);
                        MathUtil.Print(result);
                        break;
                }
                inputArg = Console.ReadLine().Split();
            }
        }
    }
}
