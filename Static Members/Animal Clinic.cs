using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalClinic
{
    public class Animal
    {
        public string name;
        public string breed;
        public int animalcount;
        
        public Animal(string name, string breed)
        {
            this.name = name;
            this.breed = breed;
            this.animalcount = ++AnimalClinic.patientId;
        }
    }
    public class AnimalClinic
    {
        public static int patientId;
        public static int healedAnimalsCount;
        public static int rehabilitedAnimalsCount;
        public AnimalClinic()
        {
            ++patientId;
            //++healedAnimalsCount;
            //++rehabilitedAnimalsCount;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            List<Animal> healedAnimals = new List<Animal>();
            List<Animal> rehabilitatedAnimals = new List<Animal>();

            while (input[0] != "End")
            {
                string name = input[0];
                string breed = input[1];
                string command = input[2];//heal or rehabilitate
                Animal animal = new Animal(name, breed);
               

                switch (command)
                {
                    case "heal":
                        AnimalClinic.healedAnimalsCount++;
                        healedAnimals.Add(animal);
                        Console.WriteLine($"Patient {AnimalClinic.patientId}: [{animal.name} ({animal.breed})] has been healed!");
                        break;
                    case "rehabilitate":
                        AnimalClinic.rehabilitedAnimalsCount++;
                        rehabilitatedAnimals.Add(animal);
                        Console.WriteLine($"Patient {AnimalClinic.patientId}: [{animal.name} ({animal.breed})] has been rehabilitated!");
                        break;
                }
                input = Console.ReadLine().Split();
            }
            Console.WriteLine($"Total healed animals: {AnimalClinic.healedAnimalsCount}");
            Console.WriteLine($"Total rehabilitated animals: {AnimalClinic.rehabilitedAnimalsCount}");
            input = Console.ReadLine().Split();
            switch (input[0])
            {
                case "heal":
                    foreach (var healedAnimal in healedAnimals)
                    {
                        Console.WriteLine($"{healedAnimal.name} {healedAnimal.breed}");
                    }
                    break;
                case "rehabilitate":
                    rehabilitatedAnimals.Select(x => x.name + " " + x.breed).ToList().ForEach(x => Console.WriteLine(x));
                    break;
            }

        }
    }
}
