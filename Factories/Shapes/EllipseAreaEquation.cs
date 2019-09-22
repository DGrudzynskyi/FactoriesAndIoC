using System;
using System.Collections.Generic;
using System.Text;

namespace Factories.Shapes
{
    public class EllipseAreaEquation : IEllipseAreaEquation
    {
        public double CalculateArea(double xRadius, double yRadius)
        {
            return Math.PI * xRadius * yRadius;
        }
    }
}
