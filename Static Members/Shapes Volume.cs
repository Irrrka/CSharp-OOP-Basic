using System;
using System.Collections.Generic;
using System.Linq;

namespace ShapeVolume
{
    public class TriangularPrism
    {
        public double baseside;
        public double height;
        public double lenght;
        public TriangularPrism(double baseside, double height, double lenght)
        {
            this.baseside = baseside;
            this.height = height;
            this.lenght = lenght;
        }
            
    }
    public class Cube
    {
        public double side;
        public double lenght;
        public Cube(double side)
        {
            this.side = side;
        }
    }
    public class Cylinder
    {
        public double radius;
        public double height;
        public Cylinder(double radius, double height)
        {
            this.radius = radius;
            this.height = height;
        }
    }
    public static class VolumeCalculator
    {
        public static double TriangularPrism(double baseside, double height, double lenght)
        {
            return ((baseside * height) / 2.0) * lenght;
        }
        public static double Cube(double side) 
        {
            return (side * side * side);
        }
        public static double Cylinder(double radius, double height)
        {
            return (Math.PI*radius*radius) * height;
        }
        public static void Print(double result)
        {
            Console.WriteLine($"{result:F3}");
        }
    }
    class ShapeVolume
    {
        static void Main(string[] args)
        {
            string[] inputArg = Console.ReadLine().Split();
            double result = 0.0;

            while (inputArg[0] != "End")
            {
                string figure = inputArg[0];
                switch (figure)
                {
                    case "Cube":
                        double side = double.Parse(inputArg[1]);
                        Cube cube = new Cube(side);
                        result = VolumeCalculator.Cube(cube.side);
                        VolumeCalculator.Print(result);
                        break;
                    case "Cylinder":
                        double radius = double.Parse(inputArg[1]);
                        double height = double.Parse(inputArg[2]);
                        Cylinder cylinder = new Cylinder(radius, height);
                        result = VolumeCalculator.Cylinder(cylinder.radius, cylinder.height);
                        VolumeCalculator.Print(result);
                        break;
                    case "TrianglePrism":
                        double baseside = double.Parse(inputArg[1]);
                        height = double.Parse(inputArg[2]);
                        double lenght = double.Parse(inputArg[3]);
                        TriangularPrism triangularPrism = new TriangularPrism(baseside, height, lenght);
                        result = VolumeCalculator.TriangularPrism(triangularPrism.baseside, triangularPrism.height, triangularPrism.lenght);
                        VolumeCalculator.Print(result);
                        break;
                }
                inputArg = Console.ReadLine().Split();
            }
        }
    }
}
