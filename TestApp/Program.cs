using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace TestApp
{
    using BaseRegistry = SimplePlugins.Registry<TestPlatform.IBase>;

    class Program
    {

        static void Main(string[] args)
        {
            var registry = new BaseRegistry();

            var exeInfo = new FileInfo(Assembly.GetEntryAssembly().Location);
            string importPath = Path.Combine(exeInfo.Directory.FullName, @"..\..\..\TestPlugin1\bin\Debug\TestPlugin1.dll");
            registry.Import(importPath);

            var dict = new Dictionary<string, object>();
            foreach (var info in registry.ImportedTypes)
            {
                var item = registry.Create(info.Name, dict);
                Console.WriteLine("{0}: {1}", info.Name, item.Name);
            }
            
            Console.WriteLine("Done!");
            Console.ReadLine();
        }
    }
}
