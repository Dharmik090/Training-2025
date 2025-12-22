using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicsDemo.ClassTypes
{
    internal class Rectangle : IShape, IPrintable
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public Rectangle(double Length, double Width)
        {
            this.Length = Length;
            this.Width = Width;
        }

        public double Area()
        {
            return Length * Width;
        }

        public double Perimeter()
        {
            return (2 * Length + 2 * Width);
        }

        public void PrintDetails()
        {
            Console.WriteLine($"Rectangle: {Width} x {Length}");
            Console.WriteLine($"Area = {Area()}");
            Console.WriteLine($"Perimeter = {Perimeter()}");
        }
    }
}
