using System;
using System.Collections.Generic;
using System.Text;

namespace Factories.Shapes
{
    public class Ellipse : IShape
    {
        IEllipseAreaEquation _areaEquation;

        public Ellipse(double radiusHorizontal, double radiusVertical, IEllipseAreaEquation ellipseAreaEquation) {
            RadiusHorizontal = radiusHorizontal;
            RadiusVertical = radiusVertical;
            _areaEquation = ellipseAreaEquation;
        }

        public double RadiusHorizontal { get; set; }

        public double RadiusVertical { get; set; }

        public double Area() {
            return _areaEquation.CalculateArea(RadiusHorizontal, RadiusVertical);
        }
    }
}
