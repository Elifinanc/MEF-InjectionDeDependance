using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;


namespace Quete1_MEF_InjectionDeDependance
{
    class Program
    {
        private Host _host;

        static void Main(string[] args)
        {
            var program = new Program();
            program.Run();

            Console.ReadKey();
        }

        private void Run()
        {
            _host = new Host();
            HelloSayer service = _host.Container.GetExportedValue<HelloSayer>();
        }
    }

    internal class Host
    {
        public CompositionContainer Container
        {
            get
            {
                if (_container == null)
                {
                    var catalog = new DirectoryCatalog(".", "Quete1_MEF_InjectionDeDependance.*");
                    _container = new CompositionContainer(catalog);
                }
                return _container;
            }
        }
        private CompositionContainer _container = null;
    }

    [Export]
    internal class SayHello
    {
        public SayHello()
        {
            Console.WriteLine("Hello !");
        }
    }

    [Export]
    internal class HelloSayer
    {
        [Import]
        private SayHello sayHello;
    }
}

