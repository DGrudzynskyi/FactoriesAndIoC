using FM = Factories.FactoryMethod;
using AF = Factories.AbstractFactory;
using System;
using System.Linq;
using Ninject;
using Factories.Shapes;

namespace Factories
{
    class Program
    {
        static void Main(string[] args)
        {
            IoC.RegisterServices();
            //AbstractFactoryMain();

            // FactoryMethodMain();

            IoCFactoyMethodMain();
        }

        static void FactoryMethodMain() {
            var library = new FM.ShapesLibrary();

            commandHandler(command =>
            {
                if (command == "total")
                {
                    Console.WriteLine(library.GetTotalArea());
                }
                else {
                    var arguments = command.Split(" ");
                    library.CreateShape(arguments[0], arguments.Skip(1).ToArray());
                }
            });
        }

        static void AbstractFactoryMain()
        {
            var library = new AF.ShapesLibrary();
            var factory = new AF.ShapesFactory();

            commandHandler(command =>
            {
                if (command == "total")
                {
                    Console.WriteLine(library.GetTotalArea());
                }
                else
                {
                    var arguments = command.Split(" ");
                    var newShape = factory.CreateShape(arguments[0], arguments.Skip(1).ToArray());
                    if (newShape != null)
                    {
                        library.AddShape(newShape);
                    }
                }
            });
        }

        static void IoCFactoyMethodMain() {

            var library = new AF.ShapesLibrary();
            var factory = new AF.ShapesFactory();

            commandHandler(command =>
            {
                if (command == "total")
                {
                    Console.WriteLine(library.GetTotalArea());
                }
                else
                {
                    var arguments = command.Split(" ");
                    var shapesCreationMethod = IoC.Kernel.Get<Func<string[], IShape>>();
                    library.AddShape(shapesCreationMethod(arguments));
                }
            });
        }



        static void commandHandler(Action<String> specificCommandHandler)
        {
            var exitCommandEntered = false;
            Console.WriteLine("Please, add shape to library...");
            while (!exitCommandEntered)
            {
                var command = Console.ReadLine();
                if (command == "q")
                {
                    exitCommandEntered = true;
                    continue;
                }
                else
                {
                    specificCommandHandler(command);
                }
            }
        }
    }
}
