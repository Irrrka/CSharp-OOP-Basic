    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace RecIntersection
    {
        public class Coordinates
        {
            public double x;
            public double y;
            public Coordinates() { }
            public Coordinates(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
        }
        public class Rectangular
        {
            public string ID;
            public double width;
            public double height;
            public Coordinates topleft;
            //public Coordinates downleft;
            //public Rectangular anotherRectangular;
            public Rectangular() { }

            public Rectangular(string ID, double width, double lenght, double x, double y)
            {
                this.ID = ID;
                this.width = width;
                this.height = lenght;
                this.topleft = new Coordinates(x,y);
                //this.downleft = new Coordinates();
               //this.anotherRectangular = new Rectangular();
            }
        
            public bool hasIntersect(Rectangular anotherRectangular)
            {
                Coordinates downleft = new Coordinates(this.topleft.x + this.width, 
                                                        this.topleft.y + this.height);
                Coordinates downLeftAnotherRec = new Coordinates(anotherRectangular.topleft.x + anotherRectangular.width, 
                                                                anotherRectangular.topleft.y + anotherRectangular.height);
                if (anotherRectangular.topleft.x <= downleft.x &&
                    anotherRectangular.topleft.y <= downleft.y)
                {
                    return true;
                }
                return false;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                int[] intersec = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int numofRec = intersec[0];
                int intersections = intersec[1];
                string[] input = null;
                Dictionary <string, Rectangular> rectangularCollection = new Dictionary<string, Rectangular>();
                Rectangular myRectangular = null;

                for (int i = 0; i < numofRec; i++)
                {
                    input = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
                    string ID = input[0];
                    double width = double.Parse(input[1]);
                    double height =double.Parse(input[2]);
                    double topleftX = double.Parse(input[3]);
                    double topleftY = double.Parse(input[4]);
                    myRectangular = new Rectangular(ID, width, height, topleftX, topleftY);
                    rectangularCollection.Add(ID, myRectangular);
                }

                for (int i = 0; i < intersections; i++)
                {
                    input = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
                    string myRec = input[0];
                    string anotherRec = input[1];
                    bool result = false;

                    if (rectangularCollection[anotherRec].topleft.x >= rectangularCollection[myRec].topleft.x
                    && rectangularCollection[anotherRec].topleft.y >= rectangularCollection[myRec].topleft.y)
                    {
                        result = rectangularCollection[myRec].hasIntersect(rectangularCollection[anotherRec]);
                    }
                    else result = rectangularCollection[anotherRec].hasIntersect(rectangularCollection[myRec]);
                Console.WriteLine(result.ToString().ToLower());
                }

            }
        }
    }
