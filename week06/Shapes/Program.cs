using System;
using System.Collections.Generic;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();

            Square square1 = new Square("Red", 4);
            shapes.Add(square1);

            Rectangle rect1 = new Rectangle("Blue", 5, 10);
            shapes.Add(rect1);

            Circle circ1 = new Circle("Green", 3.5);
            shapes.Add(circ1);

            Console.WriteLine("--- List of Shapes ---");

            foreach (Shape s in shapes)
            {
                string color = s.GetColor();
                double area = s.GetArea();

                Console.WriteLine($"Color: {color}, Area: {area:F2}");
            }
        }
    }
}