using System;
using System.Collections.Generic;
using System.Linq;

namespace Pr5
{
    class SpeedRacing
    {
        public class Car
        {
            public string model;
            public double fuel;
            public double fuelCostFor1km;
            public double distanceTraveled;

            public Car(string model, double fuel, double fuelCostFor1km)
            {
                this.model = model;
                this.fuel = fuel;
                this.fuelCostFor1km = fuelCostFor1km;
                this.distanceTraveled = 0;
            }

            public void Drive(int amountOfKm)
            {
                if (amountOfKm <= this.fuel / this.fuelCostFor1km)
                {
                    fuel -= fuelCostFor1km * amountOfKm;
                    this.distanceTraveled += amountOfKm;
                }
                else
                {
                    System.Console.WriteLine("Insufficient fuel for the drive");
                }

            }
        }
        static void Main(string[] args)
        {
            int carstotrack = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            string[] input = null;

            for (int i = 0; i < carstotrack; i++)
            {
                input = Console.ReadLine().Split();
                Car car = new Car(
                    input[0],//audi a4
                    double.Parse(input[1]),//23
                    double.Parse(input[2])//0.3
                    );
                cars.Add(car);//AudiA4 23 0.3, BMW-M2 45 0.42
            }
            input = Console.ReadLine().Split();
            while (input[0]!="End")
            {
                //Drive BMW-M2 56
                string carModel = input[1];
                int amountOfKm = int.Parse(input[2]);
                Car carToDrive = cars.First(c => c.model==carModel);
                carToDrive.Drive(amountOfKm);
                input = Console.ReadLine().Split();
            }
            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.model} {car.fuel:F2} {car.distanceTraveled}");
            }
        }
    }
}
