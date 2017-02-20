using System;
using System.Linq;

public class Car
{
    public int speed;//km/h
    public double fuel;//l
    public double fuelEconomy;//l/km

    public Car(int speed, double fuel, double fuelEconomy)
    {
        this.speed = speed;
        this.fuel = fuel;
        this.fuelEconomy = fuelEconomy;
    }

    public double distanceTravelled = 0;
    public int hours = 0;
    public int minutes = 0;

    public void Travel(double distance)
    {
        double possibleDistance = Math.Min((this.fuel / fuelEconomy)*speed, distance);
        this.distanceTravelled += possibleDistance;
        this.fuel -= this.fuelEconomy * possibleDistance/speed;
        this.hours += (int)(possibleDistance / speed);
        this.minutes += (int)(possibleDistance % speed);
    }

    public void Refuel(double liters)
    {
        this.fuel += liters;
    }

    public void Distance()
    {
        Console.WriteLine($"Total distance: {this.distanceTravelled:f1} kilometers");
    }
    public void Time()
    {
        Console.WriteLine($"Total time: {this.hours} hours and {this.minutes} minutes");
    }
    public void Fuel()
    {
        Console.WriteLine($"Fuel left: {this.fuel:f1} liters");
    }
}

class CarExercise
{
    static void Main(string[] args)
    {
        double[] carInfo = Console.ReadLine().Split().Select(double.Parse).ToArray();
        Car myBrichka = new Car(
                                (int)carInfo[0], 
                                carInfo[1], 
                                carInfo[2]
                                );
        string input = "";
        while ((input = Console.ReadLine()) != "END")
        {
            string[] command = input.Split();
            switch (command[0])
            {
                case "Travel":
                    myBrichka.Travel(double.Parse(command[1]));
                    break;
                case "Refuel":
                    myBrichka.Refuel(double.Parse(command[1]));
                    break;
                case "Distance":
                    myBrichka.Distance();
                    break;
                case "Time":
                    myBrichka.Time();
                    break;
                case "Fuel":
                    myBrichka.Fuel();
                    break;
            }
        }
    }
}
