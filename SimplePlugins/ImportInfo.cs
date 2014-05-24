using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace SimplePlugins
{
    public class ImportInfo
    {
        public ImportInfo(string name, string desc, Assembly source)
        {
            Name = name;
            Description = desc;
            SourceAssembly = source;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public Assembly SourceAssembly { get; private set; }

        public override bool Equals(object obj)
        {
            if (obj is ImportInfo)
            {
                return Name.Equals(((ImportInfo)obj).Name);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
