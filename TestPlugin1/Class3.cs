using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestPlugin1
{
    [SimplePlugins.Factory("Test Class3", Description = "This is a test class")]
    public class Class3Factory : SimplePlugins.TypeRegistry<TestPlatform.IBase2>.IFactory
    {
        public TestPlatform.IBase2 Create(IDictionary<string, object> parms)
        {
            return new Class3();
        }
    }

    class Class3 : TestPlatform.IBase2
    {
        public string Name
        {
            get { return "Class3"; }
        }
    }
}
