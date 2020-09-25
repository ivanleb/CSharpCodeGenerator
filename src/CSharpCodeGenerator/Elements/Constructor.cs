using CSharpCodeGenerator.Builders;
using CSharpCodeGenerator.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpCodeGenerator.Elements
{
    public class Constructor : Member
    {
        private HashSet<Parameter> _parameters;
        private Dictionary<string, string> _constructorMap = new Dictionary<string, string>();
        public Constructor(AccessModifier accessModifier, string name, Parameter[] parameters) : base(accessModifier, "", name)
        {
            _parameters = new HashSet<Parameter>(parameters);
        }

        public void Parameter(Parameter parameter) => _parameters.Add(parameter);

        public void Parameter(Parameter parameter, Member bindedMember) 
        {
            if (parameter.Type != bindedMember.Type) throw new Exception("Type mismatch");
            _constructorMap[bindedMember.Name] = parameter.Name;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var pair in _constructorMap)
            {
                sb.Append("this." + pair.Key + " = " + pair.Value + ";\n");
            }
            return $@"{AccessModifier} {Name}({ _parameters.Select(prop => prop.ToString()).Aggregate((acc, arg) => acc + "," + arg)}) 
            {{
                {sb}
            }}";
        }

        public static ConstructorBuilder Add() => ConstructorBuilder.AddConstructor();
    }
}
