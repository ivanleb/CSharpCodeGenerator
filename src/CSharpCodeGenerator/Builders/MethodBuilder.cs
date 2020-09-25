using CSharpCodeGenerator.Elements;
using System.Collections.Generic;

namespace CSharpCodeGenerator.Builders
{
    public class MethodBuilder
    {
        private List<Parameter> _parameters = new List<Parameter>();
        private AccessModifier _modifier;
        private string _returnType;
        private string _name;

        private MethodBuilder(AccessModifier modifier, string returnType, string name)
        {
            _modifier = modifier;
            _returnType = returnType;
            _name = name;
        }

        private MethodBuilder()
        {
            _modifier = AccessModifier.Public;
        }

        public static MethodBuilder AddMethod(AccessModifier modifier, string returnType, string name) 
        {
            return new MethodBuilder(modifier, returnType, name);
        }

        public static MethodBuilder AddMethod(string returnType, string name)
        {
            return AddMethod(AccessModifier.Public, returnType, name);
        }

        public static MethodBuilder AddMethod()
        {
            return new MethodBuilder();
        }

        public static MethodBuilder AddMethod(string name)
        {
            var method = new MethodBuilder();
            return method.Name(name);            
        }

        public MethodBuilder AddParameter(string type, string name, ParameterModifier modifier)
        {
            var parameter = new Parameter(type, name, modifier);
            _parameters.Add(parameter);
            return this;
        }

        public MethodBuilder ReturnedType(string type)
        {
            _returnType = type;
            return this;
        }

        public MethodBuilder Access(AccessModifier accessModifier)
        {
            _modifier = accessModifier;
            return this;
        }

        public MethodBuilder Name(string name)
        {
            _name = name;
            return this;
        }

        public MethodBuilder AddParameter(string type, string name)
        {
            return AddParameter(type, name, ParameterModifier.None);
        }

        public Method Build() 
        {
            if (string.IsNullOrWhiteSpace(_returnType) || string.IsNullOrWhiteSpace(_name))
            {
                throw new System.Exception();
            }
            return new Method(_modifier, _returnType, _name, _parameters.ToArray());
        }
    }
}
