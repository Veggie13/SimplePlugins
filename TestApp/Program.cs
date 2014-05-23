using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApp
{
    using BaseRegistry = SimplePlugins.Registry<TestPlatform.IBase>;
    using System.IO;

    class Program
    {

        static void Main(string[] args)
        {
            BaseRegistry.Import(@"C:\Corey Derochie\Projects\GitHub\SimplePlugins\TestPlugin1\bin\Debug\TestPlugin1.dll");

            var dict = new Dictionary<string, object>();
            foreach (string type in BaseRegistry.ImportedTypes)
            {
                var item = BaseRegistry.Create(type, dict);
                Console.WriteLine("{0}: {1}", type, item.Name);
            }
            
            Console.WriteLine("Done!");
            Console.ReadLine();
        }
    }
}
