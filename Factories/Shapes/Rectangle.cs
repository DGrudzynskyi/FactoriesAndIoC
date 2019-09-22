using System;
using System.Collections.Generic;
using System.Text;

namespace Factories.Shapes
{
    public class Rectangle : IShape
    {
        private IRectangleAreaEquation _rectangleAreaEquation;

        public Rectangle(double length,double height, IRectangleAreaEquation rectangleAreaEquation) {
            Length = length;
            Height = height;
            _rectangleAreaEquation = rectangleAreaEquation;
        }

        public double Length { get; set; }

        public double Height { get; set; }

        public double Area()
        {
            return _rectangleAreaEquation.CalculateArea(Length, Height);
        }
    }
}
