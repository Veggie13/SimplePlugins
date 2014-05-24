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
            var exeInfo = new FileInfo(Assembly.GetEntryAssembly().Location);
            string importPath = Path.Combine(exeInfo.Directory.FullName, @"..\..\..\TestPlugin1\bin\Debug\TestPlugin1.dll");
            BaseRegistry.Import(importPath);

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
