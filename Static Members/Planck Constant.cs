using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanckConstant
{
    static class Calculation
    {
        public const double PlanckConstant = 6.62606896e-34;
        public const double Pi = 3.14159;

        public static void ReducePlanck()
        {
            Console.WriteLine(Calculation.PlanckConstant/ (2 * Calculation.Pi));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Calculation.ReducePlanck();
        }
    }
}
