using CSharpCodeGenerator.Elements;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCodeGenerator.Builders
{
    public class ConstructorBuilder
    {
        private Dictionary<Parameter, Member> _parameters = new Dictionary<Parameter, Member>();
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
            return Parameter(new Parameter(type, name, ParameterModifier.None), null);
        }

        public ConstructorBuilder Parameter(string type, string name, string fieldType, string fieldName)
        {
            return Parameter(new Parameter(type, name, ParameterModifier.None), new Field(AccessModifier.None, fieldType, fieldName, false));
        }

        public ConstructorBuilder Parameter(string type, string name, ParameterModifier parameterModifier)
        {
            return Parameter(new Parameter(type, name, parameterModifier), null);
        }

        private ConstructorBuilder Parameter(Parameter parameter, Field bindedField) 
        { 
            _parameters.Add(parameter, bindedField);
            return this;
        }



        public ConstructorBuilder Static(bool isStatic)
        {
            _isStatic = isStatic;
            return this;
        }

        public Constructor Build()
        {
            var constructor = new Constructor(_modifier, _name, _parameters.Keys.ToArray());
            _parameters.Where(p => p.Value != null).ToList().ForEach(p => constructor.Parameter(p.Key, p.Value));
            return constructor;
        }
    }
}