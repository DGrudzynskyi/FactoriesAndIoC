using System;
using System.Collections.Generic;
using System.Text;
using Factories.Shapes;

namespace Factories.Shapes
{
    public interface IShapesFactory
    {
        IShape CreateShape(string shape, params string[] parameters);
    }
}