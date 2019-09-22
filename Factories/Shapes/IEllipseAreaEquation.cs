using System;
using System.Collections.Generic;
using System.Text;

namespace Factories.Shapes
{
    public interface IEllipseAreaEquation
    {
        double CalculateArea(double xRadius, double yRadius);
    }
}
