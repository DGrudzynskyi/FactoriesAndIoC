using Factories.JustFactory;
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

            // при такой привязке новый екземпляр RectangleAreaEquation создаётся каждый раз при необходимости получить IRectangleAreaEquation 
            Kernel.Bind<IRectangleAreaEquation>().To<RectangleAreaEquation>();

            // при такой привязке при необходимости получить IEllipseAreaEquation вызывается метод, который возвращает обьект конкретного класса, 
            // реализующего IEllipseAreaEquation 
            Kernel.Bind<IEllipseAreaEquation>().ToMethod(ctx => {
                return new EllipseAreaEquation();
            });


            Kernel.Bind<IShapesFactory>().To<ShapesFactory>();

            // в єтом случае будет создан только лишь один екземпляр ShapesLibrary, сколько бы раз мы не запрашивали IShapesLibrary
            Kernel.Bind<IShapesLibrary>().To<ShapesLibrary>().InSingletonScope();

            Kernel.Bind<Func<string[], IShape>>().ToMethod(ctx =>
            {
                var factory = ctx.Kernel.Get<IShapesFactory>();

                return (string[] commandParts) => factory.CreateShape(commandParts[0], commandParts.Skip(1).ToArray());
            });
        }
    }
}
