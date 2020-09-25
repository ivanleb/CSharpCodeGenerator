using CSharpCodeGenerator.Elements;
using CSharpCodeGenerator.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CSharpCodeGenerator.Builders
{
    public class InterfaceBuilder
    {
        private string _name;
        private HashSet<PropertyBuilder> _properties = new HashSet<PropertyBuilder>();
        private HashSet<InterfaceBuilder> _interfaces = new HashSet<InterfaceBuilder>();
        private HashSet<MethodBuilder> _methods = new HashSet<MethodBuilder>();

        private InterfaceBuilder(string name)
        {
            _name = name;
        }

        public static InterfaceBuilder AddInterface(string name) 
        {
            return new InterfaceBuilder(name);
        } 

        public InterfaceBuilder AddProperty(PropertyBuilder builder)
        {
            _properties.Add(builder);
            return this;
        }

        public InterfaceBuilder AddMethod(MethodBuilder builder)
        {
            _methods.Add(builder);
            return this;
        }


        public InterfaceBuilder Implement(InterfaceBuilder builder)
        {
            _interfaces.Add(builder);
            return this;
        }

        public Interface Build() 
        {
            return new Interface(AccessModifier.Public, _name, 
                _properties.Select(builder => builder.Build()).ToArray(), 
                _interfaces.Select(builder => builder.Build()).ToArray(),
                _methods.Select(builder => builder.Build()).ToArray());
        }
    }
}
