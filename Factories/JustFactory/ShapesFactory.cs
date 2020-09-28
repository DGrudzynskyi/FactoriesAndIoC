using Factories.Shapes;
using Ninject;
using System.Collections.Generic;
using System.Linq;

namespace Factories.JustFactory

{
    public class ShapesFactory : IShapesFactory
    {
        private IRectangleAreaEquation _rectangleAreaEquation;
        private IEllipseAreaEquation _ellipsAreaEquation;

        public ShapesFactory(IRectangleAreaEquation rectangleAreaEquation, IEllipseAreaEquation ellipsAreaEquation)
        {
            _rectangleAreaEquation = rectangleAreaEquation;
            _ellipsAreaEquation = ellipsAreaEquation;
        }

        public IShape CreateShape(string shape, params string[] shapeArguments)
        {
            IShape newShape = null;
            
            switch (shape) {
                case "square":
                case "s":
                    newShape = new Square(double.Parse(shapeArguments[0]), _rectangleAreaEquation);
                    break;
                case "rectangle":
                case "r":
                    newShape = new Rectangle(double.Parse(shapeArguments[0]), double.Parse(shapeArguments[1]), _rectangleAreaEquation);
                    break;
                case "ellipse":
                case "e":
                    newShape = new Ellipse(double.Parse(shapeArguments[0]), double.Parse(shapeArguments[1]), _ellipsAreaEquation);
                    break;
                case "circle":
                case "c":
                    newShape = new Circle(double.Parse(shapeArguments[0]), _ellipsAreaEquation);
                    break;
            }

            return newShape;
        }
    }
}
