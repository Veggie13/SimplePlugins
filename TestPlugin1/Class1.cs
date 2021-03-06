﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestPlugin1
{
    [SimplePlugins.Factory("Test Class1", Description = "This is a test class")]
    public class Class1Factory : SimplePlugins.TypeRegistry<TestPlatform.IBase1>.IFactory
    {
        public TestPlatform.IBase1 Create(IDictionary<string, object> parms)
        {
            return new Class1();
        }
    }

    class Class1 : TestPlatform.IBase1
    {
        public string Name
        {
            get { return "Class1"; }
        }
    }
}
