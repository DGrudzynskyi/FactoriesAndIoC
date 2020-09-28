using Factories.Shapes;

namespace Factories.JustFactory
{
    interface IShapesLibrary
    {
        void AddShape(IShape shape);

        double GetTotalArea();
    }

    interface ICanReceiveShape {
        void AddShape(IShape shape);
    }

    interface IContainShapes {
        double GetTotalArea();
    }
}