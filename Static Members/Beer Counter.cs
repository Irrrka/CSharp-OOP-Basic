using System;
using System.Collections.Generic;
using System.Linq;

public class BeerCounter
    {
        public static int beerInstock;//колко бири съм купила
        public static int beerDrankCount;//колко бири съм изпила

    public static void BuyBeer(int beerBought)//добавя бири към бирите които са купени
    {
        beerInstock += beerBought;
    }
    public static void DrinkBeer(int beerDrunk)//добавя бири към изпитите и вади от купените на склад
    {
        beerDrankCount += beerDrunk;
        beerInstock -= beerDrunk;
    }
}
    
class Program
{
    static void Main(string[] args)
    {
        string[] inputArg = Console.ReadLine().Split();
        while (inputArg[0]!="End")
        {
            int beerBought = int.Parse(inputArg[0]);//бири, които съм купила
            int beerDrunk = int.Parse(inputArg[1]);//бири, които съм изпила
            BeerCounter.BuyBeer(beerBought);
            BeerCounter.DrinkBeer(beerDrunk);
            
            inputArg = Console.ReadLine().Split();
        }
        Console.WriteLine($"{BeerCounter.beerInstock} {BeerCounter.beerDrankCount}");
    }
}

