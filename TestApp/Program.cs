using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using TestPlatform;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var registry = new SimplePlugins.Registry();

            var exeInfo = new FileInfo(Assembly.GetEntryAssembly().Location);
            string dirPath = Path.Combine(exeInfo.Directory.FullName, "Plugins");
            registry.LoadDirectory(dirPath);

            var dict = new Dictionary<string, object>();
            Console.WriteLine("IBase1");
            foreach (var info in registry.GetImportedTypes<IBase1>())
            {
                var item = registry.Create<IBase1>(info.Name, dict);
                Console.WriteLine("{0}: {1}", info.Name, item.Name);
            }

            Console.WriteLine("IBase2");
            foreach (var info in registry.GetImportedTypes<IBase2>())
            {
                var item = registry.Create<IBase2>(info.Name, dict);
                Console.WriteLine("{0}: {1}", info.Name, item.Name);
            }
            
            Console.WriteLine("Done!");
            Console.ReadLine();
        }
    }
}
