using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestPlugin1
{
    public class Class1 : TestPlatform.IBase
    {
        [SimplePlugins.Factory]
        public class Factory : SimplePlugins.Factory<TestPlatform.IBase, Class1>
        {
            public override TestPlatform.IBase Create(IDictionary<string, object> parms)
            {
                return new Class1();
            }
        }

        public string Name
        {
            get { return "Class1"; }
        }
    }
}
