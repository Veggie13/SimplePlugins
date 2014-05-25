using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestPlugin1
{
    [SimplePlugins.Factory("Test Class2", Description = "This is a test class")]
    public class Class2Factory : SimplePlugins.TypeRegistry<TestPlatform.IBase1>.IFactory
    {
        public TestPlatform.IBase1 Create(IDictionary<string, object> parms)
        {
            return new Class2();
        }
    }

    class Class2 : TestPlatform.IBase1
    {
        public string Name
        {
            get { return "Class2"; }
        }
    }
}
