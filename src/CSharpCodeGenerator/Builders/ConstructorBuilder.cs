using CSharpCodeGenerator.Elements;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCodeGenerator.Builders
{
    public class ConstructorBuilder
    {
        private HashSet<Parameter> _parameters = new HashSet<Parameter>();
        private string _name;
        private bool _isStatic;
        private AccessModifier _modifier;

        private ConstructorBuilder()
        {
            _modifier = AccessModifier.Public;
        }

        public static ConstructorBuilder AddConstructor()
        {
            return new ConstructorBuilder();
        }

        public ConstructorBuilder Name(string name)
        {
            _name = name;
            return this;
        }

        public ConstructorBuilder Parameter(string type, string name)
        {
            return Parameter(new Parameter(type, name, ParameterModifier.None));
        }

        public ConstructorBuilder Parameter(string type, string name, ParameterModifier parameterModifier)
        {
            return Parameter(new Parameter(type, name, parameterModifier));
        }

        private ConstructorBuilder Parameter(Parameter parameter) 
        { 
            _parameters.Add(parameter);
            return this;
        }

        public ConstructorBuilder Static(bool isStatic)
        {
            _isStatic = isStatic;
            return this;
        }

        public Constructor Build()
        {
            return new Constructor(_modifier, _name, _parameters.ToArray()) ;
        }
    }
}