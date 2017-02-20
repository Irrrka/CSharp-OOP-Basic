using System;
using System.Collections.Generic;
using System.Linq;

namespace Drawingtool
{
    public abstract class Shape
    {
        public abstract void Draw();
    }
    public class Rectangular : Shape
    {
        public int width;
        public int lenght;
        public Rectangular(int width, int lenght)
        {
            this.width = width;
            this.lenght = lenght;
        }
        public override void Draw()
        {
            Console.WriteLine("{0}{1}{0}", '|', new string('-', this.width));
            for (int i = 0; i < this.lenght-2; i++)
            {
                Console.WriteLine("{0}{1}{0}", '|', new string(' ', this.width));
            }
            Console.WriteLine("{0}{1}{0}", '|', new string('-', this.width));
        }
    }
    public class Square : Shape
    {
        public int side;
        public Square(int side)
        {
            this.side = side;
        }
        public override void Draw()
        {
            Console.WriteLine("{0}{1}{0}", '|', new string('-', this.side));
            for (int i = 0; i < this.side - 2; i++)
            {
                Console.WriteLine("{0}{1}{0}", '|', new string(' ', this.side));
            }
            Console.WriteLine("{0}{1}{0}", '|', new string('-', this.side));
        }
    }

    public class CorDraw
    {
        public CorDraw(Shape shape)
        {
            this.Draw(shape);
        }
        public void Draw(Shape shape)
        {
            shape.Draw();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfShape = Console.ReadLine();
            Shape shape = null;

            switch (typeOfShape)
            {
                case "Square":
                    int side = int.Parse(Console.ReadLine());
                    shape = new Square(side);
                    break;
                case "Rectangle":
                    int width = int.Parse(Console.ReadLine());
                    int lenght = int.Parse(Console.ReadLine());
                    shape = new Rectangular(width, lenght);
                    break;
            }
            CorDraw drawer = new CorDraw(shape);
        }
    }
}
