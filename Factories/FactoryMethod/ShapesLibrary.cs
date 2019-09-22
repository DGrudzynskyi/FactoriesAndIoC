using Factories.Shapes;
using System.Collections.Generic;
using System.Linq;

namespace Factories.FactoryMethod
{
    public class ShapesLibrary : IShapesLibrary
    {
        private List<IShape> Shapes;

        public ShapesLibrary() {
            Shapes = new List<IShape>();
        }

        public IShape CreateShape(string shape, params string[] shapeArguments)
        {
            IShape newShape = null;

            switch (shape) {
                case "square":
                case "s":
                    newShape = new Square(double.Parse(shapeArguments[0]), new RectangleAreaEquation());
                    break;
                case "rectangle":
                case "r":
                    newShape = new Rectangle(double.Parse(shapeArguments[0]), double.Parse(shapeArguments[1]), new RectangleAreaEquation());
                    break;
                case "ellipse":
                case "e":
                    newShape = new Ellipse(double.Parse(shapeArguments[0]), double.Parse(shapeArguments[1]), new EllipseAreaEquation());
                    break;
                case "circle":
                case "c":
                    newShape = new Circle(double.Parse(shapeArguments[0]), new EllipseAreaEquation());
                    break;
            }

            if (newShape != null)
            {
                this.Shapes.Add(newShape);
            }
            return newShape;
        }

        public double GetTotalArea()
        {
            return Shapes.Sum(x => x.Area());
        }
    }
}
