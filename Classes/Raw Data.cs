using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{

    class Program
    {
        public class Car
        {
            public string model;
            public Cargo cargo = new Cargo();
            public Engine engine = new Engine();
            public Tire tire = new Tire();
            public List<Tire> tires = new List<Tire>(4);

            public Car()
            { }
            public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType,
                    double tire1Pressure, int tire1Age,
                    double tire2Pressure, int tire2Age,
                    double tire3Pressure, int tire3Age,
                    double tire4Pressure, int tire4Age)
            {
                this.model = model;
                this.engine.Speed = engineSpeed;
                this.engine.Power = enginePower;
                this.cargo.Weight = cargoWeight;
                this.cargo.Type = cargoType;
                this.tires.Add(new Tire(this.tire.Pressure = tire1Pressure, this.tire.Age = tire1Age));
                this.tires.Add(new Tire(this.tire.Pressure = tire2Pressure, this.tire.Age = tire2Age));
                this.tires.Add(new Tire(this.tire.Pressure = tire3Pressure, this.tire.Age = tire3Age));
                this.tires.Add(new Tire(this.tire.Pressure = tire4Pressure, this.tire.Age = tire4Age));
            }
        }
        public class Cargo
        {
            private int weight;
            private string type;
            public Cargo()
            { }
            public Cargo(int weight, string type)
            {
                this.weight = weight;
                this.type = type;
            }
            public int Weight
            {
                get; set;
            }
            public string Type
            {
                get; set;
            }

        }
        public class Engine
        {
            private int speed;
            private int power;
            public Engine()
            { }
            public Engine(int speed, int power)
            {
                this.speed = speed;
                this.power = power;
            }

            public int Speed
            {
                get; set;
            }
            public int Power
            {
                get; set;
            }
        }
        public class Tire
        {
            private double pressure;
            private int age;
            public Tire()
            { }
            public Tire(double pressure, int age)
            {
                this.Pressure = pressure;
                this.Age = age;
            }

            public double Pressure
            {
                get; set;
            }
            public int Age
            {
                get; set;
            }

        }
        static void Main(string[] args)
        {
            int amountOfCars = int.Parse(Console.ReadLine());
            Car brichka = new Car();
            List<Car> cars = new List<Car>(amountOfCars);
            for (int i = 0; i < amountOfCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split();
                string model = carInfo[0];
                int engineSpeed =int.Parse(carInfo[1]);
                int enginePower =int.Parse(carInfo[2]);
                int cargoWeight =int.Parse(carInfo[3]);
                string cargoType = carInfo[4];
                double tire1Pressure = double.Parse(carInfo[5]);
                int tire1Age = int.Parse(carInfo[6]);
                double tire2Pressure = double.Parse(carInfo[7]);
                int tire2Age = int.Parse(carInfo[8]);
                double tire3Pressure = double.Parse(carInfo[9]);
                int tire3Age = int.Parse(carInfo[10]);
                double tire4Pressure = double.Parse(carInfo[11]);
                int tire4Age = int.Parse(carInfo[12]);
                brichka = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, 
                    tire1Pressure, tire1Age, 
                    tire2Pressure, tire2Age, 
                    tire3Pressure, tire3Age, 
                    tire4Pressure, tire4Age);
                cars.Add(brichka);
            }
            string filter = Console.ReadLine();
            switch (filter)
            {
                case "fragile":
                    foreach (var car in cars)
                    {
                        if (car.cargo.Type == "fragile" && car.tires.Any(p => p.Pressure < 1))//Pressure!=pressure
                        {
                            Console.WriteLine(car.model);
                        }
                    }
                    break;
                case "flamable":
                    foreach (var car in cars)
                    {
                        if (car.cargo.Type == "flamable" && car.engine.Power > 250)
                        {
                            Console.WriteLine(car.model);
                        }
                    }
                    break;
            }
        }
    }
}
