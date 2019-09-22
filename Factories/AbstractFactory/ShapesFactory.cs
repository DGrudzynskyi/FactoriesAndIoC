using Factories.Shapes;
using Ninject;
using System.Collections.Generic;
using System.Linq;

namespace Factories.AbstractFactory

{
    public class ShapesFactory : IShapesFactory
    {
        public IShape CreateShape(string shape, params string[] shapeArguments)
        {
            IShape newShape = null;

            switch (shape) {
                case "square":
                case "s":
                    newShape = new Square(double.Parse(shapeArguments[0]), IoC.Kernel.Get<IRectangleAreaEquation>());
                    break;
                case "rectangle":
                case "r":
                    newShape = new Rectangle(double.Parse(shapeArguments[0]), double.Parse(shapeArguments[1]), IoC.Kernel.Get<IRectangleAreaEquation>());
                    break;
                case "ellipse":
                case "e":
                    newShape = new Ellipse(double.Parse(shapeArguments[0]), double.Parse(shapeArguments[1]), IoC.Kernel.Get<IEllipseAreaEquation>()); ;
                    break;
                case "circle":
                case "c":
                    newShape = new Circle(double.Parse(shapeArguments[0]), IoC.Kernel.Get<IEllipseAreaEquation>());
                    break;
            }

            return newShape;
        }
    }
}
