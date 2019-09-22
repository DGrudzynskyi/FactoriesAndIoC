using Factories.Shapes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Factories.AbstractFactory
{
    interface IShapesLibrary
    {
        void AddShape(IShape shape);

        double GetTotalArea();
    }
}