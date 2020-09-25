using CSharpCodeGenerator.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpCodeGenerator.Builders
{
    public class NamespaceBuilder
    {
        private string _name = "";
        private readonly HashSet<string> _usings = new HashSet<string>();
        private readonly HashSet<ClassBuilder> _classBuilders = new HashSet<ClassBuilder>();

        private NamespaceBuilder() { }

        public static NamespaceBuilder AddNamespace(string name) 
        {
            return new NamespaceBuilder().Name(name);
        }

        public NamespaceBuilder Name(string name)
        {
            _name = name;
            return this;
        }

        public NamespaceBuilder Using(string usingName)
        {
            _usings.Add("using " + usingName + ";");
            return this;
        }

        public NamespaceBuilder Class(ClassBuilder builder)
        {
            _classBuilders.Add(builder);
            return this;
        }

        public Namespace Build() 
        {
            return new Namespace(_name, 
                _usings.ToArray(), 
                _classBuilders.Select(builder => builder.Build()).ToArray());
        }
    }
}
