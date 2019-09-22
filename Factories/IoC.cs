using Factories.AbstractFactory;
using Factories.Shapes;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Factories
{
    public static class IoC
    {
        public static IKernel Kernel;


        public static void RegisterServices() {
            Kernel = new StandardKernel();

            Kernel.Bind<IRectangleAreaEquation>().To<RectangleAreaEquation>();
            Kernel.Bind<IEllipseAreaEquation>().To<EllipseAreaEquation>();
            Kernel.Bind<IShapesFactory>().To<ShapesFactory>();

            Kernel.Bind<Func<string[], IShape>>().ToMethod(ctx =>
            {
                var factory = ctx.Kernel.Get<IShapesFactory>();

                return (string[] commandParts) => factory.CreateShape(commandParts[0], commandParts.Skip(1).ToArray());
            });
        }
    }
}
