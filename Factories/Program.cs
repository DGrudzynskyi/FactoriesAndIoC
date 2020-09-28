using FM = Factories.FactoryMethod;
using JF = Factories.JustFactory;
using System;
using System.Linq;
using Ninject;
using Factories.Shapes;
using Factories.JustFactory;

namespace Factories
{
    class Program
    {
        static void Main(string[] args)
        {
            IoC.RegisterServices();
            FactoryMain();
            // AbstractFactoryMain();

            // FactoryMethodMain();

            // IoCFactoyMethodMain();
        }

        public static void FactoryMain()
        {
            var library = new JF.ShapesLibrary();
            var factory = new JF.ShapesFactory(new RectangleAreaEquation(), new EllipseAreaEquation());

            commandHandler(library, arguments =>
            {
                var newShape = factory.CreateShape(arguments[0], arguments.Skip(1).ToArray());
                if (newShape != null)
                {
                    library.AddShape(newShape);
                }
            });
        }

        public static void IoCMain()
        {
            var library = IoC.Kernel.Get<IShapesLibrary>();
            var factory = IoC.Kernel.Get<IShapesFactory>();

            commandHandler(library, arguments =>
            {
                var shapesCreationMethod = IoC.Kernel.Get<Func<string[], IShape>>();
                library.AddShape(factory.CreateShape(arguments[0], arguments.Skip(1).ToArray()));
            });
        }

        public static void IoCFactoyMethodMain() {
            var library = IoC.Kernel.Get<IShapesLibrary>();

            commandHandler(library, arguments =>
            {
                var shapesCreationMethod = IoC.Kernel.Get<Func<string[], IShape>>();
                library.AddShape(shapesCreationMethod(arguments));
            });
        }

        
        /*public static void FactoryMethodMain()
        {
            var library = new FM.ShapesLibrary();

            commandHandler(library, arguments =>
            {
                library.CreateShape(arguments[0], arguments.Skip(1).ToArray());
            });
        }*/


        public static void commandHandler(JF.IShapesLibrary library, Action<String[]> specificCommandHandler)
        {
            var exitCommandEntered = false;
            while (!exitCommandEntered)
            {
                Console.WriteLine("Please, add shape to library...");
                var command = Console.ReadLine().Split(" ");
                switch (command[0])
                {
                    case "q":
                        exitCommandEntered = true;
                        break;
                    case "total":
                        Console.WriteLine(library.GetTotalArea());
                        break;
                    default:
                        specificCommandHandler(command);
                        break;
                }
            }
        }
    }
}
