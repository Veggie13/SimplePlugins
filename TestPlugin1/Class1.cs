using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestPlugin1
{
    [SimplePlugins.Factory("Test Class1", Description = "This is a test class")]
    public class Class1Factory : SimplePlugins.Registry<TestPlatform.IBase>.IFactory
    {
        public TestPlatform.IBase Create(IDictionary<string, object> parms)
        {
            return new Class1();
        }
    }

    class Class1 : TestPlatform.IBase
    {
        public string Name
        {
            get { return "Class1"; }
        }
    }
}
