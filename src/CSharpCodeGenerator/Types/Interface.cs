using CSharpCodeGenerator.Builders;
using CSharpCodeGenerator.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpCodeGenerator.Types
{
    public class Interface
    {
        public Interface(string name) : this(AccessModifier.Public, name, new Property[0], new Interface[0], new Method[0]) { }
        public Interface(AccessModifier accessModifier, string name, Property[] properties, Interface[] interfaces, Method[] methods)
        {
            AccessModifier = accessModifier;
            Name = name;
            Properties.UnionWith(properties);
            ImplementedInterfaces.UnionWith(interfaces);
            Methods.UnionWith(methods);
        }

        public void Implement(Interface @interface) => ImplementedInterfaces.Add(@interface);
        public void AddProperty(Property property) => Properties.Add(property);

        public AccessModifier AccessModifier { get; } = AccessModifier.Public;
        public string Name { get; }
        public HashSet<Interface> ImplementedInterfaces { get; private set; } = new HashSet<Interface>();
        public HashSet<Property> Properties { get; private set; } = new HashSet<Property>();
        public HashSet<Method> Methods { get; private set; } = new HashSet<Method>();

        public static InterfaceBuilder Add(string name) => InterfaceBuilder.AddInterface(name);

    }
}
