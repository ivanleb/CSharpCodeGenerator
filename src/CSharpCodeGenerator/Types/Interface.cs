using CSharpCodeGenerator.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpCodeGenerator.Types
{
    public class Interface
    {
        public Interface(string name) : this(AccessModifier.Public, name, new Property[0], new Interface[0]) { }
        public Interface(AccessModifier accessModifier, string name, Property[] properties, Interface[] interfaces)
        {
            AccessModifier = accessModifier;
            Name = name;
            properties.ToList().ForEach(p => Properties.Add(p));
            interfaces.ToList().ForEach(i => ImplementedInterfaces.Add(i));
        }

        public void Implement(Interface @interface) => ImplementedInterfaces.Add(@interface);
        public void AddProperty(Property property) => Properties.Add(property);

        public AccessModifier AccessModifier { get; } = AccessModifier.Public;
        public string Name { get; }
        public HashSet<Interface> ImplementedInterfaces { get; private set; } = new HashSet<Interface>();
        public HashSet<Property> Properties { get; private set; } = new HashSet<Property>();
    }
}
