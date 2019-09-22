using System;
using System.Collections.Generic;
using System.Text;

namespace Factories.Shapes
{
    public interface IRectangleAreaEquation
    {
        double CalculateArea(double xSide, double ySide);
    }
}
