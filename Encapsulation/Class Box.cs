using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ClassBox
{
    public class Box
    {
       public double Lenght { get; set; }
       public double Width { get; set; }
       public double Height { get; set; }

        public Box()
        { }
        public Box(double lenght, double width, double height)
        {
            this.Lenght = lenght;
            this.Width = width;
            this.Height = height;
        }
        public static double SurfaceAres(double lenght, double width, double height)
        {
            //2lw + 2lh + 2wh
            return 2 * lenght*width + 2 * lenght*height + 2 * width*height;
        }
        public static double LateralSurface(double lenght, double width, double height)
        {
            //2lh + 2wh
            return 2 * lenght*height+2*width*height;
        }
        public static double Volume(double lenght, double width, double height)
        {
            //lwh
            return lenght * width * height;
        }
        public static void Print()
        {
            Console.WriteLine();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Count());

            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            Box box = new Box();
            box.Lenght = lenght;
            box.Width = width;
            box.Height = height;

            var lateralsurface = Box.LateralSurface(box.Lenght, box.Width, box.Height);
            var surface = Box.SurfaceAres(box.Lenght, box.Width, box.Height);
            var volume = Box.Volume(box.Lenght, box.Width, box.Height);

            Console.WriteLine($"Surface Area - {surface:F2}");
            Console.WriteLine($"Lateral Surface Area - {lateralsurface:F2}");
            Console.WriteLine($"Volume - {volume:F2}");

        }
    }
}
