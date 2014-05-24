using System;
namespace SimplePlugins
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class FactoryAttribute : Attribute
    {
        public FactoryAttribute(string name)
            : base()
        {
            Name = name;
        }

        public string Name { get; private set; }

        public string Description { get; set; }
    }
}
