using Factories.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Factories.JustFactory
{
    public class ShapesLibrary : IShapesLibrary
    {
        private List<IShape> _shapes;

        public ShapesLibrary() {
            _shapes = new List<IShape>();
        }

        public void AddShape(IShape shape)
        {
            _shapes.Add(shape);
        }

        public double GetTotalArea()
        {
            return _shapes.Sum(x => x.Area());
        }
    }
}
