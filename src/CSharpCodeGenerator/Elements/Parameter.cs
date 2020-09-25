using CSharpCodeGenerator.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpCodeGenerator.Elements
{
    public class Parameter
    {
        public Parameter(string type, string name, ParameterModifier parameterModifier)
        {
            Type = type;
            Name = name;
            ParameterModifier = parameterModifier;
        }

        public string Type { get;}
        public string Name { get;}
        public ParameterModifier  ParameterModifier {get; }

        public override string ToString()
        {
            return $"{ParameterModifier} {Type} {Name}";
        }
    }
}
