using System;
using System.Collections.Generic;
using System.Text;

namespace Factories.Shapes
{
    public class RectangleAreaEquation : IRectangleAreaEquation
    {
        public double CalculateArea(double xSide, double ySide)
        {
            return xSide * ySide;
        }
    }
}
