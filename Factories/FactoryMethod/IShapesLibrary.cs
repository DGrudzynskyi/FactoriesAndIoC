using Factories.Shapes;

namespace Factories.FactoryMethod
{
    public interface IShapesLibrary
    {
        double GetTotalArea();

        IShape CreateShape(string shape, params string[] shapeArguments);
    }
}
