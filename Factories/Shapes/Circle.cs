using System;
using System.Collections.Generic;
using System.Text;

namespace Factories.Shapes
{
    public class Circle : IShape
    {
        IEllipseAreaEquation _areaEquation;

        public Circle(double radius, IEllipseAreaEquation ellipseAreaEquation) {
            Radius = radius;
            _areaEquation = ellipseAreaEquation;
        }

        public double Radius { get; set; }

        public double Area() {
            return _areaEquation.CalculateArea(Radius, Radius);
        }
    }
}
