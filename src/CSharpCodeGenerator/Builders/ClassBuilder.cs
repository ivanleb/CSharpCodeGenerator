using CSharpCodeGenerator.Elements;
using CSharpCodeGenerator.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpCodeGenerator.Builders
{
    public class ClassBuilder
    {
        private readonly List<FieldBuilder> _fields = new List<FieldBuilder>();
        private readonly List<PropertyBuilder> _properties = new List<PropertyBuilder>();
        private readonly List<ConstructorBuilder> _constructors = new List<ConstructorBuilder>();
        private readonly List<MethodBuilder> _methods = new List<MethodBuilder>();
        private readonly List<InterfaceBuilder> _interfaces = new List<InterfaceBuilder>();
        private string _ancesorType = "";
        private string _name;

        private ClassBuilder(string name)
        {
            _name = name;
        }

        public static ClassBuilder AddClass(string name) 
        {
            return new ClassBuilder(name);
        }

        public ClassBuilder AddField(FieldBuilder builder)
        {
            _fields.Add(builder);
            return this;
        }

        public ClassBuilder AddFields(params FieldBuilder[] builders)
        {
            _fields.AddRange(builders);
            return this;
        }

        public ClassBuilder AddProperty(PropertyBuilder builder)
        {
            _properties.Add(builder);
            return this;
        }

        public ClassBuilder AddMethod(MethodBuilder methodBuilder)
        {
            _methods.Add(methodBuilder);
            return this;
        }

        public ClassBuilder AddConstructor(ConstructorBuilder builder)
        {
            _constructors.Add(builder);
            return this;
        }

        public ClassBuilder AddAncesor(string ancesorType)
        {
            if(String.IsNullOrEmpty(_ancesorType))
                _ancesorType = ancesorType;
            return this;
        }

        public ClassBuilder Implement(InterfaceBuilder interfaceBuilder)
        {
            _interfaces.Add(interfaceBuilder);
            return this;
        }

        public Class Build() 
        {
            var @class = new Class(_name);

            @class.Fields.UnionWith(_fields.Select(builder => builder.Build()));
            @class.Properties.UnionWith(_properties.Select(builder => builder.Build()));
            @class.Methods.UnionWith(_methods.Select(builder => builder.Build()));
            @class.ImplementedInterfaces.UnionWith(_interfaces.Select(builder => builder.Build()));
            @class.Constructors.UnionWith(
                _constructors.Select(builder => builder
                    .Name(@class.Name)
                    .Static(@class.IsStatic)
                    .Build()));

            return @class;
        }
    }
}
