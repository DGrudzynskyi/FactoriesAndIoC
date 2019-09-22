using System;
using System.Collections.Generic;
using System.Text;

namespace Factories.Shapes
{
    public class Square : IShape
    {
        private IRectangleAreaEquation _rectangleAreaEquation;

        public Square(double side, IRectangleAreaEquation rectangleAreaEquation)
        {
            SideSize = side;
            _rectangleAreaEquation = rectangleAreaEquation;
        }

        public double SideSize { get; set; }

        public double Area() {
            return _rectangleAreaEquation.CalculateArea(SideSize, SideSize);
        }
    }
}
